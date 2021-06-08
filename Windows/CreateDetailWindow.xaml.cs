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
    /// Interaction logic for CreateDetailWindow.xaml
    /// </summary>
    public partial class CreateDetailWindow : Window
    {
        Detail _detail;
        private byte[] photo;
        public CreateDetailWindow(Detail detail)
        {
            InitializeComponent();
            _detail = detail;
            CbTypeOfDetail.ItemsSource = AppData.Context.TypeOfDetail.ToList();
            if (_detail != null)
            {
                photo = _detail.Photo;
                TbTitle.Text = "Редактирование детали";
                DataContext = detail;
                CbTypeOfDetail.Text = detail.TypeOfDetail.Name;
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
            if (MessageBox.Show("Отменить действия?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(TbDetailName.Text) || CbTypeOfDetail.SelectedIndex < 0)
            {
                MessageBox.Show("Название и тип детали обязательны для заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TypeOfDetail typeOfDetail = new TypeOfDetail();
            typeOfDetail = AppData.Context.TypeOfDetail.ToList().FirstOrDefault(p => p.Name.ToLower() == CbTypeOfDetail.Text.ToLower());
            if (typeOfDetail == null)
            {
                typeOfDetail = AppData.Context.TypeOfDetail.Add(new TypeOfDetail
                {
                    Name = CbTypeOfDetail.Text
                });
            }
            if (_detail != null)
            {
                _detail.TypeOfDetail = typeOfDetail;
                AppData.Context.SaveChanges();
                MessageBox.Show("Информация о детали отредактирована в БД", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AppData.Context.Detail.Add(new Detail
                {
                    Name = TbDetailName.Text,
                    TypeOfDetail = typeOfDetail,
                    Photo = photo,
                    Price = decimal.Parse(TbPrice.Text),
                    Description = TbDescription.Text,
                });
                AppData.Context.SaveChanges();
                MessageBox.Show("Деталь добавлена в БД", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Close();
        }

        private void TbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
