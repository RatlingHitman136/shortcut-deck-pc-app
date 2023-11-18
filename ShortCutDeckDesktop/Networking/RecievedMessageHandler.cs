using System;
using System.Text;
using System.Threading;
using ShortCutDeckDesktop.Actions;

namespace ShortCutDeckDesktop.Networking
{
    public class RecievedMessageHandler
    {
        public RecievedMessageHandler()
        { }

        public void handleRecievedMessage(byte[] buffer, int bytesRead, ClientClass whoSent)
        {
            string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            ThreadPool.QueueUserWorkItem(_ => handleRecievedMessage(msg, whoSent));
        }

        private void handleRecievedMessage(string msg, ClientClass whoSent)
        {
            Logger.logServerMsg(msg);
            ActionBase recievedAction = ActionFactory.GetActionFromString(msg, whoSent);
            recievedAction.executeAction();
        }
    }
}
