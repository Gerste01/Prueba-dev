using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_dev.Models
{
    public class StaffInfoViewModel
    {
        public string Oc { get; set; }
        public string F12 { get; set; }
        public string Sku { get; set; }
        public string Cc { get; set; }
        public string Estado { get; set; }

       

        public List<StaffInfoViewModel> StaffList { get; set; }
        public StaffInfoViewModel()
        {
            StaffList = new List<StaffInfoViewModel>();
        }
    }
}
