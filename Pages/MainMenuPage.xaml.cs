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

namespace IT_Center.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void BtnOrderList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderListPage());
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicePage());
        }

        private void BtnDetailsPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DetailsPage());
        }

        private void BtnWorkerList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkerListPage());
        }


        private void BtnClientList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientListPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppData.currentEmployee.RoleId != 1)
            {
                BtnWorkerList.Visibility = Visibility.Collapsed;
            }
        }
    }
}
