﻿using ClosedXML.Excel;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class ReportController : Controller
    {
        [AllowAnonymous] //giriş yapmayla uğraşmamak amacıyla

        //static excel listesi

        public IActionResult ReportList()
        {
            return View();
        }
        public IActionResult ExcelStatic()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Personel ID";
            workSheet.Cells[1, 2].Value = "Personel Name";
            workSheet.Cells[1, 3].Value = "Personel Surname";

            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "Tuba";
            workSheet.Cells[2, 3].Value = "Zorlu";

            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "Serap";
            workSheet.Cells[3, 3].Value = "Beran";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","personnels.xlsx");



        }

        public List<CustomerViewModel> CustomerList()
        {
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            using (var context = new Context())
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel { Mail = x.CustomerMail, Name = x.CustomerName, Surname = x.CustomerSurname, Phone = x.CustomerPhone }).ToList();
                return customerViewModels;
            }
        }
        public IActionResult DynamicExcel()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Müşteri");
                workSheet.Cell(1, 1).Value = "Mail Adresi";
                workSheet.Cell(1, 2).Value = "Müşteri Adresi";
                workSheet.Cell(1, 3).Value = "Müşteri Soyadı";
                workSheet.Cell(1, 4).Value = "Müşteri Telefon";

                int rowCount = 2;
                foreach(var item in CustomerList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Mail;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Phone;
                    rowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream); //akışın içerisne workbooktan gelen değer
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "personnels.xlsx");
                }

                //workBook= excel dosyası Sheet=çalışılan sayfa
            }
            return View();

        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "Musteri.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Hallo Hallo");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReports/Musteri.Pdf", "application/pdf", "Musteri.pdf");
        }
    

    }
}
