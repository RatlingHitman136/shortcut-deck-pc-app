using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Converters
{
    public class EditorColumnWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double height;             // [0] - ActualHeight
            double horizontalMargin;   // [1] - used margins horizontally
            double verticalMargin;     // [2] - used margins vertically
            int horizontalGridSize;    // [3] - grid size horizontally
            int verticalGridSize;      // [4] - grid size vertically

            try
            {
                height = (double)values[0];
                horizontalMargin = (double)values[1];
                verticalMargin = (double)values[2];
                horizontalGridSize = (int)values[3];
                verticalGridSize = (int)values[4];
            }
            catch { throw new ArgumentException(); }

            double actualGridHeight = height - 2 * verticalMargin;
            double actualGridWidth = actualGridHeight / verticalGridSize * horizontalGridSize;

            double returnVal = actualGridWidth + 2 * horizontalMargin;

            if (targetType != typeof(GridLength))
                throw new ArgumentException();

            return new GridLength(returnVal);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
