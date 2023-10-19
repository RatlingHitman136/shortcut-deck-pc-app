using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class AllProfilesListerViewModel : ObservableObject
    {
        public AllProfilesListerViewModel()
        {
            ShortCutProfileManager.ProfilesListUpdateEvent += OnShortCutProfileListUpdated;
            _shortCutProfilesViewModelList = new();
            UpdateProfilesViewModelList(ShortCutProfileManager.Profiles);
            OnPropertyChanged();
        }

        private ObservableCollection<SmallProfileViewModel> _shortCutProfilesViewModelList;
        public ObservableCollection<SmallProfileViewModel> ShortCutProfilesViewModelList { get => _shortCutProfilesViewModelList; }

        public void OnShortCutProfileListUpdated(ShortCutProfilesListUpdateEventArgs e)
        {
            UpdateProfilesViewModelList(e.NewProfilesList);
        }

        private void UpdateProfilesViewModelList(List<ShortCutProfile> shortCutProfiles)
        {
            _shortCutProfilesViewModelList.Clear();
            foreach (var profile in shortCutProfiles)
            {
                _shortCutProfilesViewModelList.Add(new SmallProfileViewModel(profile));
            }

            OnPropertyChanged();
        }
    } 
}
