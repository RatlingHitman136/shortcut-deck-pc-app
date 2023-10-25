using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Views
{
    /// <summary>
    /// Interaction logic for ProfilePreviewerView.xaml
    /// </summary>
    public partial class ProfilePreviewer6X4View : UserControl
    {
        public ProfilePreviewer6X4View()
        {
            InitializeComponent();
        }

        private void ItemControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                var obj = Mouse.DirectlyOver as Rectangle;
                DragDrop.DoDragDrop(obj, obj, DragDropEffects.Move);
            }
        }
    }
}
