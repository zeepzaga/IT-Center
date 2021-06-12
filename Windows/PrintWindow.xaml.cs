using IT_Center.Entities;
using mshtml;
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
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        public PrintWindow(Order order)
        {
            InitializeComponent();

            String result = Properties.Resources.Kvitok.ToString();
            StringBuilder ServicesDevices = new StringBuilder();

            if (order.DetailOfOrder.Count != 0)
            {
                ServicesDevices.Append("<tr class=\"row8\"> <td class=\"column1 style10 s style12\" colspan=\"4\">Детали</td>");
                ServicesDevices.Append("<td class=\"column6 style1 null\"></td>");
                ServicesDevices.Append("<td class=\"column7 style1 null\"></td></tr>");
                ServicesDevices.Append("<tr class=\"row9\"><td class=\"column1 style3 s\">Деталь</td>");
                ServicesDevices.Append("<td class=\"column2 style3 s\">Количество в заказе</td>");
                ServicesDevices.Append("<td class=\"column3 style3 s\">Цена за штуку</td>");
                ServicesDevices.Append("<td class=\"column4 style3 s\">Итоговая цена</td></tr>");
                foreach (var item in order.DetailOfOrder.ToList())
                {
                    ServicesDevices.Append("<tr class=\"row10\">");
                    ServicesDevices.Append($"<td class=\"column1 style7 s\">{item.Detail.Name}</td>");
                    ServicesDevices.Append($"<td class=\"column2 style8 n\">{item.Count}</td>");
                    ServicesDevices.Append($"<td class=\"column3 style8 n\">{item.Detail.Price} р.</td>");
                    ServicesDevices.Append($"<td class=\"column4 style8 n\">{item.Detail.Price * item.Count} р.</td>");
                    ServicesDevices.Append("</tr>");
                }
            }
            if (order.ServiceOfOrder.Count != 0)
            {
                ServicesDevices.Append("<tr class=\"row5\">");
                ServicesDevices.Append("<td class=\"column1 style10 s style12\" colspan=\"4\">Услуги</td></tr>");
                ServicesDevices.Append("<tr class=\"row6\">");
                ServicesDevices.Append("<td class=\"column1 style10 s style12\" colspan=\"3\">Название</td>");
                ServicesDevices.Append("<td class=\"column3 style10 s style12\">Цена</td>");
                ServicesDevices.Append("</tr>");
                foreach (var item in order.ServiceOfOrder.ToList().Where(p => p.ServiceOfOrderStatusId != 3).ToList())
                {
                    ServicesDevices.Append("<tr class=\"row7\">");
                    ServicesDevices.Append($"<td class=\"column1 style13 s style14\" colspan=\"3\">{item.Service.Name}</td>");
                    ServicesDevices.Append($"<td class=\"column3 style15 n style16\">{item.Service.Price} р.</td>");
                    ServicesDevices.Append("</tr>");
                }
            }

            result = result.Replace("DATA", ServicesDevices.ToString());
            result = result.Replace("ClientName", order.Client.FullName);
            result = result.Replace("ClientTelephone", order.Client.TelephoneNumber);
            result = result.Replace("ClientEmail", order.Client.Email);
            result = result.Replace("OrderName", order.Description);
            result = result.Replace("DateOrder", order.DateTimeOfCreate.ToString("dd.MM.yyyy"));
            result = result.Replace("WorkerName", order.Employee.FullName);
            result = result.Replace("OrderNumber", order.OrderNumber);

            BrowserMain.NavigateToString(result);
        }
        
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var document = BrowserMain.Document as IHTMLDocument2;
            document.execCommand("Print");
        }
    }
}
