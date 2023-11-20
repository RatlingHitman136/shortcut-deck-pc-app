using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutEditors;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static ShortCutDeckDesktop.ShortCuts.ShortCutProfile;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models
{
    class ProfileEditorModel:ObservableObject
    {
        private ShortCutProfileDataHolder _editableShortCutProfileData;
        private ObservableCollection<ShortCutPreviewerBaseViewModel> _shortCutViewModels;

        private ProfileEditorViewModel profileEditorViewModel;

        public ObservableCollection<ShortCutPreviewerBaseViewModel> ShortCutViewModels
        {
            get => _shortCutViewModels;
        }

        public ProfileEditorModel(ShortCutProfile shortCutProfileToEdit, ProfileEditorViewModel profileEditorViewModel)
        {
            this.profileEditorViewModel = profileEditorViewModel;
            _editableShortCutProfileData = shortCutProfileToEdit.getDataHolder();
            List<ShortCutBaseDataHolder> shortCutsData = _editableShortCutProfileData.shortCuts;
            _shortCutViewModels = new ObservableCollection<ShortCutPreviewerBaseViewModel>();
            foreach (var a in shortCutsData)
            {
                var bastDataHolder = a as ShortCutButtonDataHolder;
                _shortCutViewModels.Add(ShortCutPreviewViewModelFactory.CreatePreviewViewModelFromDataHolder(a));
            }
        }

        public bool CanAddShortCutViewModelToGrid(ShortCutPreviewerBaseViewModel viewModelToAdd)
        {
            foreach(var oldVieModel in _shortCutViewModels)
            {
                if(oldVieModel.X_Pos == viewModelToAdd.X_Pos && oldVieModel.Y_Pos == viewModelToAdd.Y_Pos)
                    return false;
            }
            return true;
        }

        public bool TryChangeShortCutViewModelPositionInGrid(int newPos_X, int newPos_Y, ShortCutPreviewerBaseViewModel viewModel)
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

        public bool TrySelectShortCutPreviewerFromPositionInGrid(MouseButtonEventArgs mouseButtonEventArgs, int posX, int posY)
        {
            if (mouseButtonEventArgs.ChangedButton == MouseButton.Left)
                foreach (var viewModel in _shortCutViewModels)
                {
                    if (viewModel.X_Pos == posX && viewModel.Y_Pos == posY)
                    {

                        profileEditorViewModel.SelectedShortCutEditorVM = new ShortCutEditorViewModel(viewModel.DataHolder);
                        profileEditorViewModel.SelectedShortCutEditorVM.ActionBaseEditorViewModel.PropertyChanged += viewModel.UpdateProperties;
                        return true;
                    }
                }
            profileEditorViewModel.SelectedShortCutEditorVM = null;
            return false;
        }

        public void InitProfileApplyChanges()
        {
            //create new list of shortcut data holder with new positions
            List<ShortCutBaseDataHolder> newShortCuts = new List<ShortCutBaseDataHolder>();
            foreach (var viewModel in _shortCutViewModels)
                newShortCuts.Add(viewModel.DataHolder);
            _editableShortCutProfileData.shortCuts = newShortCuts;

            ShortCutProfileManager.tryUpdateExistingProfileWithDataHolder(_editableShortCutProfileData);
        }
    }
}
