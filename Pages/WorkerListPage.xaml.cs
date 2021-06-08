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
    /// Interaction logic for WorkerListPage.xaml
    /// </summary>
    public partial class WorkerListPage : Page
    {
        List<Employee> employeesList = new List<Employee>();
        List<Role> rolesList = new List<Role>();
        public WorkerListPage()
        {
            InitializeComponent();
            rolesList = AppData.Context.Role.ToList();
            rolesList.Insert(0, new Role
            {
                Name = "Все должности"
            });
            CbRole.ItemsSource = AppData.Context.Role.ToList();
            CbRole.SelectedIndex = 0;
            employeesList = AppData.Context.Employee.ToList();
            Update();
        }

        private void BtnWorker_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow(null);
            addWorkerWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Employee>().ToList().ForEach(p => p.Reload());
            employeesList = AppData.Context.Employee.ToList();
            Update();
        }

        private void CbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow((sender as Button).DataContext as Employee);
            addWorkerWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Employee>().ToList().ForEach(p => p.Reload());
            employeesList = AppData.Context.Employee.ToList();
            Update();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Уволить работника?","Вопрос",
                MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ((sender as Button).DataContext as Employee).IsWork = false;
                AppData.Context.SaveChanges();
            }
            Update();
        }

        private void Update()
        {
            var list = employeesList;
            list = list.Where(p => p.FullName.ToLower().Contains(TbName.Text.ToLower())).ToList();
            if (CbRole.SelectedIndex > 0)
                list = list.Where(p => p.Role == CbRole.SelectedItem as Role).ToList();
            IcDetails.ItemsSource = null;
            IcDetails.ItemsSource = list;
        }
    }
}
