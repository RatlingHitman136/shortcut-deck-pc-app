using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    class ProfilePreviewerViewModel : ObservableObject
    {
        private ObservableCollection<object> _nodes;

        public ProfilePreviewerViewModel()
        {
            _nodes = new() { 1 };
        }

        public ObservableCollection<object> Nodes { get => _nodes; }
    }
}
