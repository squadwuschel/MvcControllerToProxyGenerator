using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProxyGenerator.ProxyTypeAttributes;
using ProxyGeneratorDemoPage.Models.Person.Models;

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

        [CreateAngularTsProxy(ReturnType = typeof(List<Models.Person.Models.Person>))]
        public ActionResult GetAllPersons(string name)
        {
            return Json(new List<Person>(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public ActionResult AddOrUpdatePerson(Person person, string test)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }
    }
}