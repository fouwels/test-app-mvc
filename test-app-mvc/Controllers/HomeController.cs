using InterFAX.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace test_app_mvc.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await SendInterFax();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task SendInterFax()
        {
            // Update username/password in web.config to valid credentials first. Otherwise will throw 401:unauthorised

            var username = ConfigurationManager.AppSettings["INTERFAX_USERNAME"];
            var password = ConfigurationManager.AppSettings["INTERFAX_PASSWORD"];
            FaxClient fc = new FaxClient(username, password);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("sample.pdf");
            IFaxDocument ifd = fc.Documents.BuildFaxDocument(filePath);
            SendOptions so = new SendOptions();
            so.FaxNumber = "+99999990";
            so.PageHeader = "test";
            try
            {
                var result = await fc.Outbound.SendFax(ifd, so);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}