using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using ProxyGenerator.ProxyTypeAttributes;
using ProxyGeneratorDemoPage.Models.Person.Interfaces;
using ProxyGeneratorDemoPage.Models.Person.Models;

namespace ProxyGeneratorDemoPage.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IPersonModelBuilder PersonModelBuilder { get; set; }


        public ActionResult Index()
        {
            return View();
        }

        [CreateAngularTsProxy(ReturnType = typeof(void))]
        public ActionResult GetPerson(int id)
        {
            return Json(PersonModelBuilder.GetPerson(id), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy()]
        public ActionResult AddOrUpdatePerson(Person person)
        {
            return Json(PersonModelBuilder.AddOrUpdatePerson(person), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy()]
        public ActionResult GetAllPersons()
        {
            return Json(PersonModelBuilder.GetAllPersons(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(List<Models.Person.Models.Person>))]
        public JsonResult GetAllAutos()
        {
            return Json(PersonModelBuilder.GetAllPersons(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy()]
        public ActionResult SearchPerson(string name)
        {
            return Json(PersonModelBuilder.SearchPerson(name), JsonRequestBehavior.AllowGet);
        }
    }
}