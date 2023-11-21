using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.Profiles;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels
{
    internal class ProfileSmallViewModel:ObservableObject
    {
        private Profile _profile;
        private ICommand _selectedCommand;

        public ProfileSmallViewModel(Profile p, ICommand c) => (_profile, _selectedCommand) = (p, c);

        public Profile Profile { get { return _profile; } }
        public ICommand SelectedCommand { get { return _selectedCommand; } }
        public string ProfileName { get { return _profile.Name; } }
    }
}
