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
        private ProfileEditorModel _profilePreviewerEditorModel;

        private ICommand _dragDrop_DropCommand;
        private ICommand _shortCutPreview_SelectedCommand;

        public ProfilePreviewer6X4ViewModel(ProfileEditorModel profileEditorModel)
        {
            _profilePreviewerEditorModel = profileEditorModel;
            _dragDrop_DropCommand = new RelayCommand<object?>(param => OnShortCutDropped(param));
            _shortCutPreview_SelectedCommand = new RelayCommand<object?>(param => OnShortCutSelected(param));
        }

        public ObservableCollection<ShortCutPreviewerBaseViewModel> ShortCutsViewModels
        {
            get => _profilePreviewerEditorModel.ShortCutViewModels;
        }
        public ICommand DragDrop_DropCommand { get => _dragDrop_DropCommand; }
        public ICommand ShortCutPreview_SelectedCommand { get => _shortCutPreview_SelectedCommand; }

        private void OnShortCutDropped(object? param)
        {
            if (param is not (ShortCutPreviewerBaseViewModel, int, int))
                return;

            var converted = ((object, int, int))param;
            ShortCutPreviewerBaseViewModel viewModel = (ShortCutPreviewerBaseViewModel)converted.Item1;
            int newPos_X = converted.Item2;
            int newPos_Y = converted.Item3;


            _profilePreviewerEditorModel.TryChangeShortCutViewModelPositionInGrid(newPos_X, newPos_Y, viewModel);
        }

        private void OnShortCutSelected(object? param)
        {
            if (param is not (MouseButtonEventArgs, int, int))
                return;

            var convertedParams = ((MouseButtonEventArgs, int, int))param;
            _profilePreviewerEditorModel.TrySelectShortCutPreviewerFromPositionInGrid(convertedParams.Item2, convertedParams.Item3);
        }
    }
}
