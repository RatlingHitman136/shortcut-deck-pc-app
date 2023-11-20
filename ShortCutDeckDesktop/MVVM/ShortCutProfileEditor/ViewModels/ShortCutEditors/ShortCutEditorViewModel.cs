using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ActionEditors;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutEditors
{
    internal class ShortCutEditorViewModel : ObservableObject
    {
        private ActionBaseEditorViewModel _actionBaseEditorViewModel;

        public ShortCutEditorViewModel(ShortCutBaseDataHolder shortCutDataHolder)
        {
            _actionBaseEditorViewModel = ShortCutPreviewViewModelFactory.CreateActionEditorViewModelFromShortCutDataHolder(shortCutDataHolder);
        }

        public ActionBaseEditorViewModel ActionBaseEditorViewModel { get => _actionBaseEditorViewModel; }
    }
}
