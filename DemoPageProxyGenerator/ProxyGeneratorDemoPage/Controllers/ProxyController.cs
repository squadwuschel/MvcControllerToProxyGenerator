using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        #endregion

        #region File Upload
        /// <summary>
        /// Kein Attribut zum Erstellen des Proxies hinzufügen, hier muss der Service von Hand gebaut werden!
        /// </summary>
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public ActionResult AddFileToServer(HttpPostedFileBase dateiname, int detailId)
        {
            if (dateiname == null)
            {   
                throw new Exception("File Upload is Null");
            }

            return Json(new Person() { Id = detailId}, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AngularJs Proxy Methods Examples
        [CreateJQueryJsProxy]
        [CreateAngularJsProxy]
        public JsonResult AddJsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
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

        #region AngularTs Proxy Methods Examples
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
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Error 1", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
