using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.ShortCuts;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        #region constructor
        public MainWindowViewModel()
        {
            AllProfilesListerViewModel = new HomeProfileListerViewModel(this);
            CurrentProfileViewerViewModel = AllProfilesListerViewModel;

            _profileListerSideBarViewModels = new()
            {
                new DefaultProfileListerSideBarViewModel()
            };
        }
        #endregion

        #region Server Log fields and Properties
        public ObservableCollection<string> LogsList { get => Logger.LogsList; }

        private ICommand? _clearLogsList;
        public ICommand ClearLogsList
        {
            get
            {
                if (_clearLogsList == null)
                    _clearLogsList = new RelayCommand(Logger.clearLog);

                return _clearLogsList;
            }
        }
        #endregion

        #region Profile lister and viewer 

        public HomeProfileListerViewModel AllProfilesListerViewModel { get; set; }

        private object _currentProfileViewerViewModel;
        public object CurrentProfileViewerViewModel
        {
            get => _currentProfileViewerViewModel;
            set 
            {
                _currentProfileViewerViewModel = value;
                OnPropertyChanged("CurrentProfileViewerViewModel");
            }
        }
        public void SelectedProfileFromHomeProfileLister(ShortCutProfile selectedProfile)
        {
            if (IsProfileAlreadyOpened(selectedProfile, out SpecificProfileListerSideBarViewModel foundedViewModel))
            {
                
            }
            else
            {
                _profileListerSideBarViewModels.Add(new SpecificProfileListerSideBarViewModel(selectedProfile));
                OnPropertyChanged();
            }

        }
        #endregion

        #region Profile lister side bar
        private ObservableCollection<DefaultProfileListerSideBarViewModel> _profileListerSideBarViewModels;
        public ObservableCollection<DefaultProfileListerSideBarViewModel> ProfileListerSideBarViewModels { get => _profileListerSideBarViewModels; }
        public bool IsProfileAlreadyOpened(ShortCutProfile profileToCheck, out SpecificProfileListerSideBarViewModel foundedViewModel)
        {
            foreach (var profileViewModel in _profileListerSideBarViewModels)
            {
                if (profileViewModel is SpecificProfileListerSideBarViewModel)
                    if (((SpecificProfileListerSideBarViewModel)profileViewModel).CorrespondedShortCutProfile == profileToCheck)
                    {
                        foundedViewModel = (SpecificProfileListerSideBarViewModel)profileViewModel;
                        return true;
                    }
            }
            foundedViewModel = null;
            return false;
        }
        #endregion

    }
}
