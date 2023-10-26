using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCuts
{
    abstract class ShortCutBaseViewModel : ObservableObject
    {
        internal int _x_pos;
        internal int _y_pos;

        internal int _size_X;
        internal int _size_Y;

        protected ShortCutBaseViewModel(int pos_X, int posY, int sizeX, int sizeY)
        {
            X_Pos = pos_X;
            Y_Pos = posY;
            _size_X = sizeX;
            _size_Y = sizeY;
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
    }
}
