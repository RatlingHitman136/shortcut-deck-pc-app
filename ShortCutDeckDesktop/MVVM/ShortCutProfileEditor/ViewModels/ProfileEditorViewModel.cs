using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutEditors;
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

            _profileEditorModel = new ProfileEditorModel(profileToEdit, this);
            _profilePreviewerViewModel = new ProfilePreviewer6X4ViewModel(_profileEditorModel);

            _applyChangesCommand = new RelayCommand(_profileEditorModel.InitProfileApplyChanges);
        }

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
    }
}
