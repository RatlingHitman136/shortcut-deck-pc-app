using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ActionEditors;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutEditors
{
    internal class ShortCutEditorViewModel : ObservableObject
    {
        private ActionBaseEditorViewModel _actionBaseEditorViewModel;

        public ShortCutEditorViewModel(ShortCutBaseDataHolder shortCutDataHolder)
        {
            _actionBaseEditorViewModel = ShortCutEditorViewModelFactory.CreateActionEditorViewModelFromShortCutDataHolder(shortCutDataHolder);
        }

        public ActionBaseEditorViewModel ActionBaseEditorViewModel { get => _actionBaseEditorViewModel; }
    }
}
