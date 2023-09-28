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
                new List<(ShortCutTypes.ShortCutBase, ShortCutProfile.GridPos)>
                {
                    (new ShortCutButton(), new ShortCutProfile.GridPos(0,0)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(0,1)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(0,2)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(0,4)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(1,0)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(1,1)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(1,2)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(1,4)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(2,0)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(2,1)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(2,2)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(2,4)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(3,0)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(3,1)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(3,2)),
                    (new ShortCutButton(), new ShortCutProfile.GridPos(3,4))
                }
                );
            _profiles.Add(testProfile);
        }

    }
}
