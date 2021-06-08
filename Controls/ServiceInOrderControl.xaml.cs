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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT_Center.Controls
{
    /// <summary>
    /// Interaction logic for ServiceInOrderControl.xaml
    /// </summary>
    public partial class ServiceInOrderControl : UserControl
    {
        public event EventHandler SelectionChanged;

        public ServiceInOrderControl()
        {
            InitializeComponent();
            CbStatus.ItemsSource = AppData.Context.ServiceOfOrderStatus.ToList();

        }

        private void CbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectionChanged(sender, e);
                if ((DataContext as ServiceOfOrderStatus) != CbStatus.SelectedItem as ServiceOfOrderStatus)
                {
                    var serviceOfOrder = DataContext as ServiceOfOrder;
                    if (((sender as ComboBox).SelectedItem as ServiceOfOrderStatus).Id == 2
                        || ((sender as ComboBox).SelectedItem as ServiceOfOrderStatus).Id == 3)
                    {
                        serviceOfOrder.DateTimeEnd = DateTime.Now;
                        AppData.Context.SaveChanges();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
