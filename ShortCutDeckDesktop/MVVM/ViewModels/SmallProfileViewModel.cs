using CommunityToolkit.Mvvm.ComponentModel;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class SmallProfileViewModel : ObservableObject
    {
        public SmallProfileViewModel(ShortCutProfile correspondingProfile) { 
            _profile = correspondingProfile;
        }

        private ShortCutProfile _profile;
        public ShortCutProfile Profile { get => _profile; }
        public string ProfileName
        {
            get
            {
                return Profile.Name;
            }
        }
    }
}
