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
        public DateTime? DateTimeOfEnd { get; set; }
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
                if (ServiceOfOrder.Count == 0) return "Выполнен";
                if (ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1) <= ServiceOfOrder.Count
                   && ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 1) != 0)
                {
                    DateTimeOfEnd = null;
                    return "Выполняется";
                }
                else if (ServiceOfOrder.ToList().Count(p => p.ServiceOfOrderStatusId == 3) == ServiceOfOrder.Count)
                {
                    ServiceOfOrder serviceOfOrder = ServiceOfOrder.OrderByDescending(p => p.DateTimeEnd).FirstOrDefault();
                    if (serviceOfOrder != null)
                        DateTimeOfEnd = serviceOfOrder.DateTimeEnd;
                    else
                        DateTimeOfEnd = DateTimeOfCreate;
                    return "Отменён";
                }
                else
                {
                    ServiceOfOrder serviceOfOrder = ServiceOfOrder.OrderByDescending(p => p.DateTimeEnd).FirstOrDefault();
                    if (serviceOfOrder != null)
                        DateTimeOfEnd = serviceOfOrder.DateTimeEnd;
                    else
                        DateTimeOfEnd = DateTimeOfCreate;
                    return "Выполнен";
                }
            }
        }
        public Brush StatusOfOrderBrush
        {
            get
            {
                if (ServiceOfOrder.Count == 0) return Brushes.Green;
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
                return $"{DateTimeOfEnd:dd.MM.yyyy HH:mm}";
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return ServiceOfOrder.ToList().Where(p=>p.ServiceOfOrderStatusId!=3).ToList()
                    .Sum(p => p.Service.Price) + DetailOfOrder.Sum(p=>p.Count*p.Detail.Price);
            }
        }
    }
}
