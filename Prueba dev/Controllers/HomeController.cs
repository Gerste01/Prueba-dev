using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using Prueba_dev.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_dev.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult File()
        {
            FileUploadViewModel model = new FileUploadViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult File(FileUploadViewModel model)
        {


            FileInfo file = new FileInfo(Path.GetFullPath("Datos.xlsx"));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(file))
            {

                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                {

                }
                else
                {

                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[row, 1].Value.ToString() == model.OcBusqueda || worksheet.Cells[row, 2].Value.ToString() == model.OcBusqueda)
                        {
                            model.StaffInfoViewModel.StaffList.Add(new StaffInfoViewModel
                            {
                                Oc = (worksheet.Cells[row, 1].Value ?? string.Empty).ToString().Trim(),
                                F12 = (worksheet.Cells[row, 2].Value ?? string.Empty).ToString().Trim(),
                                Sku = (worksheet.Cells[row, 3].Value ?? string.Empty).ToString().Trim(),
                                Cc = (worksheet.Cells[row, 4].Value ?? string.Empty).ToString().Trim(),
                                Estado = (worksheet.Cells[row, 5].Value ?? string.Empty).ToString().Trim(),
                            });

                        }

                    }
                }

                return View(model);
            }
        }
    }
}
