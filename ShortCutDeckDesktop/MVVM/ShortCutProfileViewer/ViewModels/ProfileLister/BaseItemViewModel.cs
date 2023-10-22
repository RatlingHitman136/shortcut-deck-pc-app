using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileViewer.ViewModels.ProfileLister
{
    internal class BaseItemViewModel:ObservableObject
    {
        private object _correspondingMainViewModel;
        private string _title;

        public BaseItemViewModel(object correspondingMainViewModel, string title)
        {
            _correspondingMainViewModel = correspondingMainViewModel;
            _title = title;
        }

        public object CorrespondingMainViewModel { get => _correspondingMainViewModel; }
        public string Title { get => _title; }
    }
}
