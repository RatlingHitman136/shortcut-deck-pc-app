using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels;
using ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.Views;
using ShortCutDeckDesktop.ShortCuts;
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
        private ObservableCollection<SideLister.BaseItemViewModel> _sideListerViewModels;
        private SideLister.BaseItemViewModel _selectedProfileListerViewModel;
        #endregion

        public ShortCutProfilesViewerViewModel()
        {
            _sideListerViewModels = new() { new SideLister.BaseItemViewModel(new DefaultMainViewModel(this), "Profiles") };
            SelectedProfileListerViewModel = _sideListerViewModels[0];
            OnPropertyChanged();
        }

        #region public Properties
        public object ProfileMainViewModel 
        { 
            get => _profileMainViewModel; 
            set
            {
                _profileMainViewModel = value;
                OnPropertyChanged(nameof(ProfileMainViewModel));
            }
        }
        public ObservableCollection<SideLister.BaseItemViewModel> SideListerViewModels { get => _sideListerViewModels; }
        public SideLister.BaseItemViewModel SelectedProfileListerViewModel
        {
            get => _selectedProfileListerViewModel;
            set
            {
                _selectedProfileListerViewModel = value;    
                ProfileMainViewModel = _selectedProfileListerViewModel.CorrespondingMainViewModel;
                OnPropertyChanged(nameof(SelectedProfileListerViewModel));
            }
        }
        #endregion

        public bool IsProfileOpened(ShortCutProfile shortCutProfile, out SideLister.ProfileItemViewModel? profileItemViewModel)
        {
            foreach (var item in SideListerViewModels.Where(x => x is SideLister.ProfileItemViewModel)
                .Select(x => x as SideLister.ProfileItemViewModel))
            {
                if (item != null)
                    if (item.CorrespondingProfile == shortCutProfile)
                    {
                        profileItemViewModel = item;
                        return true;
                    }
            }

            profileItemViewModel = null;
            return false;   
        }

        public void TryCloseProfile(SideLister.ProfileItemViewModel profileToClose)
        {
            int res = SideListerViewModels.IndexOf(profileToClose);
            if (res > -1)
            {
                if(profileToClose == SelectedProfileListerViewModel)
                    SelectedProfileListerViewModel = SideListerViewModels[res-1];
                SideListerViewModels.RemoveAt(res);
                OnPropertyChanged(nameof(SideListerViewModels));
            }
        }
    }
}
