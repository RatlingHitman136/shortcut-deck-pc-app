using ShortCutDeckDesktop.Actions.ActionTypes.ShortCutActions;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public static class ShortCutProfileManager
    {
        private static List<ShortCutProfile> _profiles = new List<ShortCutProfile>();

        // TODO values are only for test
        private static int _gridWidth = 4; 
        private static int _gridHeight = 6;

        public static List<ShortCutProfile> Profiles { get => _profiles; }
        public static int GridWidth { get => _gridWidth; }
        public static int GridHeight { get => _gridHeight; }

        public static bool TryGetProfilesWithIDs(string id, out ShortCutProfile profile)
        {
            profile = _profiles.Find(x => x.Id == id);
            return profile != null;
        }

        public static void initTestOneProfile() { 
            ShortCutProfile testProfile = new ShortCutProfile("mainPrf",
                new List<(ShortCutBase, ShortCutProfile.GridPos)>
                {
                    (new ShortCutButton(new ActionPCVolumeUp()), new ShortCutProfile.GridPos(0,0)),
                    (new ShortCutButton(new ActionPCMediaPausePlay()), new ShortCutProfile.GridPos(1,0)),
                    (new ShortCutButton(new ActionPCVolumeMute()), new ShortCutProfile.GridPos(2,0)),
                    (new ShortCutButton(new ActionPCVolumeDown()), new ShortCutProfile.GridPos(3,0)),
                }
                );
            _profiles.Add(testProfile);
        }

    }
}
