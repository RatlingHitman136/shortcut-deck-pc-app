using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Networking
{
    public static class ServerClass
    {
        private static Socket? _listenerSocket = null;
        private static List<ClientClass> _clients = new List<ClientClass>();
        private static Thread? _listenerThread;
        private static bool _isRunning = false;
        private static string _serverName = "";

        #region consts
        private const int TERMINATION_TIMEOUT = 100;
        private const int BASE_PORT = 8888;
        #endregion

        public static Socket ListenerSocket { get => _listenerSocket; }
        public static string ServerName { get => _serverName;}
        public static List<ClientClass> Clients { get => _clients; }

        static public void StartServer(string name = "PC device", int port = BASE_PORT)
        {
            if (_isRunning)
            {
                StopServer();
                Logger.logServerMsg("Server Stopped");
            }
            _serverName = name;
            _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(getIp4Address()), port);
            _listenerSocket.Bind(ip);
            _listenerThread = new Thread(ListenForConnections);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
            _isRunning = true;
            Logger.logServerMsg("Server Started \nAwaiting Connections");
        }
        static private void StopServer()
        {
            if (_isRunning)
            {

                if (_clients.Count != 0)
                {
                    //_listenerSocket?.Shutdown(SocketShutdown.Both);
                    foreach (ClientClass clientClass in _clients)
                    {
                        clientClass.Disconnect();
                    }
                    _clients.Clear(); 
                }
                _listenerSocket?.Close();
                bool isSuccessfulyTerminated = _listenerThread.Join(TERMINATION_TIMEOUT);
                _isRunning = false;
            }
        }
        static public void TryDisconnectClient(ClientClass client)
        {
            if(_clients.Contains(client))
                _clients.Remove(client);
            client.Disconnect();
        }
        static private void ListenForConnections()
        {
            if (_listenerSocket is null)
                Logger.logError("listener Socket is NULL");
            try
            {
                while (_isRunning)
                {
                    _listenerSocket?.Listen(0);
                    Logger.logServerMsg("Listening.....");
                    ClientClass newClient = new ClientClass(_listenerSocket.Accept());
                    _clients.Add(newClient);
                    Logger.logServerMsg("New client from " + (newClient.ClientSocket.RemoteEndPoint as IPEndPoint).Address);
                }
            }
            catch (Exception ex)
            {
                Logger.logServerMsg("WRN!!: " + ex.Message);
            }
        }


        static public string getIp4Address()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }
    }
}
