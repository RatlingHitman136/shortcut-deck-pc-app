using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ViewModels
{
    internal class DefaultProfileListerSideBarViewModel:ObservableObject 
    {
        internal string _title = "Profiles";

        public string Title { get => _title; }
    }
}
