using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels;
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
        private ShortCutProfileEditorViewModel _profileEditor;

        public ProfileMainViewModel(ShortCutProfile profile)
        {
            _profile = profile;
            _profileEditor = new ShortCutProfileEditorViewModel(profile);
            OnPropertyChanged();
        }

        public ShortCutProfile Profile { get => _profile; }
        public ShortCutProfileEditorViewModel ProfileEditor { get => _profileEditor; }
    }
}