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
    /// Interaction logic for ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public ClientListPage()
        {
            InitializeComponent();
            Update();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            CleintWindow cleintWindow = new CleintWindow(null);
            cleintWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Employee>().ToList().ForEach(p => p.Reload());
            Update();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            CleintWindow cleintWindow = new CleintWindow((sender as Button).DataContext as Client);
            cleintWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Employee>().ToList().ForEach(p => p.Reload());
            Update();
        }

        private void Update()
        {
            DgService.ItemsSource = null;
            DgService.ItemsSource = AppData.Context.Client.ToList().Where(p => p.FullName.ToLower().Contains(TbName.Text.ToLower()));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            CleintWindow cleintWindow = new CleintWindow(null);
            cleintWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Employee>().ToList().ForEach(p => p.Reload());
            Update();
        }
    }
}
