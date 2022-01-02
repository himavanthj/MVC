using ClosedXML.Excel;
using MVCInterviewDemoProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInterviewDemoProject.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeModel employeeModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(employeeModel.ImageFile.FileName);
            string extension = Path.GetExtension(employeeModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            employeeModel.photo = "~/App_Data/oImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
            employeeModel.ImageFile.SaveAs(fileName);
            return View();
        }

        [HttpGet]
        public ActionResult DownloadExcel()
        {
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "sample.xlsx";
            var stream = new MemoryStream();
            

            var rowNumber = 1;
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("DemoSheet");

            worksheet.Cell(rowNumber, 1).Value = $"Bandi Vamshi Krishna";
            worksheet.Cell(rowNumber, 1).Style.Font.Bold = true;
            worksheet.Range(worksheet.Cell(rowNumber, 1), worksheet.Cell(rowNumber, 3)).Merge();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, contentType, fileName);
        }
    }
}