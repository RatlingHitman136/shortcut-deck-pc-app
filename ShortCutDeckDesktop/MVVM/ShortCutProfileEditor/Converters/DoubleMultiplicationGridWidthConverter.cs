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
    public class DoubleMultiplicationGridWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double res = 1;
                foreach (var item in values)
                {
                    res *= (double)item;
                }
                res += double.Parse(parameter.ToString());

                if (targetType == typeof(GridLength))
                    return new GridLength(res);


                throw new NotSupportedException();
            }
            catch { throw new Exception(); }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
