using ShortCutDeckDesktop.Actions.ActionTypes;
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
        public static ActionBase GetActionFromStringFromClient(string actionString, ClientClass caller)
        {
            return GetActionFromStringFromClient(actionString.Split(StringConstants.FIRST_LEVEL_SPLIT_CHARACTER), caller);
        }

        private static ActionBase GetActionFromStringFromClient(IEnumerable<string> actionStringEnum, ClientClass caller)
        {
            List<string> actionStringList = actionStringEnum.ToList();
            if (actionStringList.Count() < 1)
                return new ActionBase();
            switch (actionStringList[0])
            {
                case StringConstants.ACTION_SCAN_TAG:
                    if (actionStringList.Count == 3)
                        return new ActionScanAns(caller, actionStringList[1], actionStringList[2]);
                    break;

                case StringConstants.ACTION_REQUEST_ALL_PROFILES_TAG:
                    return new ActionSendProfiles(caller);
            }

            return new ActionBase();
        }
    }
}
