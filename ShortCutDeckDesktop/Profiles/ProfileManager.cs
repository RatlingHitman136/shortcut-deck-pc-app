using Newtonsoft.Json;
using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ShortCutDeckDesktop.Profiles
{
    public delegate void ProfilesListUpdateEventHandler(ProfilesListUpdateEventArgs e);

    public class ProfilesListUpdateEventArgs:EventArgs
    {
        private List<Profile> _newProfilesList;
        public ProfilesListUpdateEventArgs(List<Profile> newProfilesList) => _newProfilesList = newProfilesList;
        public List<Profile> NewProfilesList { get => _newProfilesList; }
    }

    public static class ProfileManager
    {
        #region Private Fields
        private static List<Profile> _profiles = new List<Profile>();

        // TODO values are only for test
        private static int _gridWidth = 4;
        private static int _gridHeight = 6;
        #endregion

        #region Public Properties
        public static List<Profile> Profiles { get => _profiles; }
        public static event ProfilesListUpdateEventHandler profilesListUpdateEvent = delegate { };
        public static int GridWidth { get => _gridWidth; }
        public static int GridHeight { get => _gridHeight; }
        #endregion

        public static bool TryGetProfilesByID(string id, out Profile profile)
        {
            profile = _profiles.Find(x => x.Id == id);
            return profile != null;
        }

        public static bool TryUpdateExistingProfileWithDataHolder(ProfileDataHolder dataHolder)
        {
            if (!_profiles.Exists(x => x.Id == dataHolder.id))
                return false;

            int foundIndex = _profiles.FindIndex(x => x.Id == dataHolder.id);
            if (foundIndex == -1) return false;

            Profile newProfileInstance = new Profile(dataHolder);
            _profiles[foundIndex] = newProfileInstance;

            profilesListUpdateEvent(new ProfilesListUpdateEventArgs(_profiles));
            SaveProfile(dataHolder);
            NotifyAllClientsProfileChanged(newProfileInstance);
            return true;
        }

        private static void NotifyAllClientsProfileChanged(Profile profile)
        {
            foreach (var client in ServerClass.Clients)
            {
                ActionSendProfiles actionSendProfiles = new ActionSendProfiles(client, new List<Profile> { profile });
                actionSendProfiles.ExecuteAction();
            }
        }

        public static void SaveProfile(ProfileDataHolder profileData)
        {
        }


        public static void initTestOneProfile()
        {
            Profile testProfile = new Profile("mainPrf", "Default Profile", 4, 6,
                new List<ShortCutBase>
                {
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_VOLUME_UP), 0, 0),
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_MEDIA_PLAY_PAUSE), 1, 0),
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_VOLUME_MUTE), 2, 0),
                                new ShortCutButton(new ActionPCVirtualKeyPress(VirtualKeysConstants.VK_VOLUME_DOWN), 3, 0),
                }
                );
            _profiles.Add(testProfile);
            profilesListUpdateEvent(new ProfilesListUpdateEventArgs(_profiles));
        }
    }
}
