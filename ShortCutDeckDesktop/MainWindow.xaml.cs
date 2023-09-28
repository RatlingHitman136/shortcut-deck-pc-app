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
using Hardcodet.Wpf.TaskbarNotification;
using ShortCutDeckDesktop.Networking;
using ShortCutDeckDesktop.ShortCuts;

namespace ShortCutDeckDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskbarIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            ShortCutProfileManager.initTestOneProfile();
            Logger.setServerLogField(tb_server_log);

            //notifyIcon = new TaskbarIcon();
            //notifyIcon.Icon = new System.Drawing.Icon("""Icons\tastbarTray.ico""",128, 128);

            //notifyIcon.TrayMouseDoubleClick += NotifyIcon_TrayMouseDoubleClick;

            //StateChanged += MainWindow_StateChanged;
        }

        private void NotifyIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void btn_start_server_Click(object sender, RoutedEventArgs e)
        {
            ServerClass.startServer();
        }

        private void btn_clear_log_field_Click(object sender, RoutedEventArgs e)
        {
            tb_server_log.Text = string.Empty;
        }

        private void MainWindow_StateChanged(object? sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}