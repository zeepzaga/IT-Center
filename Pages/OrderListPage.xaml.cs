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
    /// Interaction logic for OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public OrderListPage()
        {
            InitializeComponent();
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrderPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IcOrders.ItemsSource = AppData.Context.Order.ToList();
        }
    }
}
