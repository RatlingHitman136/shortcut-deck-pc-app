using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShortCutDeckDesktop
{
    public static class Logger
    {
        private static ObservableCollection<string> _logsList = new ObservableCollection<string>();

        public static ObservableCollection<string> LogsList { get => _logsList; set => _logsList = value; }

        public static void logError(string msg)
        {
            throw new Exception(msg);
        }

        public static void logWarning(string msg)
        {
            throw new WarningException(msg);
        }

        public static void logServerMsg(string msg)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => { _logsList.Add(msg); }), System.Windows.Threading.DispatcherPriority.Render);
        }
        public static void clearLog() {
            _logsList.Clear();
        }
    }
}
