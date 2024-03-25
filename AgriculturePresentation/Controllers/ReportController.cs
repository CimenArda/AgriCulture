using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workbook.Cells[1, 1].Value = "Ürün Adı";
            workbook.Cells[1, 2].Value = "Ürün Kategorisi";
            workbook.Cells[1, 3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "Mercimek";
            workbook.Cells[2, 2].Value = "Bakliyat";
            workbook.Cells[2, 3].Value = "785 KG";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "1.982 KG";

            workbook.Cells[4, 1].Value = "Havuç";
            workbook.Cells[4, 2].Value = "Sebze";
            workbook.Cells[4, 3].Value = "167 KG";


            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx"); 

            //epplus artık lisans veriyor paralı o yüzden bu kısım lisans eklemesi yaptıktan sonra calısır.
           
        }


        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using(var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    ID=x.AnnouncementID,
                    Status=x.Status,
                    Date=x.Date,
                    Description=x.Description,
                    Title = x.Title
                }).ToList();
            }
            return announcementModels;
        }
        public IActionResult AnnouncementReport()
        {
            using (var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Duyuru Listesi");
                worksheet.Cell(1, 1).Value = "Duyuru ID";
                worksheet.Cell(1, 2).Value = "Duyuru Durumu";
                worksheet.Cell(1, 3).Value = "Duyuru Tarihi";
                worksheet.Cell(1, 4).Value = "Duyuru Açıklaması";
                worksheet.Cell(1, 5).Value = "Duyuru Başlığı";

                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    worksheet.Cell(announcementRowCount, 1).Value = item.ID;
                    worksheet.Cell(announcementRowCount, 2).Value = item.Status;
                    worksheet.Cell(announcementRowCount, 3).Value = item.Date;
                    worksheet.Cell(announcementRowCount, 4).Value = item.Description;
                    worksheet.Cell(announcementRowCount, 5).Value = item.Title;
                    announcementRowCount++;
                }

                using(var stream =new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content =stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRapor.xlsx");
                }




            }
        }







    }
}