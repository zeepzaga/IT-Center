﻿using IT_Center.Entities;
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

namespace IT_Center.Controls
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        private  Order order;
        public OrderControl()
        {
            InitializeComponent();
            MainGrid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
            GridLine.Visibility = Visibility.Collapsed;
        }

        private void TblExpand_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var txt = sender as TextBlock;
            if (txt.Text == "\xE70E")
            {
                MainGrid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
                GridLine.Visibility = Visibility.Collapsed;
                txt.Text = "\xE70D";
            }
            else
            {
                MainGrid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                GridLine.Visibility = Visibility.Visible;
                txt.Text = "\xE70E";
            }

        }

        private void ServiceInOrderControl_SelectionChanged(object sender, EventArgs e)
        {
            var serviceOfOrder = ((sender as ComboBox).Parent as StackPanel).DataContext as ServiceOfOrder;
            ServiceOfOrder serviceOfOrder1 = order.ServiceOfOrder.FirstOrDefault(p => p.Id == serviceOfOrder.Id);
            if (serviceOfOrder1
                .ServiceOfOrderStatusId != serviceOfOrder1.ServiceOfOrderStatus.Id)
            {
                AppData.Context.ChangeTracker.Entries<Order>().ToList().ForEach(p => p.Reload());
                var buff = DataContext;
                DataContext = null;
                DataContext = buff;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            order = DataContext as Order;
        }
    }
}
