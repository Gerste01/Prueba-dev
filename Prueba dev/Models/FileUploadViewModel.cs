using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_dev.Models
{
    public class FileUploadViewModel
    {
        public string OcBusqueda { get; set; }

        public StaffInfoViewModel StaffInfoViewModel { get; set; }
        public FileUploadViewModel()
        {
           
            StaffInfoViewModel = new StaffInfoViewModel();
        }
    }
}
