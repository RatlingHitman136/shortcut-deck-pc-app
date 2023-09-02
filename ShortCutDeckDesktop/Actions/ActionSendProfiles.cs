using ShortCutDeckDesktop.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Actions
{
    public class ActionSendProfiles : ActionBase
    {
        private ClientClass _whoRequested;
        private List<int> _profilesIndexesToSend;

        public ActionSendProfiles(ClientClass whoRequested, IEnumerable<int> profileIndexes) {
            _whoRequested = whoRequested;
            _profilesIndexesToSend = profileIndexes.ToList();
        }


        public override void executeAction()
        {
            base.executeAction();
        }
    }
}
