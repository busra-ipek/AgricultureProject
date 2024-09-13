using AgricultureProject.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgricultureProject.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            //Nuget paketlerden EPplus adında yeni bir paket eklenir. Bu paketlerle excel paketlerini kullanabiliriz.

            ExcelPackage excelPackage = new ExcelPackage();

            var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");
            //Dosya1 adında bir çalışma dosyası eklenir.

            //Bu şekilde verileri statik olarak ekleriz.
            workbook.Cells[1, 1].Value = "Ürün Adı";
            workbook.Cells[1, 2].Value = "Ürün Kategorisi";
            workbook.Cells[1, 3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "Mercimek";
            workbook.Cells[2, 2].Value = "Bakliyat";
            workbook.Cells[2, 3].Value = "785 kg";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "1 986 kg";

            workbook.Cells[4, 1].Value = "Havuç";
            workbook.Cells[4, 2].Value = "Sebze";
            workbook.Cells[4, 3].Value = "167 kg";

            var bytes = excelPackage.GetAsByteArray();
            /*EPPlus kütüphanesi kullanılarak oluşturulan bir Excel dosyasını byte dizisi (byte[]) olarak bellekte
            almanızı sağlar. Bu, Excel dosyasını fiziksel bir dosya olarak kaydetmek yerine, doğrudan bellek
            üzerinde bir byte dizisi olarak kullanmanıza olanak tanır. Özellikle, dosyayı indirmek veya bir web
            API üzerinden istemciye göndermek gibi işlemler için kullanışlıdır.*/

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Excel dosyaları için belirlenmiş türdür.

            string fileName = "BakliyatRaporu.xlsx";
            //Excel dosyasının adıdır.

            return File(bytes, contentType, fileName);

            //File() metodu dosya indirme veya gösterme amacıyla kullanılır.ASP.NET Core'da return File() metodu, Controller
            //sınıfının bir parçasıdır ve dosya indirilebilir bir yanıt olarak döndürülür.

        }

        public List<ContactModel> ContactList() //Contactmodel classsından ContactList adında bir liste oluşturulur.
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName = x.Name,
                    ContactMessage = x.Message,
                    ContactMail = x.Mail,
                    ContactDate = x.Date,

                }).ToList();
            }
            return contactModels;
        }

        public IActionResult ContactReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Mesaj Listesi");
                worksheet.Cell(1, 1).Value = "Mesaj ID"; //Excelin sütun isimleri tek tek yazılır.
                worksheet.Cell(1, 2).Value = "Mesajı Gönderen";
                worksheet.Cell(1, 3).Value = "Mail Adresi";
                worksheet.Cell(1, 4).Value = "Mesaj İçeriği";
                worksheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2; //bu değişken bize stır sayısı vericek. 2.satırdan itibaren veriler Excele kaydedilecek.
                foreach (var item in ContactList())
                {
                    worksheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    worksheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    worksheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    worksheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    worksheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                    //Contact tablosunun tüm satırları okunana kadar artmaya devam eder.
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    string contentTypeMessage = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileNameMessage = "MesajRapor.xlsx";

                    return File(content, contentTypeMessage, fileNameMessage);
                }
            }
        }

        //ContactReport için ne yaptıysak aynısını AnnouncementReport için de yaparız.
        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncementID = x.AnnouncementID,
                    AnnouncementTitle = x.Title,
                    AnnouncementDescription = x.Description,
                    AnnouncementStatus = x.Status,
                    AnnouncementDate = x.Date,

                }).ToList();
            }
            return announcementModels;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Duyuru Listesi");
                worksheet.Cell(1, 1).Value = "Duyuru ID";
                worksheet.Cell(1, 2).Value = "Duyuru Başlığı";
                worksheet.Cell(1, 3).Value = "Duyuru Tarihi";
                worksheet.Cell(1, 4).Value = "Duyuru İçeriği";
                worksheet.Cell(1, 5).Value = "Durum";

                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    worksheet.Cell(announcementRowCount, 1).Value = item.AnnouncementID;
                    worksheet.Cell(announcementRowCount, 2).Value = item.AnnouncementTitle;
                    worksheet.Cell(announcementRowCount, 3).Value = item.AnnouncementDate;
                    worksheet.Cell(announcementRowCount, 4).Value = item.AnnouncementDescription;
                    worksheet.Cell(announcementRowCount, 5).Value = item.AnnouncementStatus;
                    announcementRowCount++;
                    //Contact tablosunun tüm satırları okunana kadar artmaya devam eder.
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    string contentTypeMessage = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileNameMessage = "DuyuruRapor.xlsx";

                    return File(content, contentTypeMessage, fileNameMessage);
                }
            }
        }


    }
}