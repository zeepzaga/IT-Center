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
    /// Interaction logic for CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        List<Detail> detailsList = new List<Detail>();
        List<Service> serviceList = new List<Service>();
        public CreateOrderPage()
        {
            InitializeComponent();
            detailsList = AppData.Context.Detail.ToList();
            IcDetails.ItemsSource = detailsList;
            IcServices.ItemsSource = AppData.Context.Service.ToList();
            CbClient.ItemsSource = AppData.Context.Client.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            if (String.IsNullOrWhiteSpace(CbClient.Text)) error += "• Введите ФИО клиента!";
            if (detailsList.Count(p => p.CoutOnOrder != 0) == 0 && serviceList.Count == 0) error += "\n• В заказе должна быть как минимум 1 услуга или деталь!";
            if (error.Length != 0)
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Client client = AppData.Context.Client.ToList().FirstOrDefault(p => p.FullName == CbClient.Text
                            && p.TelephoneNumber == TbTelephoneNumber.Text);
            if (client == null)
            {
                client = new Client
                {
                    FIrstName = CbClient.Text.Split(' ')[1],
                    LastName = CbClient.Text.Split(' ')[0],
                    MiddleName = CbClient.Text.Split().Length < 3 ? null : CbClient.Text.Split(' ')[2],
                    Email = TbEmail.Text,
                    TelephoneNumber = TbTelephoneNumber.Text,
                };
            }
            Order order = AppData.Context.Order.Add(new Order
            {
                DateTimeOfCreate = DateTime.Now,
                Description = TbDescription.Text,
                Employee = AppData.currentEmployee,
                Client = client,
            });
            foreach (var item in detailsList)
            {
                if (item.CoutOnOrder != 0)
                {
                    AppData.Context.DetailOfOrder.Add(new DetailOfOrder
                    {
                        Count = item.CoutOnOrder,
                        Detail = item,
                        Order = order
                    });
                }
            }
            foreach (var item in serviceList)
            {
                AppData.Context.ServiceOfOrder.Add(new ServiceOfOrder
                {
                    Order = order,
                    Service = item,
                    ServiceOfOrderStatusId = 1,

                });
            }
            AppData.Context.SaveChanges();
            NavigationService.GoBack();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить действия?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Service;
            serviceList.Add(service);
            (sender as Button).Visibility = Visibility.Collapsed;
        }

        private void CbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = (CbClient.SelectedItem as Client);
            if (client != null)
            {
                TbTelephoneNumber.Text = client.TelephoneNumber;
                TbEmail.Text = client.Email;
            }
            else
            {
                TbTelephoneNumber.Text = null;
                TbEmail.Text = null;
            }
        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void BtnRemoveService_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Service;
            if (serviceList.FirstOrDefault(p => p == service) != null)
            {
                serviceList.Remove(service);
                foreach (var item in ((sender as Button).Parent as Grid).Children)
                {
                    if (item is Button btn)
                        if (btn.Name == "BtnAddService")
                            btn.Visibility = Visibility.Visible;
                }       
            }
        }
    }
}
