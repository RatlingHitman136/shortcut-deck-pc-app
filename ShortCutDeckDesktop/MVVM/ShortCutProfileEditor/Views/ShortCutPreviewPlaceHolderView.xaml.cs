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
    /// Interaction logic for ShortCutPreviewPlaceHolderView.xaml
    /// </summary>
    public partial class ShortCutPreviewPlaceHolderView : UserControl
    {
        public ShortCutPreviewPlaceHolderView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DragDrop_MouseMoveCommandProperty = DependencyProperty.Register("DragDrop_MouseMoveCommand",
            typeof(ICommand), typeof(ShortCutPreviewPlaceHolderView));

        public static readonly DependencyProperty DragDrop_MouseLeaveCommandProperty = DependencyProperty.Register("DragDrop_MouseLeaveCommand",
            typeof(ICommand), typeof(ShortCutPreviewPlaceHolderView));

        public static readonly DependencyProperty DragDrop_DropCommandProperty = DependencyProperty.Register("DragDrop_DropCommand",
            typeof(ICommand), typeof(ShortCutPreviewPlaceHolderView));

        public ICommand DragDrop_MouseMoveCommand
        {
            get { return (ICommand)GetValue(DragDrop_MouseMoveCommandProperty); }
            set { SetValue(DragDrop_MouseMoveCommandProperty, value); }
        }

        public ICommand DragDrop_MouseLeaveCommand
        {
            get { return (ICommand)GetValue(DragDrop_MouseLeaveCommandProperty); }
            set { SetValue(DragDrop_MouseLeaveCommandProperty, value); }
        }

        public ICommand DragDrop_DropCommand
        {
            get { return (ICommand)GetValue(DragDrop_DropCommandProperty); }
            set { SetValue(DragDrop_DropCommandProperty, value); }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            
            DragDrop_MouseMoveCommand?.Execute(e);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            DragDrop_MouseLeaveCommand?.Execute(e);
        }

        private void Border_Drop(object sender, DragEventArgs e)
        {
            DragDrop_DropCommand?.Execute(e);
        }
    }
}
