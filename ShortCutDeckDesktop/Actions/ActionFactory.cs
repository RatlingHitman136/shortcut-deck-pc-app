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

        #region consts
        public const char SPLIT_CHARACTER = '/';
        public const string SCAN_TAG_STRING = "scan";
        public const string SEND_TAG_STRING = "send";
        public const string SEND_ALL_PROFILES_TAG_STRING = "allProf";
        public const string SEND_SPECIFIC_PROFILES_TAG_STRING = "specProf";
        public const char PROFILES_SPLIT_CHARACTER = ' ';
        #endregion


        public static ActionBase parseAction(string actionString, ClientClass caller)
        {
            return ActionFromString(actionString.Split(SPLIT_CHARACTER), caller);
        }

        private static ActionBase ActionFromString(IEnumerable<string> actionStringEnum, ClientClass caller)
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
                case SEND_ALL_PROFILES_TAG_STRING:
                    if (actionStringList.Count == 2 && actionStringList[1] == SEND_ALL_PROFILES_TAG_STRING)
                        return new ActionSendProfiles(caller, new List<int>());
                    else if(actionStringList.Count == 3 && actionStringList[1] == SEND_SPECIFIC_PROFILES_TAG_STRING)
                    {
                        List<int> profiles = actionStringList[2].Trim().Split(PROFILES_SPLIT_CHARACTER).Select(indexString => Convert.ToInt32(indexString)).ToList();
                        return new ActionSendProfiles(caller, profiles);
                    }
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
