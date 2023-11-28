using ShortCutDeckDesktop.DataLoaders;
using ShortCutDeckDesktop.MVVM.ViewModels;
using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShortCutDeckDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServerClass.StartServer();
            ShortCutProfileManager.InitProfiles();
            PCVirtualKeyDefaultOptionsLoader.LoadData();
        }
    }
}