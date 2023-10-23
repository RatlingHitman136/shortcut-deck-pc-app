using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal class ShortCutProfileEditorViewModel:ObservableObject
    {
        private ICommand _resizeCommand;

        public ShortCutProfileEditorViewModel()
        {
            _resizeCommand = new RelayCommand(OnEditorResized);
        }

        public ICommand ResizeCommand { get => _resizeCommand; }

        public void OnEditorResized()
        {
            throw new Exception();
        }
    }
}
