using System.Web;
using System.Web.Mvc;
using BusinessLogicApi;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        public IVersionControlService VersionControlService { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0 ||
                !file.FileName.ToLower().EndsWith(".dll"))
            {
                return View("Error", (object)@"Uploaded file is empty or is not *.dll");
            }
            var records = VersionControlService.Save(file.InputStream, file.FileName);
            var model = new VersioningHistoryViewModel
            {
                Records = records,
                AssemblyName = file.FileName
            };
            return View("VersioningHistory", model);
        }
    }
}
