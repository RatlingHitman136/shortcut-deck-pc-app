using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCuts;
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
        private ProfileEditorModel _profilePrevewerEditorModel;
        private ICommand _dragDrop_DropCommand;

        public ProfilePreviewer6X4ViewModel()
        {
            _profilePrevewerEditorModel = new ProfileEditorModel(4,6);
            _profilePrevewerEditorModel.ShortCutViewModels.Add(new ShortCutButtonViewModel(1,2));
            _profilePrevewerEditorModel.ShortCutViewModels.Add(new ShortCutButtonViewModel(3,2));

            _dragDrop_DropCommand = new RelayCommand<object?>(param => OnShortCutDropped(param));
        }

        public ObservableCollection<ShortCutBaseViewModel> ShortCutsViewModels
        {
            get => _profilePrevewerEditorModel.ShortCutViewModels;
        }
        public ICommand DragDrop_DropCommand { get => _dragDrop_DropCommand; }

        private void OnShortCutDropped(object? param)
        {
            if (param is not (ShortCutBaseViewModel, int, int))
                return;

            var converted = ((object, int, int))param;
            ShortCutBaseViewModel viewModel = (ShortCutBaseViewModel)converted.Item1;
            int newPos_X = converted.Item2;
            int newPos_Y = converted.Item3;


            _profilePrevewerEditorModel.TryChangeShortCutViewModelPositionInGrid(newPos_X, newPos_Y, viewModel);
        }
    }
}
