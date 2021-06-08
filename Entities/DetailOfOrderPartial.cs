using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Center.Entities
{
    public partial class DetailOfOrder
    {
        public string NameCount
        {
            get
            {
                return $"{Detail.Name} ({Count})";
            }
        }
    }
}
