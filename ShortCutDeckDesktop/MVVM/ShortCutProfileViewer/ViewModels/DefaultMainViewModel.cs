using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels.SideLister;
using ShortCutDeckDesktop.MVVM.ViewModels;
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
            ShortCutProfileManager.profilesListUpdateEvent += UpdateProfilesSmallViewModelList;
            UpdateProfilesSmallViewModelList(new(ShortCutProfileManager.Profiles));
            OnPropertyChanged();
        }

        public ObservableCollection<ProfileSmallViewModel> ProfilesSmallViewModels { 
            get => _profilesSmallViewModels;
        }

        private void UpdateProfilesSmallViewModelList(ShortCutProfilesListUpdateEventArgs e)
        {
            _profilesSmallViewModels.Clear();
            foreach (var profile in e.NewProfilesList)
            {
                ICommand command = new RelayCommand<ShortCutProfile>(_ => { ProfileFromListerSelected(profile); });
                _profilesSmallViewModels.Add(new ProfileSmallViewModel(profile, command));
            }
            OnPropertyChanged();
        }

        private void ProfileFromListerSelected(ShortCutProfile shortCutProfile)
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
