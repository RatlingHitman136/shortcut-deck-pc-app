using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCuts;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
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
        private ShortCutProfileDataHolder _editableShortCutProfileData;
        private ObservableCollection<ShortCutBaseViewModel> _shortCutViewModels;


        private ShortCutEditorBaseModel? _shortCutEditorModel;

        public ObservableCollection<ShortCutBaseViewModel> ShortCutViewModels
        {
            get => _shortCutViewModels;
        }
        public ShortCutEditorBaseModel? ShortCutEditorModel
        {
            get => _shortCutEditorModel;
            set => _shortCutEditorModel = value;
        }


        public ProfileEditorModel(ShortCutProfile shortCutProfileToEdit)
        {
            _editableShortCutProfileData = shortCutProfileToEdit.GetDataHolder();
            List<(ShortCutBaseDataHolder, ShortCutProfile.GridPos)> shortCutsData = _editableShortCutProfileData.shortCuts;
            _shortCutViewModels = new ObservableCollection<ShortCutBaseViewModel>();
            foreach (var a in shortCutsData)
            {
                var bastDataHolder = a.Item1 as ShortCutButtonDataHolder;
                _shortCutViewModels.Add(ShortCutViewModelFactory.CreatePreviewViewModelFromDataHolder(a));
            }
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

        public bool TrySelectShortCutPreviewerFromPositionInGrid(int posX, int posY)
        {
            foreach (var oldVieModel in _shortCutViewModels)
            {
                if (oldVieModel.X_Pos == posX && oldVieModel.Y_Pos == posX)
                {
                    //SelectedShortCutViewModel = oldVieModel;
                    return true;
                }
            }
            return false;
        }
    }
}
