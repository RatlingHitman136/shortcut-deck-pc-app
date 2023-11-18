using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers
{
    abstract class ShortCutPreviewerBaseViewModel : ObservableObject
    {
        protected int _x_pos;
        protected int _y_pos;

        protected int _size_X;
        protected int _size_Y;

        private ShortCutBaseDataHolder _dataHolder;

        protected ShortCutPreviewerBaseViewModel(int pos_X, int posY, int sizeX, int sizeY, ShortCutBaseDataHolder shortCutBaseDataHolder)
        {
            X_Pos = pos_X;
            Y_Pos = posY;
            _size_X = sizeX;
            _size_Y = sizeY;
            _dataHolder = shortCutBaseDataHolder;
        }

        public int X_Pos
        {
            get => _x_pos;
            set
            {
                _x_pos = value;
                OnPropertyChanged();
            }
        }
        public int Y_Pos
        {
            get => _y_pos;
            set
            {
                _y_pos = value;
                OnPropertyChanged();
            }
        }

        public int Size_X
        {
            get => _size_X;
            set
            {
                _size_X = value;
                OnPropertyChanged();
            }
        }
        public int Size_Y
        {
            get => _size_Y;
            set
            {
                _size_Y = value;
                OnPropertyChanged();
            }
        }

        public ShortCutBaseDataHolder DataHolder { get => _dataHolder; }
        public virtual void UpdateProperties(object? sender, PropertyChangedEventArgs e) => OnPropertyChanged();
    }
}
