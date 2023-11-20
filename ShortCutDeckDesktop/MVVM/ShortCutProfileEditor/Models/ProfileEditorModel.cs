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

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Models
{
    class ProfileEditorModel : ObservableObject
    {
        private ShortCutProfileDataHolder _editableShortCutProfileData;

        public ProfileEditorModel(ShortCutProfile shortCutProfileToEdit)
        {
            _editableShortCutProfileData = shortCutProfileToEdit.GetDataHolder();
        }

        public ObservableCollection<ShortCutPreviewerBaseViewModel> GetShortCutPreviewerViewModels()
        {
            ObservableCollection<ShortCutPreviewerBaseViewModel> shortCutViewModels = new ObservableCollection<ShortCutPreviewerBaseViewModel>();
            foreach (var data in _editableShortCutProfileData.shortCuts)
            {
                var bastDataHolder = data as ShortCutButtonDataHolder;
                shortCutViewModels.Add(ShortCutPreviewViewModelFactory.CreatePreviewViewModelFromDataHolder(data));
            }
            return shortCutViewModels;
        }

        public void InitProfileApplyChanges() =>
            ShortCutProfileManager.TryUpdateExistingProfileWithDataHolder(_editableShortCutProfileData);
    }
}
