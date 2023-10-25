using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    class ProfilePreviewerViewModel : ObservableObject
    {
        private ObservableCollection<object> _shortCuts;

        public ProfilePreviewerViewModel()
        {
            _shortCuts = new() { 1, 2 };
        }
        public ObservableCollection<object> ShortCuts { get => _shortCuts; }
    }
}
