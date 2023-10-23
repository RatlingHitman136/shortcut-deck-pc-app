using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal class ShortCutProfileEditorViewModel : ObservableObject
    {
        private double _widthToHeightRatio = 0.5;

        public double WidthToHeightRatio { get => _widthToHeightRatio; }
    }
}
