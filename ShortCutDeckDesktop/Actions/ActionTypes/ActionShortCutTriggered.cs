using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortCutDeckDesktop.Profiles;

namespace ShortCutDeckDesktop.Actions.ActionTypes
{
    public class ActionShortCutTriggered : ActionBase
    {
        private string _profileID;
        private string _msg;
        public ActionShortCutTriggered(ClientClass whoSend, string profileID, string msg)
        {
            _profileID = profileID;
            _msg = msg;
        }

        public override void ExecuteAction()
        {
            base.ExecuteAction();
            Profile profile;
            if(ProfileManager.TryGetProfilesByID(_profileID, out profile))
            {
                (int x, int y, List<string> additionData) = ProfileStringConverter.ParseDataFromTriggeredShortCut(_msg);
                ShortCutBase shortCut;
                if(profile.TryGetShortCutByGridPos(x, y, out shortCut))
                {
                    shortCut.ShortCutTriggered(additionData);
                }
            }
        }
    }
}
