using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPageProxyGenerator.Controllers
{
    public class AjaxCallsController : Controller
    {
        public JsonResult GetFullName(string accountName)
        {
            

            return Json("Fullname: " + accountName, JsonRequestBehavior.AllowGet);
        }
    }
}