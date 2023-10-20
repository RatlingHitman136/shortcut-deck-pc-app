using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class SpecificProfileListerSideBarViewModel : ObservableObject
    {
        public SpecificProfileListerSideBarViewModel(ShortCutProfile shortCutProfile, MainWindowViewModel mainWindowViewModel)
        {
            _correspondedShortCutProfile = shortCutProfile;
            _title = shortCutProfile.Name;
            _bigProfileViewModel = new BigProfileViewModel();
            _closeCommand = new RelayCommand<SpecificProfileListerSideBarViewModel>(_ => mainWindowViewModel.TryCloseProfileListerSideBarElement(this));
        }

        private string _title;
        public string Title { get => _title; }

        private ShortCutProfile _correspondedShortCutProfile;
        public ShortCutProfile CorrespondedShortCutProfile { get => _correspondedShortCutProfile; }

        private BigProfileViewModel _bigProfileViewModel;
        internal BigProfileViewModel BigProfileViewModel { get => _bigProfileViewModel; }

        private ICommand _closeCommand;
        public ICommand CloseCommand { get => _closeCommand; }
    }
}
