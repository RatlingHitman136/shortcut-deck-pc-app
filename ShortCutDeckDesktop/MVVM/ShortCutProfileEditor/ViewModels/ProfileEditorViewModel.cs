using CommunityToolkit.Mvvm.ComponentModel;
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

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal class ProfileEditorViewModel : ObservableObject
    {
        private double _previewerHorizontalMargin;
        private double _previewerVerticalMargin;

        private ProfileEditorModel _profileEditorModel;
        private ProfilePreviewer6X4ViewModel _profilePreviewerViewModel;
        private ShortCutEditorViewModel? _selectedShortcutEditorVM;

        public ProfileEditorViewModel(ShortCutProfile profileToEdit)
        {
            _previewerHorizontalMargin = 15;
            _previewerVerticalMargin = 15;

            _profileEditorModel = new ProfileEditorModel(profileToEdit, this);
            _profilePreviewerViewModel = new ProfilePreviewer6X4ViewModel(_profileEditorModel);
        }

        public int PreviewerHorizontalGridSize { get => ShortCutProfileManager.GridWidth; }
        public int PreviewerVerticalGridSize { get => ShortCutProfileManager.GridHeight; }
        public Thickness PreviewerMargin { get => new Thickness(_previewerHorizontalMargin, _previewerVerticalMargin, PreviewerHorizontalMargin, PreviewerVerticalMargin); }
        public double PreviewerHorizontalMargin { get => _previewerHorizontalMargin; set => _previewerHorizontalMargin = value; }
        public double PreviewerVerticalMargin { get => _previewerVerticalMargin; set => _previewerVerticalMargin = value; }
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
    }
}
