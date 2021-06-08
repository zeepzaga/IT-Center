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
using System.Windows.Shapes;

namespace IT_Center.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class CleintWindow : Window
    {
        Client _client;
        public CleintWindow(Client client)
        {
            InitializeComponent();
            _client = client;
            if (client != null)
            {
                DataContext = client;
                TbTitle.Text = "Редактирование клиента";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(TbName.Text) || !String.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Имя и фамилия обязательны для заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_client != null)
            {
                AppData.Context.SaveChanges();
            }
            else
            {
                AppData.Context.Client.Add(new Client
                {
                    FIrstName = TbName.Text,
                    Email = TbEmail.Text,
                    LastName = TbLastName.Text,
                    MiddleName = TbMiddleName.Text,
                    TelephoneNumber = TbTelephoneNumber.Text
                });
                AppData.Context.SaveChanges();
            }
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить действия?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
