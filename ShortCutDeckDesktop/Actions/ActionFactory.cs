using ShortCutDeckDesktop.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Actions
{
    public static class ActionFactory
    {
        public const char SPLIT_CHARACTER = '/';
        public const string SCAN_TAG_STRING = "scan";


        public static ActionBase parseAction(string actionString, ClientClass caller)
        {
            return parseAction(actionString.Split(SPLIT_CHARACTER), caller);
        }

        public static ActionBase parseAction(IEnumerable<string> actionStringEnum, ClientClass caller)
        {
            List<string> actionStringList = actionStringEnum.ToList();
            if (actionStringList.Count() < 1)
                return new ActionBase();
            switch (actionStringList[0])
            {
                case SCAN_TAG_STRING:
                    if (actionStringList.Count == 3)
                        return new ActionScanAns(caller, actionStringList[1], actionStringList[2]);
                    break;        
            }

            return new ActionBase();
        }

        public static string ActionToString(ActionBase action)
        {
            string actionString = "";

            switch(action)
            {
                case ActionScanAns actionScanAns:
                    actionString = SCAN_TAG_STRING + SPLIT_CHARACTER + actionScanAns.AnsPassword + SPLIT_CHARACTER + ServerClass.ServerName;
                    break;
            }

            return actionString;
        }
    }
}
