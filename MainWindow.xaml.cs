using IT_Center.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace IT_Center
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            TbDateTime.Text = $"{DateTime.Now:dd MMMM yyyy hh:mm}";
            dispatcherTimer.Start();
            MainFrame.Navigate(new MainMenuPage());
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TbDateTime.Text = $"{DateTime.Now:dd MMMM yyyy hh:mm}";
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var page = MainFrame.Content as Page;
            if (page is AutorizationPage)
            {
                SpLogout.Visibility = Visibility.Collapsed;
                GridLine.Visibility = Visibility.Collapsed;
                TblBack.Visibility = Visibility.Collapsed;
            }
            else
            {
                SpLogout.Visibility = Visibility.Visible;
                GridLine.Visibility = Visibility.Visible;
                TblBack.Visibility = Visibility.Visible;
            }

        }

        private void TblBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var page = MainFrame.Content as Page;
            if (page is MainMenuPage)
            {
                TblLogout_MouseLeftButtonDown(null, null);
                return;
            }
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void TblLogout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("Выйти из аккаунта?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainFrame.Navigate(new AutorizationPage());
            }
        }
    }
}
