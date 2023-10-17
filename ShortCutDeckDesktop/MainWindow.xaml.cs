using System;
using System.ComponentModel;
using System.Windows;
using ShortCutDeckDesktop.Resources.Icons;
using ShortCutDeckDesktop.ShortCuts;

namespace ShortCutDeckDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProfileLister profileLister;


        public MainWindow()
        {
            InitializeComponent();
            Logger.setServerLogField(tb_server_log);

            profileLister = new ProfileLister();
            fProfileLister.Navigate(profileLister);
        }

        private void btn_clear_log_field_Click(object sender, RoutedEventArgs e)
        {
            tb_server_log.Text = string.Empty;
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
        }

        private void tray_icon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void tray_icon_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}