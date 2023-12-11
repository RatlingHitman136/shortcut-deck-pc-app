using ShortCutDeckDesktop.Actions.ActionTypes;
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

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers
{
    internal class ShortCutButtonPreviewerViewModel : ShortCutPreviewerBaseViewModel
    {

        protected new ShortCutButtonDataHolder _dataHolder;

        public ShortCutButtonPreviewerViewModel(ShortCutButtonDataHolder shortCutButtonDataHolder) : base(1, 1, shortCutButtonDataHolder)
        { 
            _dataHolder = shortCutButtonDataHolder;
        }

        public string ShortCutImagePath => GetImgPathFromLoader();

        private string GetImgPathFromLoader()
        {
            return "\"pack://application:,,,/ShortCutDeckDesktop;component/Resources/Icons/ShortCutIcons/shortCut-Def.png\"";
        }

        public override void UpdateProperties(object? sender, PropertyChangedEventArgs e)
        {
            base.UpdateProperties(sender, e);
            OnPropertyChanged();
        }
    }
}
