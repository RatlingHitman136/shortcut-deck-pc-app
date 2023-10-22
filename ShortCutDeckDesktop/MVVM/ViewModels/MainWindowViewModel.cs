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
using ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels;
using ShortCutDeckDesktop.ShortCuts;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        #region constructor
        public MainWindowViewModel()
        {
            _profilesViewer = new ShortCutProfilesViewerViewModel();
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

        private ShortCutProfilesViewerViewModel _profilesViewer;
        public ShortCutProfilesViewerViewModel ProfilesViewer { get => _profilesViewer; }

    }
}
