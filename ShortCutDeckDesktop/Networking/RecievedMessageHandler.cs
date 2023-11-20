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

        public void HandleRecievedMessage(byte[] buffer, int bytesRead, ClientClass whoSent)
        {
            string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            ThreadPool.QueueUserWorkItem(_ => HandleRecievedMessage(msg, whoSent));
        }

        private void HandleRecievedMessage(string msg, ClientClass whoSent)
        {
            Logger.logServerMsg(msg);
            ActionBase recievedAction = ActionFactory.CreateActionFromString(msg, whoSent);
            recievedAction.ExecuteAction();
        }
    }
}
