using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.DataLoaders;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers
{
    internal class ShortCutButtonPreviewerViewModel : ShortCutPreviewerBaseViewModel
    {

        protected new ShortCutButtonDataHolder _dataHolder;

        public ShortCutButtonPreviewerViewModel(ShortCutButtonDataHolder shortCutButtonDataHolder) : base(1, 1, shortCutButtonDataHolder)
        { 
            _dataHolder = shortCutButtonDataHolder;
        }

        public BitmapImage ShortCutImagePath => ShortCutImageLoader.GetImageByID(_dataHolder.iconId);


        public override void UpdateProperties(object? sender, PropertyChangedEventArgs e)
        {
            base.UpdateProperties(sender, e);
            OnPropertyChanged();
        }
    }
}
