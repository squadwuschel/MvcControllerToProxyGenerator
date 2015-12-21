using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProxyGenerator.ProxyTypeAttributes;
using ProxyGeneratorDemoPage.Helper;
using ProxyGeneratorDemoPage.Models.Person.Models;

namespace ProxyGeneratorDemoPage.Controllers
{
    public class ProxyController : Controller
    {
        #region AngularJs Proxy Methods Examples
        [CreateAngularJsProxy]
        public JsonResult AddJsEntryOnly(Person person)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult AddJsEntryAndName(Person person, string name)
        {
            return Json(new Auto(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult AddJsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult ClearJsCall()
        {
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult LoadJsCallById(int id)
        {
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParams(string name, string vorname, int alter)
        {
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParamsAndId(string name, string vorname, int alter, int id)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParamsWithEnum(string name, string vorname, int alter, ClientAccess access)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AngularTs Proxy Methods Examples
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult AddTsEntryOnly(Person person)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndName(Person person, string name)
        {
            return Json(new Auto(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallById(int id)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallByParams(string name, string vorname, int alter)
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsAndId(string name, string vorname, int alter, int id)
        {
            return Json(new Auto(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsWithEnum(string name, string vorname, int alter, ClientAccess access)
        {
            return Json(new Auto(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(List<Auto>))]
        public JsonResult LoadAllAutosListe(string name)
        {
            return Json(new List<Auto>() { new Auto(), new Auto() }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto[]))]
        public JsonResult LoadAllAutosArray(string name)
        {
            return Json(new List<Auto>() { new Auto(), new Auto() }.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult ClearTsCall()
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(void))]
        public JsonResult VoidTsReturnType(string name)
        {
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(string))]
        public JsonResult StringTsReturnType(string name)
        {
            return Json("LEERER STRING", JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(int))]
        public JsonResult IntegerTsReturnType(string name)
        {
            return Json(1337, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(long))]
        public JsonResult DateTsReturnType(string name)
        {
            return Json(1232321223, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Boolean))]
        public JsonResult BoolTsReturnType(string name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
