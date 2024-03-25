using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgriculturePresentation.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {

            List<ProductClass> products = new List<ProductClass>();
            products.Add(new ProductClass
            {
                productName = "Buğday",
                productValue=850

            });
            products.Add(new ProductClass
            {
                productName = "Mercimek",
                productValue = 500

            });
            products.Add(new ProductClass
            {
                productName = "Arpa",
                productValue = 280

            });
            products.Add(new ProductClass
            {
                productName = "Pirinç",
                productValue = 400

            });
            products.Add(new ProductClass
            {
                productName = "Domates",
                productValue = 775

            });

            return Json(new { jsonlist = products });
        }



    }
}
