using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal class ShortCutPreviewPlaceHolderViewModel : ObservableObject
    {
        private Thickness _borderThickness;
        private object _shortCutViewModel;

        private int _index_X;
        private int _index_Y;

        private ICommand _dragDrop_MouseMoveCommand;
        private ICommand _dragDrop_MouseLeaveCommand;
        private ICommand _dragDrop_DropCommand;
        private ICommand _dragDrop_RemovedCommand;

        public ShortCutPreviewPlaceHolderViewModel(int index_X, 
            int index_Y, 
            int size_X_Max, 
            int size_Y_Max)
        {
            _index_X = index_X;
            _index_Y = index_Y;

            _borderThickness = new Thickness(1);
            if (_index_X == 0)
                _borderThickness.Left = 0;
            if (_index_X == size_X_Max - 1)
                _borderThickness.Right = 0;

            if (_index_Y == 0)
                _borderThickness.Top = 0;
            if (_index_Y == size_Y_Max - 1)
                _borderThickness.Bottom = 0;

            _dragDrop_MouseMoveCommand = new RelayCommand<object?>(p => onMouseMoveCommand(p));
            _dragDrop_MouseLeaveCommand = new RelayCommand<object?>(p => onMouseLeaveCommand(p));
            _dragDrop_DropCommand = new RelayCommand<object?>(p => onDropCommand(p));
            _dragDrop_RemovedCommand = new RelayCommand<object?>(p => onRemovedCommand(p));
        }

        public Thickness BorderThickness { get => _borderThickness; }
        public object ShortCutViewModel
        {
            get => _shortCutViewModel;
            set
            {
                _shortCutViewModel = value;
                OnPropertyChanged(nameof(ShortCutViewModel));
            }
        }

        public ICommand DragDrop_MouseMoveCommand { get => _dragDrop_MouseMoveCommand; }
        public ICommand DragDrop_MouseLeaveCommand { get => _dragDrop_MouseLeaveCommand; }
        public ICommand DragDrop_DropCommand { get => _dragDrop_DropCommand; }
        public ICommand DragDrop_RemovedCommand { get => _dragDrop_RemovedCommand; }

        private void onMouseMoveCommand(object? parameter)
        {
            if (parameter is not MouseEventArgs)
                return;
        }

        private void onMouseLeaveCommand(object? parameter)
        {
            if (parameter is not MouseEventArgs)
                return;
        }

        private void onDropCommand(object? parameter)
        {
            if (parameter is not DragEventArgs)
                return;


        }

        private void onRemovedCommand(object? parameter)
        {
            ShortCutViewModel = null;
        }
    }
}
