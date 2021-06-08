using IT_Center.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Center
{
    public class AppData
    {
        public static ITCenterEntities Context = new ITCenterEntities();
        public static Employee currentEmployee;
    }
}
