using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels.SideLister;
using ShortCutDeckDesktop.MVVM.ViewModels;
using ShortCutDeckDesktop.Profiles;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels
{
    internal class DefaultMainViewModel:ObservableObject
    {
        private ObservableCollection<ProfileSmallViewModel> _profilesSmallViewModels;
        private ShortCutProfilesViewerViewModel _profilesViewerViewModel;

        public DefaultMainViewModel(ShortCutProfilesViewerViewModel shortCutProfileViewerViewModel)
        {
            _profilesSmallViewModels = new();
            _profilesViewerViewModel = shortCutProfileViewerViewModel;
            ProfileManager.profilesListUpdateEvent += UpdateProfilesSmallViewModelList;
            UpdateProfilesSmallViewModelList(new(ProfileManager.Profiles));
            OnPropertyChanged();
        }

        public ObservableCollection<ProfileSmallViewModel> ProfilesSmallViewModels { 
            get => _profilesSmallViewModels;
        }

        private void UpdateProfilesSmallViewModelList(ProfilesListUpdateEventArgs e)
        {
            _profilesSmallViewModels.Clear();
            foreach (var profile in e.NewProfilesList)
            {
                ICommand command = new RelayCommand<Profile>(_ => { ProfileFromListerSelected(profile); });
                _profilesSmallViewModels.Add(new ProfileSmallViewModel(profile, command));
            }
            OnPropertyChanged();
        }

        private void ProfileFromListerSelected(Profile shortCutProfile)
        {
            ProfileItemViewModel selectedSideBarViewModel;

            ProfileItemViewModel profileItemViewModel;
            if (_profilesViewerViewModel.IsProfileOpened(shortCutProfile, out ProfileItemViewModel foundedViewModel))
            {
                selectedSideBarViewModel = foundedViewModel;
            }
            else
            {
                ProfileMainViewModel profileMainViewModel = new ProfileMainViewModel(shortCutProfile);
                selectedSideBarViewModel = new ProfileItemViewModel(_profilesViewerViewModel, profileMainViewModel);
                _profilesViewerViewModel.SideListerViewModels.Add(selectedSideBarViewModel);
            }

            _profilesViewerViewModel.SelectedProfileListerViewModel = selectedSideBarViewModel;
        }
    }
}
