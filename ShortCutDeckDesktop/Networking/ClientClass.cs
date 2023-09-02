using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Networking
{
    public class ClientClass
    {
        private Socket _clientSocket;
        private Thread _readThread;
        private Thread _writeThread;
        private RecievedMessageHandler _interpreter;
        private List<String> _msgToWrite;

        public ClientClass(Socket clientSocket)
        {
            _clientSocket = clientSocket;
            _msgToWrite = new List<String>();
            _interpreter = new RecievedMessageHandler();
            startExchangingMessages();

            new Thread(disconnectWhenNeeded).Start();
        }

        private void disconnectWhenNeeded()
        {
            try
            {
                while (isSocketConnected())
                {
                    Thread.Sleep(10);
                }
                ServerClass.tryDisconnectClient(this);
            }
            catch (Exception ex) { }
        }

        private void startExchangingMessages() 
        {
            _readThread = new Thread(readingProcess);
            _writeThread = new Thread(writingProcess);
            _readThread.IsBackground = true;
            _writeThread.IsBackground = true;  
            _readThread.Start();
            _writeThread.Start();
        }

        private void readingProcess()
        {
            byte[] buffer;
            int bytesRead = 0;

            try
            {
                while (true)
                {
                    buffer = new byte[1024];
                    bytesRead = _clientSocket.Receive(buffer);

                    if (bytesRead > 0)
                    {
                        _interpreter.handleRecievedMessage(buffer, bytesRead, this);
                    }
                }
            }
            catch (Exception exc)
            {
                //Logger.logServerMsg("WRN!!: " + exc.Message);
            }
        }

        private void writingProcess()
        {
            try
            {
                while (isSocketConnected())
                {
                    if (_msgToWrite.Count > 0)
                    {
                        String msg = _msgToWrite[0];
                        _msgToWrite.RemoveAt(0);

                        byte[] bytesToSend = Encoding.UTF8.GetBytes(msg); // TODO it may have problems
                        _clientSocket.Send(bytesToSend);
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.logServerMsg("WRN!!: " + exc.Message);
            }
        }

        public void disconnect()
        {
            try
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
                Logger.logServerMsg("Client disconnected");
            }
            catch (Exception exc) { }

        }

        public void sendMessage(String msg)
        {
            _msgToWrite.Add(msg);
        }

        private bool isSocketConnected()
        {
            return !((_clientSocket.Poll(1000, SelectMode.SelectRead) && (_clientSocket.Available == 0)) || !_clientSocket.Connected);
        }


        public Socket ClientSocket { get => _clientSocket; }
    }
}
