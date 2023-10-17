using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ShortCutDeckDesktop.Resources.Icons
{
    /// <summary>
    /// Interaction logic for ProfileLister.xaml
    /// </summary>
    public partial class ProfileLister : Page
    {

        public ProfileLister()
        {
            InitializeComponent();
            profileListerItemsControl.ItemsSource = ShortCutProfileManager.Profiles;
            
        }
        private class ProfileUIData
        {
            public string Id { get; set; }

            public ProfileUIData(string iD)
            {
                Id = iD;
            }
        }

        private void OnProfileSelected(object sender, RoutedEventArgs e)
        {
            try
            {
                Button pressedBtn = (Button)sender;
                Logger.logServerMsg(pressedBtn.Tag.ToString());
            }
            catch { }
        }
    }
}
