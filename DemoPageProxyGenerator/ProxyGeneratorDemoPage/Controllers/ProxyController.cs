using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGeneratorDemoPage.Controllers
{
    public class ProxyController : Controller
    {
       // [CreateAngularJsProxy(ReturnType = typeof(int))]
        public JsonResult AddAuto(string name, int age)
        {
            return Json(66, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddAnhaenger(string name)
        {
            return Json(name + " ist Anhänger", JsonRequestBehavior.AllowGet);
        }
    }
}