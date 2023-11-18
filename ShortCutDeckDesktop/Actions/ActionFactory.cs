using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
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
        public static ActionBase createActionFromString(string actionString, ClientClass caller)
        {
            return createActionFromString(actionString.Split(StringConstants.FIRST_LEVEL_SPLIT_CHARACTER), caller);
        }

        private static ActionBase createActionFromString(IEnumerable<string> actionStringEnum, ClientClass caller)
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

                case StringConstants.ACTION_SHORTCUT_TRIGGERED:
                    if (actionStringList.Count == 3)
                        return new ActionShortCutTriggered(caller, actionStringList[1], actionStringList[2]);
                    break;
            }

            return new ActionBase();
        }

        public static ActionBase createActionFromDataHolder(ActionBaseDataHolder dataHolder)
        {
            switch (dataHolder)
            {
                case ActionPCVirtualKeyPressedDataHolder convertedDataHolder:
                    return new ActionPCVirtualKeyPress(convertedDataHolder);

                default:
                    throw new NotImplementedException("ActionFactory for " + dataHolder.ToString() + " is not implemented yet!");
            }
        }
    }
}
