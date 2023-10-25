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

        public static readonly DependencyProperty DragDrop_RemovedCommandProperty = DependencyProperty.Register("DragDrop_RemovedCommand",
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

        public ICommand DragDrop_RemovedCommand
        {
            get { return (ICommand)GetValue(DragDrop_RemovedCommandProperty); }
            set { SetValue(DragDrop_RemovedCommandProperty, value); }
        }


        private void DragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                var contentPresenter = VisualTreeHelper.GetChild(contentControl, 0);
                if (VisualTreeHelper.GetChildrenCount(contentPresenter) > 0)
                {
                    var res = VisualTreeHelper.GetChild(contentPresenter, 0);
                    if(res is UIElement)
                        DragDrop.DoDragDrop(res, new DataObject(DataFormats.Serializable, this), DragDropEffects.Move);
                    DragDrop_MouseMoveCommand?.Execute(e);
                }
            }
        }

        private void DragDrop_MouseLeave(object sender, MouseEventArgs e)
        {
            DragDrop_MouseLeaveCommand?.Execute(e);
        }

        private void DragDrop_Drop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.Serializable);
            if (data is ShortCutPreviewPlaceHolderView)
                ((ShortCutPreviewPlaceHolderView)data).DragDrop_Removed();
            DragDrop_DropCommand?.Execute(e);
        }

        public void DragDrop_Removed()
        {
            DragDrop_RemovedCommand.Execute(null);
        }
    }
}
