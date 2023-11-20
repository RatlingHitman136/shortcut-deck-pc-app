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
        protected int _size_X;
        protected int _size_Y;

        protected ShortCutBaseDataHolder _dataHolder;

        protected ShortCutPreviewerBaseViewModel( int sizeX, int sizeY, ShortCutBaseDataHolder shortCutBaseDataHolder)
        {
            _size_X = sizeX;
            _size_Y = sizeY;
            _dataHolder = shortCutBaseDataHolder;
        }

        public int X_Pos
        {
            get => _dataHolder.posX;
            set
            {
                _dataHolder.posX = value;
                OnPropertyChanged();
            }
        }
        public int Y_Pos
        {
            get => _dataHolder.posY;
            set
            {
                _dataHolder.posY = value;
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
        public bool IsHit(int hitPosX, int hitPosY) => 
            (hitPosX >= X_Pos && hitPosX <= X_Pos + Size_X) 
            && (hitPosY >= Y_Pos && hitPosY <= Y_Pos + Size_Y);
    }
}
