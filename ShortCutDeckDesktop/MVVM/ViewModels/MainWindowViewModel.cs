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
            _homeProfileListerViewModel = new HomeProfileListerViewModel(this);
            CurrentProfileViewerViewModel = _homeProfileListerViewModel;
            _defaultProfileListerSideBarViewModel = new DefaultProfileListerSideBarViewModel();
            _profileListerSideBarViewModels = new()
            {
                _defaultProfileListerSideBarViewModel
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

        private HomeProfileListerViewModel _homeProfileListerViewModel;
        private object _selectedViewModelSideBar;
        public object SelectedViewModelSideBar
        {
            get => _selectedViewModelSideBar;
            set
            {
                _selectedViewModelSideBar = value;
                if (_selectedViewModelSideBar is SpecificProfileListerSideBarViewModel)
                    CurrentProfileViewerViewModel = ((SpecificProfileListerSideBarViewModel)_selectedViewModelSideBar).BigProfileViewModel;
                else if (_selectedViewModelSideBar is DefaultProfileListerSideBarViewModel)
                    CurrentProfileViewerViewModel = _homeProfileListerViewModel;
                OnPropertyChanged(nameof(SelectedViewModelSideBar));
            }
        }
        private object _currentProfileViewerViewModel;
        public object CurrentProfileViewerViewModel
        {
            get => _currentProfileViewerViewModel;
            set 
            {
                _currentProfileViewerViewModel = value;
                OnPropertyChanged(nameof(CurrentProfileViewerViewModel));
            }
        }
        #endregion

        #region Profile lister side bar
        private DefaultProfileListerSideBarViewModel _defaultProfileListerSideBarViewModel;
        private ObservableCollection<object> _profileListerSideBarViewModels;
        public ObservableCollection<object> ProfileListerSideBarViewModels { get => _profileListerSideBarViewModels; }
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
        public void TryCloseProfileListerSideBarElement(SpecificProfileListerSideBarViewModel viewModelToClose)
        {
            if (_profileListerSideBarViewModels.Contains(viewModelToClose))
            {
                SelectedViewModelSideBar = _defaultProfileListerSideBarViewModel;
                _profileListerSideBarViewModels.Remove(viewModelToClose);
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
