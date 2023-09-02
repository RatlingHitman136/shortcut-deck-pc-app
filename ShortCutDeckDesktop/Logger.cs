using System;
using System.Collections.Generic;
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
        private static TextBlock? serverLog = null;


        public static void setServerLogField(TextBlock serverLogField)
        {
            serverLog = serverLogField;
        }

        public static void logError(String msg)
        {
            throw new Exception(msg);
        }

        public static void logWarning(String msg)
        {
            throw new WarningException(msg);
        }

        public static void logServerMsg(String msg)
        {
            serverLog?.Dispatcher.Invoke(delegate
            {
                if (serverLog is not null)
                    serverLog.Text += msg + "\n";
                else
                    throw new WarningException("No Logging field is specified");
            }, System.Windows.Threading.DispatcherPriority.Render);
        }
    }
}
