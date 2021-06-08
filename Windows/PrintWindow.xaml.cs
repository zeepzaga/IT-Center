using IT_Center.Entities;
using mshtml;
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
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        Order order;
        public PrintWindow(Order _order)
        {
            InitializeComponent();
            order = _order;
            PrintForClient(order);
        }

        private void PrintForClient(Order order)
        {
            StringBuilder result = new StringBuilder();
            result.Append(@"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'><head></head>");
            result.Append("<body>");
            result.Append($"<h1 align=\"center\">Чек заказа №{order.OrderNumber}</h1>");
            result.Append("<table width=100% border=1 bordercolor=#000 style='border-collapse:collapse;'>");
            result.Append("<tr>");
            result.Append("<th colspan=\"4\">Детали</th>");
            result.Append("</tr>");
            result.Append("<tr>");
            result.Append("<th>Деталь</th>");
            result.Append("<th>Количестов в заказе</th>");
            result.Append("<th>Цена за штуку</th>");
            result.Append("<th>Итоговая цена</th>");
            result.Append("</tr>");
            foreach (var item in order.DetailOfOrder.ToList())
            {
                result.Append("<tr>");
                result.Append($"<td>{item.Detail.Name}</td>");
                result.Append($"<td>{item.Count}</td>");
                result.Append($"<td>{item.Detail.Price}</td>");
                result.Append($"<td>{item.Detail.Price * item.Count}</td>");
                result.Append("</tr>");
            }
            result.Append("<th colspan=\"4\">Услуги</th>");
            result.Append("</tr>");
            result.Append("<tr>");
            result.Append("<th colspan=\"2\">Название</th>");
            result.Append("<th colspan=\"2\">Цена</th>");
            result.Append("</tr>");
            foreach (var item in order.ServiceOfOrder.ToList().Where(p => p.ServiceOfOrderStatusId != 3).ToList())
            {
                result.Append("<tr>");
                result.Append($"<td colspan=\"2\">{item.Service.Name}</td>");
                result.Append($"<td colspan=\"2\">{item.Service.Price}</td>");
                result.Append("</tr>");
            }
            result.Append("</table>");
            result.Append($"<p>Заказчик: _______________ {order.Client.FullName}</p>");
            result.Append("</body>");
            result.Append("</html>");
            BrowserMain.NavigateToString(result.ToString());
        }
        private void PrintAll(Order order)
        {
            StringBuilder result = new StringBuilder();
            result.Append(@"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'><head></head>");
            result.Append("<body>");
            result.Append($"<h1 align=\"center\">Чек заказа №{order.OrderNumber}</h1>");
            result.Append("<table width=100% border=1 bordercolor=#000 style='border-collapse:collapse;'>");
            result.Append("<tr>");
            result.Append("<th colspan=\"4\">Детали</th>");
            result.Append("</tr>");
            result.Append("<tr>");
            result.Append("<th>Деталь</th>");
            result.Append("<th>Количестов в заказе</th>");
            result.Append("<th>Цена за штуку</th>");
            result.Append("<th>Итоговая цена</th>");
            result.Append("</tr>");
            foreach (var item in order.DetailOfOrder.ToList())
            {
                result.Append("<tr>");
                result.Append($"<td>{item.Detail.Name}</td>");
                result.Append($"<td>{item.Count}</td>");
                result.Append($"<td>{item.Detail.Price}</td>");
                result.Append($"<td>{item.Detail.Price * item.Count}</td>");
                result.Append("</tr>");
            }
            result.Append("<th colspan=\"4\">Услуги</th>");
            result.Append("</tr>");
            result.Append("<tr>");
            result.Append("<th colspan=\"2\">Название</th>");
            result.Append("<th>Цена</th>");
            result.Append("<th colspan=\"2\">Статус услуги</th>");
            result.Append("</tr>");
            foreach (var item in order.ServiceOfOrder.ToList())
            {
                result.Append("<tr>");
                result.Append($"<td colspan=\"2\">{item.Service.Name}</td>");
                result.Append($"<td>{item.Service.Price}</td>");
                result.Append($"<td colspan=\"2\">{item.ServiceOfOrderStatus.Name}</td>");
                result.Append("</tr>");
            }
            result.Append("</table>");
            result.Append($"<p>Заказчик: _______________ {order.Client.FullName}</p>");
            result.Append("</body>");
            result.Append("</html>");
            BrowserMain.NavigateToString(result.ToString());
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var document = BrowserMain.Document as IHTMLDocument2;
            document.execCommand("Print");
        }

        private void ChbPrintAll_Checked(object sender, RoutedEventArgs e)
        {
            PrintAll(order);
        }

        private void ChbPrintAll_Unchecked(object sender, RoutedEventArgs e)
        {
            PrintForClient(order);
        }
    }
}
