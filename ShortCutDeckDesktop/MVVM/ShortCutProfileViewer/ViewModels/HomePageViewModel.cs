using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    internal class HomePageViewModel:ObservableObject
    {
        private ObservableCollection<ProfileSmallViewModel> _profilesSmallViewModelList;
        private ShortCutProfilesViewerViewModel _profilesViewerViewModel;

        public HomePageViewModel(ShortCutProfilesViewerViewModel shortCutProfileViewerViewModel)
        {
            _profilesSmallViewModelList = new();
            _profilesViewerViewModel = shortCutProfileViewerViewModel;
            ShortCutProfileManager.ProfilesListUpdateEvent += UpdateProfilesSmallViewModelList;
            UpdateProfilesSmallViewModelList(new(ShortCutProfileManager.Profiles));
            OnPropertyChanged();
        }

        public ObservableCollection<ProfileSmallViewModel> ProfilesSmallViewModelList { 
            get => _profilesSmallViewModelList;
        }

        private void UpdateProfilesSmallViewModelList(ShortCutProfilesListUpdateEventArgs e)
        {
            _profilesSmallViewModelList.Clear();
            foreach (var profile in e.NewProfilesList)
            {
                ICommand command = new RelayCommand<ShortCutProfile>(_ => { ProfileFromListerSelected(profile); });
                _profilesSmallViewModelList.Add(new ProfileSmallViewModel(profile, command));
            }
            OnPropertyChanged();
        }

        private void ProfileFromListerSelected(ShortCutProfile shortCutProfile)
        {
            /*
            SpecificProfileListerSideBarViewModel selectedSideBarViewModel;
            if (_profilesViewerViewModel.IsProfileAlreadyOpened(shortCutProfile, out SpecificProfileListerSideBarViewModel foundedViewModel))
            {
                selectedSideBarViewModel = foundedViewModel;
            }
            else
            {
                selectedSideBarViewModel = new SpecificProfileListerSideBarViewModel(shortCutProfile, _mainWindowViewModel);
                _profilesViewerViewModel.ProfileListerSideBarViewModels.Add(selectedSideBarViewModel);
            }

            _profilesViewerViewModel.SelectedViewModelSideBar = selectedSideBarViewModel;
            */
        }
    }
}
