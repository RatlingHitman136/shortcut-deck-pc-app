using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels.SideLister
{
    internal class ProfileItemViewModel : BaseItemViewModel
    {
        private ICommand _closeCommand;
        public ProfileItemViewModel(ShortCutProfilesViewerViewModel profilesViewerViewModel, ProfileMainViewModel correspondingMainViewModel)
            : base(correspondingMainViewModel, correspondingMainViewModel.Profile.Name)
        {
            _closeCommand = new RelayCommand<ProfileItemViewModel>(_ => { profilesViewerViewModel.TryCloseProfile(this); });
        }

        public ShortCutProfile CorrespondingProfile { get => ((ProfileMainViewModel)CorrespondingMainViewModel).Profile; }
        public new string Title { get => CorrespondingProfile.Name; }
        public ICommand CloseCommand { get => _closeCommand; }
    }
}
