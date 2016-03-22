using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Ninject;
using ProxyGenerator.ProxyTypeAttributes;
using ProxyGeneratorDemoPage.Models.Person.Models;

namespace ProxyGeneratorDemoPage.Controllers
{
    public class HomeController : Controller
    {
        [CreateAngularTsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownload(int personId, Person person)
        {
            var fileContent = Encoding.ASCII.GetBytes("Das ist ein Test Download");
            return File(fileContent, "text/text", "TestDL.txt");
        }

        [CreateAngularTsProxy(ReturnType = typeof(void))]
        public ActionResult GetPerson(int id)
        {
            return Json(new Person() {Id = id}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy()]
        public ActionResult AddOrUpdatePerson(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy()]
        public ActionResult GetAllPersons()
        {
            return Json(new List<Person>() {new Person()}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(List<Models.Person.Models.Person>))]
        public JsonResult GetAllAutos()
        {
            return Json(new List<Auto>() { new Auto()}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy()]
        public ActionResult SearchPerson(string name)
        {
            return Json(new Person() { Name = name}, JsonRequestBehavior.AllowGet);
        }
    }
}