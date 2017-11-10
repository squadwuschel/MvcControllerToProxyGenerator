using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProxyGeneratorNgDemoPage.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            //die Index.html wird von WebPack in das Verzeichnis kopiert und die Standardroute 
            //lädt dann automatisch die index.html
            return new FilePathResult("~/wwwroot/index.html", "text/html");
        }
    }
}