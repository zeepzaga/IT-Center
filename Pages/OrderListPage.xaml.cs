using IT_Center.Entities;
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
            Update();
        }
        private void Update()
        {
            IcOrders.ItemsSource = null;
            if (AppData.currentEmployee.RoleId != 1)
                IcOrders.ItemsSource = AppData.Context.Order.ToList()
                    .Where(p => p.Employee == AppData.currentEmployee && p.OrderNumber.Contains(TbName.Text)).OrderByDescending(p => p.DateTimeOfCreate).ToList();
            else
                IcOrders.ItemsSource = AppData.Context.Order.ToList()
                   .Where(p => p.OrderNumber.Contains(TbName.Text)).OrderByDescending(p => p.DateTimeOfCreate).ToList();
        }
        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrderPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.Context.ChangeTracker.Entries<Order>().ToList().ForEach(p => p.Reload());
            Update();
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
