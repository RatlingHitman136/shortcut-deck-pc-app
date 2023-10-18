using ShortCutDeckDesktop.ViewModels.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        public ObservableCollection<string> LogsList { get => Logger.LogsList; }

        private ICommand _clearLogsList;
        public ICommand ClearLogsList 
        {
            get
            {
                if(_clearLogsList == null)
                    _clearLogsList = new RelayCommand(_ => Logger.clearLog());

                return _clearLogsList;
            }
        } 
    }
}
    