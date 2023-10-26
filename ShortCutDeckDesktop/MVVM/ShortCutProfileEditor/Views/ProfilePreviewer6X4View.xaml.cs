using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
        private Grid gridPreviewer;


        public ProfilePreviewer6X4View()
        {
            InitializeComponent();

            ItemsPanelTemplate itemPanel = shortCutViewsHolder.ItemsPanel;
            gridPreviewer = (Grid)itemPanel.LoadContent();
        }

        public static readonly DependencyProperty DragDrop_DropCommandProperty = DependencyProperty.Register("DragDrop_DropCommand",
    typeof(ICommand), typeof(ProfilePreviewer6X4View));

        public ICommand DragDrop_DropCommand
        {
            get { return (ICommand)GetValue(DragDrop_DropCommandProperty); }
            set { SetValue(DragDrop_DropCommandProperty, value); }
        }


        private void DragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var res = Mouse.DirectlyOver as FrameworkElement;
                var viewModel = res.DataContext;
                DragDrop.DoDragDrop(res, new DataObject(DataFormats.Serializable, viewModel), DragDropEffects.Move);
            }
        }

        private void DragDrop_Drop(object sender, DragEventArgs e)
        {
            int newPos_X = 0;
            int newPos_Y = 0;
            Point mousePosition = e.GetPosition(this);

            double itemsControlHeight = shortCutViewsHolder.ActualHeight;
            double itemsControlWidth = shortCutViewsHolder.ActualWidth;

            double rowHeight = itemsControlHeight / gridPreviewer.RowDefinitions.Count;
            double columnWidth = itemsControlWidth / gridPreviewer.ColumnDefinitions.Count;

            newPos_X = (int)(mousePosition.X/ columnWidth);
            newPos_Y = (int)(mousePosition.Y/ rowHeight);

            var dataToSend = (e.Data.GetData(DataFormats.Serializable), newPos_X, newPos_Y);
            DragDrop_DropCommand.Execute(dataToSend);
        }
    }
}
