using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IT_Center.Entities
{
    public partial class Order
    {
        public string OrderNumber
        {
            get
            {
                int countNull = 5 - Id.ToString().Length;
                string result = "";
                for (int i = 0; i < countNull; i++)
                {
                    result += "0";
                }
                return result += Id.ToString();
            }
        }
        public int ServiceCount
        {
            get
            {
                return ServiceOfOrder.Count;
            }
        }
        public int DetailCount
        {
            get
            {
                int result = 0;
                foreach (var item in DetailOfOrder)
                {
                    result += item.Count;
                }
                return result;
            }
        }
        public string StatusOfOrder
        {
            get
            {
                if (ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1) <= ServiceOfOrder.Count
                   && ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1) != 0)
                    return "Выполняется";
                else if (ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 3) == ServiceOfOrder.Count)
                    return "Отменён";
                else
                    return "Выполнен";
            }
        }
        public Brush StatusOfOrderBrush
        {
            get
            {
                if (ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1) <= ServiceOfOrder.Count
                    && ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1) != 0)
                    return Brushes.Orange;
                else if (ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 3) == ServiceOfOrder.Count)
                    return Brushes.Red;
                else
                    return Brushes.Green;
            }
        }
        public string DateTimeOfEndString
        {
            get
            {
                if (DateTimeOfEnd == null)
                    return "";
                return $"{DateTimeOfEnd:dd.mm.yyyy mm:hh}";
            }
        }
    }
}
