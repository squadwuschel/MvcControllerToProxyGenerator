using System.Web.Mvc;
using Ninject;
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

        public ActionResult GetPerson(int id)
        {
            return Json(PersonModelBuilder.GetPerson(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrUpdatePerson(Person person)
        {
            return Json(PersonModelBuilder.AddOrUpdatePerson(person), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPersons()
        {
            return Json(PersonModelBuilder.GetAllPersons(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchPerson(string name)
        {
            return Json(PersonModelBuilder.SearchPerson(name), JsonRequestBehavior.AllowGet);
        }
    }
}