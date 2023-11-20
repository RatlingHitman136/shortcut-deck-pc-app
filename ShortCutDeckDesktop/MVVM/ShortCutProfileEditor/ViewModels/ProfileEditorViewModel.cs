using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutEditors;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal class ProfileEditorViewModel : ObservableObject
    {
        private double _horizontalMargin;
        private double _verticalMargin;

        private ProfileEditorModel _profileEditorModel;
        private ProfilePreviewer6X4ViewModel _profilePreviewerViewModel;
        private ShortCutEditorViewModel? _selectedShortcutEditorVM;

        private ICommand _applyChangesCommand;

        public ProfileEditorViewModel(ShortCutProfile profileToEdit)
        {
            _horizontalMargin = 15;
            _verticalMargin = 15;

            _profileEditorModel = new ProfileEditorModel(profileToEdit);

            ICommand onShortCutDroppedCommand = new RelayCommand<object>(OnShortCutDropped);
            ICommand OnShortCutSelectedCommand = new RelayCommand<object>(OnShortCutSelected);
            _profilePreviewerViewModel = new ProfilePreviewer6X4ViewModel(_profileEditorModel, onShortCutDroppedCommand, OnShortCutSelectedCommand);

            _applyChangesCommand = new RelayCommand(_profileEditorModel.InitProfileApplyChanges);
        }


        #region Properties
        public int PreviewerHorizontalGridSize { get => ShortCutProfileManager.GridWidth; }
        public int PreviewerVerticalGridSize { get => ShortCutProfileManager.GridHeight; }
        public Thickness GridElementAllMargin { get => new Thickness(_horizontalMargin, _verticalMargin, _horizontalMargin, _verticalMargin); }
        public Thickness GridElementBottomSidesMargin { get => new Thickness(_horizontalMargin, 0, _horizontalMargin, _verticalMargin); }
        public double HorizontalMargin { get => _horizontalMargin; set => _horizontalMargin = value; }
        public double VerticalMargin { get => _verticalMargin; set => _verticalMargin = value; }
        public ProfilePreviewer6X4ViewModel ProfilePreviewerViewModel { get => _profilePreviewerViewModel; }
        public ShortCutEditorViewModel? SelectedShortCutEditorVM
        {
            get => _selectedShortcutEditorVM;
            set
            {
                _selectedShortcutEditorVM = value;
                OnPropertyChanged();
            }
        }
        public ICommand ApplyChangesCommand { get => _applyChangesCommand; }
        #endregion

        private void OnShortCutDropped(object? param)
        {
            if (param is not (ShortCutPreviewerBaseViewModel, int, int))
                return;

            var converted = ((object, int, int))param;
            ShortCutPreviewerBaseViewModel viewModel = (ShortCutPreviewerBaseViewModel)converted.Item1;
            int newPos_X = converted.Item2;
            int newPos_Y = converted.Item3;


            TryChangeShortCutViewModelPositionInGrid(newPos_X, newPos_Y, viewModel);
        }

        public bool TryChangeShortCutViewModelPositionInGrid(int newPos_X, int newPos_Y, ShortCutPreviewerBaseViewModel viewModel)
        {
            if (!_profilePreviewerViewModel.ShortCutsViewModels.Contains(viewModel))
                return false;
            foreach (var oldVieModel in _profilePreviewerViewModel.ShortCutsViewModels)
            {
                if (oldVieModel.X_Pos == newPos_X && oldVieModel.Y_Pos == newPos_Y)
                    return false;
            }
            viewModel.X_Pos = newPos_X;
            viewModel.Y_Pos = newPos_Y;

            return true;
        }

        private void OnShortCutSelected(object? param)
        {
            if (param is not (MouseButtonEventArgs, int, int))
                return;

            var convertedParams = ((MouseButtonEventArgs, int, int))param;
            TrySelectShortCutPreviewerFromPositionInGrid(convertedParams.Item1, convertedParams.Item2, convertedParams.Item3);
        }

        public bool TrySelectShortCutPreviewerFromPositionInGrid(MouseButtonEventArgs mouseButtonEventArgs, int posX, int posY)
        {
            if (mouseButtonEventArgs.ChangedButton == MouseButton.Left)
                foreach (var viewModel in _profilePreviewerViewModel.ShortCutsViewModels)
                {
                    if (viewModel.X_Pos == posX && viewModel.Y_Pos == posY)
                    {

                        SelectedShortCutEditorVM = new ShortCutEditorViewModel(viewModel.DataHolder);
                        SelectedShortCutEditorVM.ActionBaseEditorViewModel.PropertyChanged += viewModel.UpdateProperties;
                        return true;
                    }
                }
            SelectedShortCutEditorVM = null;
            return false;
        }
    }
}
