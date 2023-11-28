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

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.Views.ActionEditors
{
    /// <summary>
    /// Interaction logic for ActoinPCVirtualKeyPressEditorView.xaml
    /// </summary>
    public partial class ActoinPCVirtualKeyPressEditorView : UserControl
    {
        public ActoinPCVirtualKeyPressEditorView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectionChangedCommandProperty = DependencyProperty.Register("SelectionChangedCommand", 
            typeof(ICommand), typeof(ActoinPCVirtualKeyPressEditorView));

        public ICommand SelectionChangedCommand
        {
            get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
            set { SetValue(SelectionChangedCommandProperty, value); }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedCommand.Execute(e);
        }
    }
}
