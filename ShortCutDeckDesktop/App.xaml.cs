﻿using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
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
        App()
        {
            ServerClass.startServer();
            ShortCutProfileManager.initTestOneProfile();//TODO(test stuff)
        }
    }
}