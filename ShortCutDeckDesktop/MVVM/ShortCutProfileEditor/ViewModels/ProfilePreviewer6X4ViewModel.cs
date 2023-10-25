using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCuts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    class ProfilePreviewer6X4ViewModel : ObservableObject
    {
        private ObservableCollection<ShortCutPreviewPlaceHolderViewModel> _shortCutPlaceHolders;

        public ProfilePreviewer6X4ViewModel()
        {
            _shortCutPlaceHolders = new();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 4; j++)
                    _shortCutPlaceHolders.Add(new ShortCutPreviewPlaceHolderViewModel(j, i, 4, 6));

            var testView = new ShortCutButtonViewModel();
            _shortCutPlaceHolders[0].ShortCutViewModel = testView;
        }

        public ObservableCollection<ShortCutPreviewPlaceHolderViewModel> ShortCutPlaceHolders { get => _shortCutPlaceHolders; }
    }
}
