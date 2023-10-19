using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class HomeProfileListerViewModel : ObservableObject
    {
        public HomeProfileListerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            ShortCutProfileManager.ProfilesListUpdateEvent += OnShortCutProfileListUpdated;
            _shortCutProfilesViewModelList = new();
            UpdateProfilesViewModelList(ShortCutProfileManager.Profiles);
            OnPropertyChanged();
        }

        private MainWindowViewModel _mainWindowViewModel;
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
                ICommand command = new RelayCommand<ShortCutProfile>(_ => { ProfileFromListerSelected(profile); });
                _shortCutProfilesViewModelList.Add(new SmallProfileViewModel(profile, command));
            }

            OnPropertyChanged();
        }

        private void ProfileFromListerSelected(ShortCutProfile shortCutProfile)
        {
            SpecificProfileListerSideBarViewModel selectedSideBarViewModel;
            if (_mainWindowViewModel.IsProfileAlreadyOpened(shortCutProfile, out SpecificProfileListerSideBarViewModel foundedViewModel))
            {
                selectedSideBarViewModel = foundedViewModel;
            }
            else
            {
                selectedSideBarViewModel = new SpecificProfileListerSideBarViewModel(shortCutProfile, _mainWindowViewModel);
                _mainWindowViewModel.ProfileListerSideBarViewModels.Add(selectedSideBarViewModel);
            }

            selectedSideBarViewModel.SelectThisView();
        }
    } 
}
