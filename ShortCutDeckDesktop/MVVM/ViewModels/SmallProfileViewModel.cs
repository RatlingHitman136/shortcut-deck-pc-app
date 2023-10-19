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
    internal class SmallProfileViewModel : ObservableObject
    {
        public SmallProfileViewModel(ShortCutProfile correspondingProfile, ICommand profileSelectedCommand) { 
            _profile = correspondingProfile;
            _profileSelected = profileSelectedCommand;
        }

        private MainWindowViewModel _mainWindowViewModel;
        private ShortCutProfile _profile;
        public ShortCutProfile Profile { get => _profile; }
        private ICommand _profileSelected;
        public ICommand ProfileSelected { get => _profileSelected; }
        public string ProfileName
        {
            get
            {
                return Profile.Name;
            }
        }
    }
}
