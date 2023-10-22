using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels
{
    internal class ShortCutProfilesViewerViewModel:ObservableObject
    {
        #region private Fields
        private object _profileMainViewModel;
        private ObservableCollection<object> _profileListerViewModels;
        private object _selectedProfileListerViewModel;

        #endregion

        public ShortCutProfilesViewerViewModel()
        {

        }

        #region public Properties
        public object ProfileMainViewModel { get => _profileMainViewModel; }
        public ObservableCollection<object> ProfileListerViewModels { get => _profileListerViewModels; }
        public object SelectedProfileListerViewModel
        {
            get => _selectedProfileListerViewModel;
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
