using IT_Center.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace IT_Center.Windows
{
    /// <summary>
    /// Interaction logic for AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        Employee _employee;
        byte[] photo;
        public AddWorkerWindow(Employee employee)
        {
            InitializeComponent();
            CbRole.ItemsSource = AppData.Context.Role.ToList();
            _employee = employee;
            if (employee != null)
            {
                photo = employee.Photo;
                TbTitle.Text = "Редактирование работника";
                DataContext = _employee;
            }
        }

        private void BtnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                photo = File.ReadAllBytes(openFileDialog.FileName);
                ImgPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить действия", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_employee == null)
            {
                AppData.Context.Employee.Add(new Employee
                {
                    FirstName = TbName.Text,
                    IsWork = true,
                    LastName = TbLastName.Text,
                    MiddleName = TbMiddleName.Text,
                    Passport = TbPassport.Text,
                    TelephoneNumber = TbTelephoneNumber.Text,
                    Role = CbRole.SelectedItem as Role,
                    Photo = photo,
                });
                AppData.Context.SaveChanges();
            }
            else
            {
                _employee.Role = CbRole.SelectedItem as Role;
                _employee.Photo = photo;
                AppData.Context.SaveChanges();
            }
            Close();
        }
    }
}
