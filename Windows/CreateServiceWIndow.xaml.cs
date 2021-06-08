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
    /// Interaction logic for CreateServiceWIndow.xaml
    /// </summary>
    public partial class CreateServiceWIndow : Window
    {
        Service _service;
        public CreateServiceWIndow(Service service)
        {
            InitializeComponent();
            _service = service;
            if (_service != null)
            {
                TbTitle.Text = "Редактирование услуги";
                DataContext = _service;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить действия?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbName.Text))
            {
                MessageBox.Show("Введите название для услуги!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_service != null)
            {
                AppData.Context.SaveChanges();
                MessageBox.Show("Информация об услуге отредактирована в БД", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AppData.Context.Service.Add(new Service
                {
                    Description = TbDescription.Text,
                    Name = TbName.Text,
                    Price = decimal.Parse(TbPrice.Text),
                });
                AppData.Context.SaveChanges();
                MessageBox.Show("Услуга добавлена в БД", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Close();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void TbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
