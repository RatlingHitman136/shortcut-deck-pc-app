using Newtonsoft.Json;
using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.DataLoaders;
using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ShortCutDeckDesktop.ShortCuts
{
    public delegate void ShortCutProfilesListUpdateEventHandler(ShortCutProfilesListUpdateEventArgs e);

    public class ShortCutProfilesListUpdateEventArgs : EventArgs
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
        public static event ShortCutProfilesListUpdateEventHandler profilesListUpdateEvent = delegate { };
        public static int GridWidth { get => _gridWidth; }
        public static int GridHeight { get => _gridHeight; }
        #endregion

        public static bool TryGetProfilesByID(string id, out ShortCutProfile profile)
        {
            profile = _profiles.Find(x => x.Id == id);
            return profile != null;
        }

        public static bool TryUpdateExistingProfileWithDataHolder(ShortCutProfileDataHolder dataHolder)
        {
            if (!_profiles.Exists(x => x.Id == dataHolder.id))
                return false;

            int foundIndex = _profiles.FindIndex(x => x.Id == dataHolder.id);
            if (foundIndex == -1) return false;

            ShortCutProfile newProfileInstance = new ShortCutProfile(dataHolder);
            _profiles[foundIndex] = newProfileInstance;

            profilesListUpdateEvent(new ShortCutProfilesListUpdateEventArgs(_profiles));
            ProfileJsonLoader.SaveProfile(dataHolder);
            NotifyAllClientsProfileChanged(newProfileInstance);
            return true;
        }

        public static void InitProfiles()
        {
            List<ShortCutProfile> loadedProfiles = ProfileJsonLoader.LoadAllProfiles();
            if (loadedProfiles.Count() == 0)
            {
                InitDefaultProfile();
                return;
            }
            _profiles = loadedProfiles;
            profilesListUpdateEvent(new ShortCutProfilesListUpdateEventArgs(_profiles));
        }

        private static void NotifyAllClientsProfileChanged(ShortCutProfile profile)
        {
            foreach (var client in ServerClass.Clients)
            {
                ActionSendProfiles actionSendProfiles = new ActionSendProfiles(client, new List<ShortCutProfile> { profile });
                actionSendProfiles.ExecuteAction();
            }
        }

        public static void InitDefaultProfile()
        {
            ShortCutProfile testProfile = new ShortCutProfile("defPrf", "Default Profile", 4, 6,
                new List<ShortCutBase>
                {
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_VOLUME_UP), 0, 0),
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_MEDIA_PLAY_PAUSE), 1, 0),
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_VOLUME_MUTE), 2, 0),
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_VOLUME_DOWN), 3, 0),
                }
                );
            _profiles = new List<ShortCutProfile> { testProfile };
            ProfileJsonLoader.SaveProfile(testProfile);
            profilesListUpdateEvent(new ShortCutProfilesListUpdateEventArgs(_profiles));
        }
    }
}
