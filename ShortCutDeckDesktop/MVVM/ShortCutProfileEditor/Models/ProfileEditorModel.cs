using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCuts;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models
{
    class ProfileEditorModel
    {
        private ShortCutProfile _editableShortCutProfile;

        private ObservableCollection<ShortCutBaseViewModel> _shortCutViewModels;
        internal ObservableCollection<ShortCutBaseViewModel> ShortCutViewModels { get => _shortCutViewModels; }

        public ProfileEditorModel(ShortCutProfile shortCutProfileToEdit)
        {
            _shortCutViewModels = new();
            //must be cloning shit
            _editableShortCutProfile = shortCutProfileToEdit.Clone();

        }

        public bool CanAddShortCutViewModelToGrid(ShortCutBaseViewModel viewModelToAdd)
        {
            foreach(var oldVieModel in _shortCutViewModels)
            {
                if(oldVieModel.X_Pos == viewModelToAdd.X_Pos && oldVieModel.Y_Pos == viewModelToAdd.Y_Pos)
                    return false;
            }
            return true;
        }

        public bool TryChangeShortCutViewModelPositionInGrid(int newPos_X, int newPos_Y, ShortCutBaseViewModel viewModel)
        {
            if(!_shortCutViewModels.Contains(viewModel))
                return false;
            foreach (var oldVieModel in _shortCutViewModels)
            {
                if (oldVieModel.X_Pos == newPos_X && oldVieModel.Y_Pos == newPos_Y)
                    return false;
            }
            viewModel.X_Pos = newPos_X;
            viewModel.Y_Pos = newPos_Y;
            return true;
        }
    }
}
