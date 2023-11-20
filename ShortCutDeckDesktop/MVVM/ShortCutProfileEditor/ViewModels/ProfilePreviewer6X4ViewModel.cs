using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    class ProfilePreviewer6X4ViewModel : ObservableObject
    {
        private ObservableCollection<ShortCutPreviewerBaseViewModel> _shortCutViewModels;

        private ICommand _dragDrop_DropCommand;
        private ICommand _shortCutPreview_SelectedCommand;

        public ProfilePreviewer6X4ViewModel(ProfileEditorModel profileEditorModel, ICommand dragDrop_DropCommand, ICommand shortCutPreview_SelectedCommand)
        {
            _dragDrop_DropCommand = dragDrop_DropCommand;
            _shortCutPreview_SelectedCommand = shortCutPreview_SelectedCommand;
            _shortCutViewModels = profileEditorModel.GetShortCutPreviewerViewModels();
        }

        public ObservableCollection<ShortCutPreviewerBaseViewModel> ShortCutsViewModels
        {
            get => _shortCutViewModels;
        }
        public ICommand DragDrop_DropCommand { get => _dragDrop_DropCommand; }
        public ICommand ShortCutPreview_SelectedCommand { get => _shortCutPreview_SelectedCommand; }


    }
}
