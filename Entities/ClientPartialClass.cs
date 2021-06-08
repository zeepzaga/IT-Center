using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Center.Entities
{
    public partial class Client
    {
        public string FullName
        {
            get
            {
                return $"{LastName} {FIrstName} {MiddleName}";
            }
        }
    }
}
