using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Actions.ActionTypes
{
    public class ActionSendProfiles : ActionBase
    {
        private ClientClass _whoRequested;
        private List<int> _profilesIndexesToSend;
        private List<(string, string)> _profileContextsToSend;

        public ActionSendProfiles(ClientClass whoRequested, List<ShortCutProfile> profiles)
        {
            _whoRequested = whoRequested;
            _profileContextsToSend = new List<(string, string)>();

            foreach (var profile in profiles)
            {
                _profileContextsToSend.Add((ShortCutProfileConverter.parseProfileToString(profile), profile.Id));
            }
        }

        public ActionSendProfiles(ClientClass whoRequested)
        {
            _whoRequested = whoRequested;
            _profilesIndexesToSend = new List<int>();
            _profileContextsToSend = new List<(string, string)>();

            for (int i = 0; i < ShortCutProfileManager.Profiles.Count; i++)
                _profilesIndexesToSend.Add(i);

            foreach (var index in _profilesIndexesToSend)
            {
                _profileContextsToSend.Add((ShortCutProfileConverter.parseProfileToString(ShortCutProfileManager.Profiles[index]), ShortCutProfileManager.Profiles[index].Id));
            }
        }


        public override void executeAction()
        {
            base.executeAction();
            foreach ((string, string) context in _profileContextsToSend)
            {
                string toSend = StringConstants.ACTION_SEND_PROFILE_TAG
                    + StringConstants.FIRST_LEVEL_SPLIT_CHARACTER
                    + context.Item2
                    + StringConstants.FIRST_LEVEL_SPLIT_CHARACTER
                    + context.Item1;

                Logger.logServerMsg("sent Prof: " + toSend);
                _whoRequested.sendMessage(toSend);
            }
        }
    }
}
