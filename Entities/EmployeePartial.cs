using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Center.Entities
{
    public partial class Employee
    {
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }
        public string Status
        {
            get
            {
                if (IsWork == true)
                    return "Работает";
                return "Уволен";
            }
        }
    }
}
