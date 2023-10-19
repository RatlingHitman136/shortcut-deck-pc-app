using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class SpecificProfileListerSideBarViewModel : DefaultProfileListerSideBarViewModel
    {
        public SpecificProfileListerSideBarViewModel(ShortCutProfile shortCutProfile, MainWindowViewModel mainWindowViewModel) : base(mainWindowViewModel)
        {
            _correspondedShortCutProfile = shortCutProfile;
            _title = shortCutProfile.Name;
            _bigProfileViewModel = new BigProfileViewModel();
        }

        private ShortCutProfile _correspondedShortCutProfile;
        public ShortCutProfile CorrespondedShortCutProfile { get => _correspondedShortCutProfile; }

        private BigProfileViewModel _bigProfileViewModel;

        public override void SelectThisView()
        {
            _mainWindowViewModel.CurrentProfileViewerViewModel = _bigProfileViewModel;
        }
    }
}
