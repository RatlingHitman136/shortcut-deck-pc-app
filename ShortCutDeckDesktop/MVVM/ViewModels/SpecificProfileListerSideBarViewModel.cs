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
        public SpecificProfileListerSideBarViewModel(ShortCutProfile shortCutProfile)
        {
            _correspondedShortCutProfile = shortCutProfile;
            _title = shortCutProfile.Name;
        }

        private ShortCutProfile _correspondedShortCutProfile;

        public ShortCutProfile CorrespondedShortCutProfile { get => _correspondedShortCutProfile; }
    }
}
