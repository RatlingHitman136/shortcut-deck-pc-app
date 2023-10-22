using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels
{
    internal class ProfileMainViewModel:ObservableObject
    {
        private ShortCutProfile _profile;

        public ProfileMainViewModel(ShortCutProfile profile)
        {
            _profile = profile;
        }

        public ShortCutProfile Profile { get => _profile; }
    }
}