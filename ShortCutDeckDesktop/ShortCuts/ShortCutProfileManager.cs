using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ShortCutDeckDesktop.ShortCuts
{
    public delegate void ShortCutProfilesListUpdateEventHandler(ShortCutProfilesListUpdateEventArgs e);

    public class ShortCutProfilesListUpdateEventArgs:EventArgs
    {
        private List<ShortCutProfile> _newProfilesList;
        public ShortCutProfilesListUpdateEventArgs(List<ShortCutProfile> newProfilesList) => _newProfilesList = newProfilesList;
        public List<ShortCutProfile> NewProfilesList { get => _newProfilesList; }
    }

    public static class ShortCutProfileManager
    {
        #region Private Fields
        private static List<ShortCutProfile> _profiles = new List<ShortCutProfile>();

        // TODO values are only for test
        private static int _gridWidth = 4; 
        private static int _gridHeight = 6;
        #endregion

        #region Public Properties
        public static List<ShortCutProfile> Profiles { get => _profiles; }
        public static event ShortCutProfilesListUpdateEventHandler ProfilesListUpdateEvent = delegate { };
        public static int GridWidth { get => _gridWidth; }
        public static int GridHeight { get => _gridHeight; }
        #endregion

        public static bool TryGetProfilesWithIDs(string id, out ShortCutProfile profile)
        {
            profile = _profiles.Find(x => x.Id == id);
            return profile != null;
        }
        public static void initTestOneProfile() { 
            ShortCutProfile testProfile = new ShortCutProfile("mainPrf", "Default Profile",
                new List<(ShortCutBase, ShortCutProfile.GridPos)>
                {
                    (new ShortCutButton(new ActionPCVirtualKeyPressed(VirtualKeysConstants.VK_VOLUME_UP)), new ShortCutProfile.GridPos(0,0)),
                    (new ShortCutButton(new ActionPCVirtualKeyPressed(VirtualKeysConstants.VK_MEDIA_PLAY_PAUSE)), new ShortCutProfile.GridPos(1,0)),
                    (new ShortCutButton(new ActionPCVirtualKeyPressed(VirtualKeysConstants.VK_VOLUME_MUTE)), new ShortCutProfile.GridPos(2,0)),
                    (new ShortCutButton(new ActionPCVirtualKeyPressed(VirtualKeysConstants.VK_VOLUME_DOWN)), new ShortCutProfile.GridPos(3,0)),
                }
                );
            _profiles.Add(testProfile);

            ProfilesListUpdateEvent(new ShortCutProfilesListUpdateEventArgs(_profiles));
        }
    }
}
