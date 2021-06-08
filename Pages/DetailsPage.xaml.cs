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
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        List<Detail> detailsLIst = new List<Detail>();
        List<TypeOfDetail> typeOfDetailsList = new List<TypeOfDetail>();
        public DetailsPage()
        {
            InitializeComponent();
            detailsLIst = AppData.Context.Detail.ToList();
            typeOfDetailsList = AppData.Context.TypeOfDetail.ToList();
            typeOfDetailsList.Insert(0, new TypeOfDetail
            {
                 Name = "Все детали"
            });
            CbTypeOfDetail.ItemsSource = typeOfDetailsList;
            CbTypeOfDetail.SelectedIndex = 0;
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void CbTypeOfDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            var list = detailsLIst;
            list = list.Where(p => p.Name.ToLower().Contains(TbName.Text.ToLower())).ToList();
            if (CbTypeOfDetail.SelectedIndex > 0)
            {
                list = list.Where(p => p.TypeOfDetail == CbTypeOfDetail.SelectedItem as TypeOfDetail).ToList();
            }
            IcDetails.ItemsSource = null;
            IcDetails.ItemsSource = list;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            CreateDetailWindow createDetailWindow = new CreateDetailWindow((sender as Button).DataContext as Detail);
            createDetailWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Detail>().ToList().ForEach(p => p.Reload());
            detailsLIst = AppData.Context.Detail.ToList();
            Update();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var detail = (sender as Button).DataContext as Detail;
            if (detail.DetailOfOrder.ToList().Count(p=>p.Order.StatusOfOrder == "Выполняется") != 0)
            {
                MessageBox.Show("Невозможно удалить деталь, которая " +
                    "необходима для выполнения заказа", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show("Удалить деталь?", "Вопрос",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Context.DetailOfOrder.RemoveRange(
                    AppData.Context.DetailOfOrder.ToList().Where(p => p.Detail == detail));
                AppData.Context.Detail.Remove(detail);
                AppData.Context.SaveChanges();
                Update();
            }
        }

        private void BtnAddDetail_Click(object sender, RoutedEventArgs e)
        {
            CreateDetailWindow createDetailWindow = new CreateDetailWindow(null);
            createDetailWindow.ShowDialog();
            AppData.Context.ChangeTracker.Entries<Detail>().ToList().ForEach(p => p.Reload());
            detailsLIst = AppData.Context.Detail.ToList();
            Update();
        }
    }
}
