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
        private ProfileEditorViewModel _profileEditor;

        public ProfileMainViewModel(ShortCutProfile profile)
        {
            _profile = profile;
            _profileEditor = new ProfileEditorViewModel(profile);
            OnPropertyChanged();
        }

        public ShortCutProfile Profile { get => _profile; }
        public ProfileEditorViewModel ProfileEditor { get => _profileEditor; }
    }
}