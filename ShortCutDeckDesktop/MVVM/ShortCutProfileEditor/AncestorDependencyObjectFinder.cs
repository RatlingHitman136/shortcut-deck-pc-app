using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor
{
    static class AncestorDependencyObjectFinder
    {
        public static T FindAncestor<T>(this DependencyObject obj)
    where T : DependencyObject
        {
            DependencyObject tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !(tmp is T))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp as T;
        }
    }
}
