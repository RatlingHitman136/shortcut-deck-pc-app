using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCuts
{
    class ShortCutButtonViewModel :ShortCutBaseViewModel
    {
        public ShortCutButtonViewModel(int x_pos, int y_pos) : base(x_pos, y_pos, 1, 1)
        {
        }
    }
}
