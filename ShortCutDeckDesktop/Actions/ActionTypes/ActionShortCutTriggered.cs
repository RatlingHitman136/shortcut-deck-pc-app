using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShortCutDeckDesktop.ShortCuts.ShortCutProfile;

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
            ShortCutProfile profile;
            if(ShortCutProfileManager.TryGetProfilesWithID(_profileID, out profile))
            {
                (int x, int y, List<string> additionData) = ShortCutProfileConverter.ParseDataFromTriggeredShortCut(_msg);
                ShortCutBase shortCut;
                if(profile.TryGetShortCutByGridPos(x, y, out shortCut))
                {
                    shortCut.ShortCutTriggered(additionData);
                }
            }
        }
    }
}
