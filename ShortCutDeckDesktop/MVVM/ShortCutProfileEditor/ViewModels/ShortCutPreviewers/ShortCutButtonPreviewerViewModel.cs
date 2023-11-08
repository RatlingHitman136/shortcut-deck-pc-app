using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers
{
    internal class ShortCutButtonPreviewerViewModel : ShortCutPreviewerBaseViewModel
    {

        internal new ShortCutButtonDataHolder _dataHolder;

        public ShortCutButtonPreviewerViewModel(int x_pos, int y_pos, ShortCutButtonDataHolder shortCutButtonDataHolder) : base(x_pos, y_pos, 1, 1, shortCutButtonDataHolder)
        { 
            _dataHolder = shortCutButtonDataHolder;
        }
    }
}
