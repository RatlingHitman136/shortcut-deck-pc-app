using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShortCutDeckDesktop.Actions;

namespace ShortCutDeckDesktop.Networking
{
    public class RecievedMessageHandler
    {
        public RecievedMessageHandler()
        { }

        public void handleRecievedMessage(byte[] buffer, int bytesRead, ClientClass whoSent)
        {
            String msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            ThreadPool.QueueUserWorkItem(_ => handleRecievedMessage(msg, whoSent));
        }

        private void handleRecievedMessage(string msg, ClientClass whoSent)
        {
            Logger.logServerMsg(msg);
            ActionBase recievedAction = ActionFactory.parseAction(msg, whoSent);
            recievedAction.executeAction();
        }
    }
}
