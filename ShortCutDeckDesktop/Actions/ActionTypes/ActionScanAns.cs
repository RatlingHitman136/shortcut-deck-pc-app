using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ShortCutDeckDesktop.Actions.ActionTypes
{
    public class ActionScanAns : ActionBase
    {
        private string _password;
        private string _ansPassword;
        private string _deviceName;
        private ClientClass _clientWhoRequested;

        public string AnsPassword { get => _ansPassword; }

        public ActionScanAns(ClientClass whoRequested, string password, string deviceName = "new Device") : base()
        {
            _password = password;
            _ansPassword = ReverseString(password);
            _deviceName = deviceName;
            _clientWhoRequested = whoRequested;
        }

        public override void ExecuteAction()
        {
            base.ExecuteAction();
            string toSend = StringConstants.ACTION_SCAN_TAG
                        + StringConstants.FIRST_LEVEL_SPLIT_CHARACTER
                        + AnsPassword
                        + StringConstants.FIRST_LEVEL_SPLIT_CHARACTER
                        + ServerClass.ServerName;
            Logger.logServerMsg("sent back: " + toSend);
            _clientWhoRequested.SendMessage(toSend);
        }

        private static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
