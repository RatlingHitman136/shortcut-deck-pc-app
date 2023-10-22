using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels.ProfileLister;
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
        private ObservableCollection<BaseItemViewModel> _profileListerViewModels;
        private BaseItemViewModel _selectedProfileListerViewModel;
        private BaseItemViewModel _defaultSelectedListerItem;
        #endregion

        public ShortCutProfilesViewerViewModel()
        {
            _defaultSelectedListerItem = new(new DefaultMainViewModel(this), "Profiles");
            _profileListerViewModels = new() { _defaultSelectedListerItem };
            SelectedProfileListerViewModel = _defaultSelectedListerItem;
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
        public ObservableCollection<BaseItemViewModel> ProfileListerViewModels { get => _profileListerViewModels; }
        public BaseItemViewModel SelectedProfileListerViewModel
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

        public bool IsProfileOpened(ShortCutProfile shortCutProfile, out ProfileItemViewModel? profileItemViewModel)
        {
            foreach (var item in ProfileListerViewModels.Where(x => x is ProfileItemViewModel)
                .Select(x => x as ProfileItemViewModel))
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

        public void TryCloseProfile(ProfileItemViewModel profileToClose)
        {
            int res = ProfileListerViewModels.IndexOf(profileToClose);
            if (res > -1)
            {
                if(profileToClose == SelectedProfileListerViewModel)
                    SelectedProfileListerViewModel = ProfileListerViewModels[res-1];
                ProfileListerViewModels.RemoveAt(res);
                OnPropertyChanged(nameof(ProfileListerViewModels));
            }
        }
    }
}
