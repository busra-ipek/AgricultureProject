﻿using AgricultureProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            //Bu şekilde liste yapmak yerine Product tablosu ekleyep verileri tablodan çekebilirdin.
            List<ProductClass> productClasses = new List<ProductClass>();

            productClasses.Add(new ProductClass
            {
                productname = "Buğday",
                productvalue = 850

            });

            productClasses.Add(new ProductClass
            {
                productname = "Mercimek",
                productvalue = 480

            });

            productClasses.Add(new ProductClass
            {
                productname = "Arpa",
                productvalue = 250

            });

            productClasses.Add(new ProductClass
            {
                productname = "Pirinç",
                productvalue = 130

            });

            productClasses.Add(new ProductClass
            {
                productname = "Domates",
                productvalue = 935

            });

            return Json(new { jsonlist = productClasses }); //Json metodu verileri grafiğe aktarabilmek için kullanılann bir metottur.
        }
    }
}
