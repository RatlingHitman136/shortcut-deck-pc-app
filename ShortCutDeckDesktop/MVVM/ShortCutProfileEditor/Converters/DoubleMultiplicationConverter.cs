using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Converters
{
    public class DoubleMultiplicationConverter : IMultiValueConverter
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
                //res += (double)parameter;
                return res;
            }
            catch { throw new Exception(); }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
