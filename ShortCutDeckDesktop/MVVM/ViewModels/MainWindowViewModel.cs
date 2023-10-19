using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        #region constructor
        public MainWindowViewModel()
        {
            AllProfilesListerViewModel = new AllProfilesListerViewModel();
            CurrentProfileViewerViewModel = AllProfilesListerViewModel;
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

        public AllProfilesListerViewModel AllProfilesListerViewModel { get; set; }


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
        #endregion

    }
}
