using IT_Center.Entities;
using IT_Center.Windows;
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
    /// Interaction logic for ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            Update();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            CreateServiceWIndow createServiceWIndow = 
                new CreateServiceWIndow((sender as Button).DataContext as Service);
            createServiceWIndow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Service>().ToList().ForEach(p => p.Reload());
            Update();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Service;
            if (AppData.Context.ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1
            && p.Service == service) != 0)
            {
                MessageBox.Show("Невозможно удалить услугу, которая выполняется", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show("Удалить услугу?", "Вопрос",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Context.ServiceOfOrder.RemoveRange(
                    AppData.Context.ServiceOfOrder.ToList().Where(p => p.Service == service));
                AppData.Context.Service.Remove(service);
                AppData.Context.SaveChanges();
                Update();
            }
        }
        private void Update()
        {
            DgService.ItemsSource = null;
            DgService.ItemsSource = AppData.Context.Service.ToList().Where(p=>p.Name.ToLower().Contains(TbName.Text.ToLower()));
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            CreateServiceWIndow createServiceWIndow = new CreateServiceWIndow(null);
            createServiceWIndow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Service>().ToList().ForEach(p => p.Reload());
            Update();
        }
    }
}
