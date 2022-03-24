using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TSWorksBusinessLayer;
using TSWorksBusinessLayer.Models;

namespace TSWorksServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppleController : Controller
    {
        BusinessLayer BL;

        public AppleController()
        {
            BL = new BusinessLayer();
        }

        [HttpGet]
        public JsonResult GetAppleData(string date)
        {
            return Json(BL.GetAppleData(date));
        }

        [HttpGet]
        public JsonResult GetAllAppleData()
        {
            return Json(BL.GetAllAppleData());
        }

        [HttpGet]
        public JsonResult get()
        {
            return Json(1);
        }

        [HttpPost]
        [Obsolete]
        public  IActionResult PostData(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            #region Upload CSV
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            #endregion

            var apple = this.GetAppleList(fileName);
             return Json(BL.PostAppleData(apple));
        }

        private List<AppleData> GetAppleList(string fileName)
        {
            List<AppleData> appleDatasBL = new List<AppleData>();
            AppleData apl = new AppleData();

            List<Models.AppleData> apples = new List<Models.AppleData>();
            #region Read CSV
            var path = $"C:" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while(csv.Read())
                {
                    apl = csv.GetRecord<AppleData>();
                    appleDatasBL.Add(apl);
                }
            }
            #endregion
            return appleDatasBL;

        }


    }
}
