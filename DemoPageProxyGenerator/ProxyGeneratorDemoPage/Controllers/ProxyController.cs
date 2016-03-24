using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProxyGenerator.ProxyTypeAttributes;
using ProxyGeneratorDemoPage.Helper;
using ProxyGeneratorDemoPage.Models.Person.Models;

namespace ProxyGeneratorDemoPage.Controllers
{
    public class ProxyController : Controller
    {
        #region Views
        public ActionResult AngularCalls()
        {
            return View();
        }

        public ActionResult JQueryCalls()
        {
            return View();
        }

        [CreateJQueryTsProxy(ReturnType = typeof(string))]
        public ActionResult TestView()
        {
            return View();
        }
        #endregion

        #region File Upload
        /// <summary>
        /// Kein Attribut zum Erstellen des Proxies hinzufügen, hier muss der Service von Hand gebaut werden!
        /// </summary>
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        [CreateAngularJsProxy]
        [CreateJQueryJsProxy]
        public ActionResult AddFileToServer(HttpPostedFileBase datei, int detailId)
        {
            if (datei == null)
            {
                throw new Exception("File Upload is Null");
            }

            //Speichern der Hochgeladenen Datei im C:\Temp\ Verzeichnis dort können wir dann prüfen ob die Datei auch "richtig" hochgeladen wurde.
            byte[] buffer = new byte[datei.ContentLength];
            datei.InputStream.Read(buffer, 0, datei.ContentLength);

            System.IO.File.WriteAllBytes(string.Format(@"C:\Temp\{0}", System.IO.Path.GetFileName(datei.FileName)), buffer);

            return Json(new Person() { Id = detailId }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Kein Attribut zum Erstellen des Proxies hinzufügen, hier muss der Service von Hand gebaut werden!
        /// </summary>
        [CreateAngularTsProxy(ReturnType = typeof(void))]
        [CreateJQueryTsProxy(ReturnType = typeof(void))]
        [CreateAngularJsProxy()]
        [CreateJQueryJsProxy]
        public ActionResult AddFileToServerNoReturnType(HttpPostedFileBase datei, int detailId)
        {
            if (datei == null)
            {
                throw new Exception("File Upload is Null");
            }

            //Speichern der Hochgeladenen Datei im C:\Temp\ Verzeichnis dort können wir dann prüfen ob die Datei auch "richtig" hochgeladen wurde.
            byte[] buffer = new byte[datei.ContentLength];
            datei.InputStream.Read(buffer, 0, datei.ContentLength);
            System.IO.File.WriteAllBytes(string.Format(@"C:\Temp\{0}", System.IO.Path.GetFileName(datei.FileName)), buffer);

            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HrefLinks for Downloads
        [CreateAngularTsProxy(CreateWindowLocationHrefLink = true)]
        [CreateAngularJsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadPerson(int personId, Person person)
        {
            var fileContent = Encoding.ASCII.GetBytes(string.Format("Das ist ein Test Download für die Person: {0} mit dem Passwort: {1} und der ID: {2}", person.Name, person.Passwort, personId));
            return File(fileContent, "text/text", "TestDL.txt");
        }

        [CreateAngularTsProxy(CreateWindowLocationHrefLink = true)]
        [CreateAngularJsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadCompany(int companyId, Company company)
        {
            var fileContent = Encoding.ASCII.GetBytes(string.Format("Das ist ein Test Download für die Company: {0} mit dem ClientAccess: {1} und der ID: {2}", company.Name, company.ClientAccess, company));
            return File(fileContent, "text/text", "TestDL.txt");
        }

        [CreateAngularTsProxy(CreateWindowLocationHrefLink = true)]
        [CreateAngularJsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadSimple(int companyId, string name)
        {
            var fileContent = Encoding.ASCII.GetBytes(string.Format("Das ist ein Test Download für die CompanyId: {0} mit dem Namen: {1}", companyId, name));
            return File(fileContent, "text/text", "TestDL.txt");
        }
        #endregion

        #region AngularJs Proxy Methods Examples
        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult AddJsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        public JsonResult ManySimpleParams(int page, int size, byte? sortedCol, byte? desc, string smCompany, int? smCustomerNumber, string smEmail, string smLastname, int? portal, int count)
        {
            return Json(new Person() { Id = count }, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult AddJsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke =  name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult AddJsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult ClearJsCall()
        {
            return Json("ClearJsCall was Called", JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult LoadJsCallById(int id)
        {
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParams(string name, string vorname, int alter)
        {
            return Json(vorname, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParamsAndId(string name, string vorname, int alter, int id)
        {
            return Json(new Person() { Name = name, Id = id}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParamsWithEnum(string name, string vorname, int alter, ClientAccess access)
        {
            return Json(new Person() { Name = name, Id = alter}, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        #region AngularTs and jQuery Ts Proxy Methods Examples
        [CreateAngularTsProxy(ReturnType = typeof(List<int>))]
        [CreateJQueryTsProxy(ReturnType = typeof(List<int>))]
        public ActionResult AddAges(List<int> ages)
        {
            return Json(new List<int>() {1, 2, 3, 4, 5, 6, 7, 8}, JsonRequestBehavior.AllowGet);
        }

        //You can create multiple Proxies for the same function
        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult AddTsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Auto))]
        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [CreateJQueryTsProxy(ReturnType = typeof(Auto))]
        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallById(int id)
        {
            return Json(new Person() { Id = id}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallByParams(string name, string vorname, int alter)
        {
            return Json(new Person() { Name = name, Id = alter}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Auto))]
        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsAndId(string name, string vorname, int alter, int id)
        {
            return Json(new Auto() { Alter = alter, Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Auto))]
        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsWithEnum(string name, string vorname, int alter, ClientAccess access)
        {
            return Json(new Auto() { Marke = name, Alter = alter}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(List<Auto>))]
        [CreateAngularTsProxy(ReturnType = typeof(List<Auto>))]
        public JsonResult LoadAllAutosListe(string name)
        {
            return Json(new List<Auto>() { new Auto() { Marke = name}, new Auto() }, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Auto[]))]
        [CreateAngularTsProxy(ReturnType = typeof(Auto[]))]
        public JsonResult LoadAllAutosArray(string name)
        {
            return Json(new List<Auto>() { new Auto() { Marke = name}, new Auto() }.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult ClearTsCall()
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(void))]
        [CreateAngularTsProxy(ReturnType = typeof(void))]
        public JsonResult VoidTsReturnType(string name)
        {
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(string))]
        [CreateAngularTsProxy(ReturnType = typeof(string))]
        public JsonResult StringTsReturnType(string name)
        {
            return Json(name, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(int))]
        [CreateAngularTsProxy(ReturnType = typeof(int))]
        public JsonResult IntegerTsReturnType(int age)
        {
            return Json(age, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(DateTime))]
        [CreateAngularTsProxy(ReturnType = typeof(DateTime))]
        public JsonResult DateTsReturnType(string name)
        {
            return Json(DateTime.Now, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Boolean))]
        [CreateAngularTsProxy(ReturnType = typeof(Boolean))]
        public JsonResult BoolTsReturnType(bool boolValue)
        {
            return Json(boolValue, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(string))]
        [CreateAngularTsProxy(ReturnType = typeof(string))]
        public ActionResult ErrorStringReturnType(bool boolValue)
        {
            //Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Error 1", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
