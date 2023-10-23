using CommunityToolkit.Mvvm.ComponentModel;
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
    internal class ShortCutProfileEditorViewModel : ObservableObject
    {
        private double _editorHorizontalMargin;
        private double _editorVerticalMargin;

        public ShortCutProfileEditorViewModel()
        {
            _editorHorizontalMargin = 15;
            _editorVerticalMargin = 15;
        }

        public int EditorHorizontalGridSize { get => ShortCutProfileManager.GridWidth; }
        public int EditorVerticalGridSize { get => ShortCutProfileManager.GridHeight; }
        public Thickness EditorMargin { get => new Thickness(_editorHorizontalMargin, _editorVerticalMargin, EditorHorizontalMargin, EditorVerticalMargin); }
        public double EditorHorizontalMargin { get => _editorHorizontalMargin; set => _editorHorizontalMargin = value; }
        public double EditorVerticalMargin { get => _editorVerticalMargin; set => _editorVerticalMargin = value; }

    }
}
