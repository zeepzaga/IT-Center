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
    /// Interaction logic for AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Entities.User user = AppData.Context.User.ToList().FirstOrDefault(p => p.Login == TbLogin.Text
                           && p.Password == PbPassword.Password);
            if (user != null)
            {
                AppData.currentEmployee = AppData.Context.Employee.ToList().FirstOrDefault(p => p.Id == user.Id);
                NavigationService.Navigate(new MainMenuPage());
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
