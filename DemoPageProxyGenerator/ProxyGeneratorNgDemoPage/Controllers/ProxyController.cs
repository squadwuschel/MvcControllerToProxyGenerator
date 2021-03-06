﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProxyGenerator.ProxyTypeAttributes;
using Auto = ProxyGeneratorNgDemoPage.Models.Auto;
using ClientAccess = ProxyGeneratorNgDemoPage.Models.ClientAccess;
using Company = ProxyGeneratorNgDemoPage.Models.Company;
using Person = ProxyGeneratorNgDemoPage.Models.Person;

namespace ProxyGeneratorNgDemoPage.Controllers
{
    public class ProxyController : Controller
    {
        #region File Upload
        /// <summary>
        /// Kein Attribut zum Erstellen des Proxies hinzufügen, hier muss der Service von Hand gebaut werden!
        /// </summary>
        [CreateAngular2TsProxy(ReturnType = typeof(Person))]
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
        [CreateAngular2TsProxy(ReturnType = typeof(void))]
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
        [CreateAngular2TsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadPerson(int personId)
        {
            var fileContent = Encoding.ASCII.GetBytes($"Das ist ein Test Download für die PersonId: {personId}");
            return File(fileContent, "text/text", "TestDL.txt");
        }

        [CreateAngular2TsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadCompany(int companyId)
        {
            var fileContent = Encoding.ASCII.GetBytes($"Das ist ein Test Download für die CompanyID: {companyId}");
            return File(fileContent, "text/text", "TestDL.txt");
        }

        [CreateAngular2TsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadSimple(int companyId, string name)
        {
            var fileContent = Encoding.ASCII.GetBytes($"Das ist ein Test Download für die CompanyId: {companyId} mit dem Namen: {name}");
            return File(fileContent, "text/text", "TestDL.txt");
        }

        [CreateAngular2TsProxy(CreateWindowLocationHrefLink = true)]
        public FileResult GetDownloadNoParams()
        {
            var fileContent = Encoding.ASCII.GetBytes("Das ist ein Test Download Ohne Parameter");
            return File(fileContent, "text/text", "TestDL.txt");
        }
        #endregion

        #region AngularJs Proxy Methods Examples
        [CreateAngular2TsProxy(ReturnType = typeof(Person))]
        public JsonResult ManySimpleParams(int page, int size, byte? sortedCol, byte? desc, string smCompany, int? smCustomerNumber, string smEmail, string smLastname, int? portal, int count)
        {
            return Json(new Person() { Id = count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region AngularTs and jQuery Ts Proxy Methods Examples
        [CreateAngular2TsProxy(ReturnType = typeof(List<int>))]
        public ActionResult AddAges(List<int> ages)
        {
            return Json(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, JsonRequestBehavior.AllowGet);
        }

        //You can create multiple Proxies for the same function
        [CreateAngular2TsProxy(ReturnType = typeof(Person))]
        public JsonResult AddTsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke = name }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [CreateAngular2TsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallById(int id)
        {
            return Json(new Person() { Id = id }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallByParams(string name, string vorname, int alter)
        {
            return Json(new Person() { Name = name, Id = alter }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsAndId(string name, string vorname, int alter, int id)
        {
            return Json(new Auto() { Alter = alter, Marke = name }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsWithEnum(string name, string vorname, int alter, ClientAccess access)
        {
            return Json(new Auto() { Marke = name, Alter = alter }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(List<Auto>))]
        public JsonResult LoadAllAutosListe(string name)
        {
            return Json(new List<Auto>() { new Auto() { Marke = name }, new Auto() }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Auto[]))]
        public JsonResult LoadAllAutosArray(string name)
        {
            return Json(new List<Auto>() { new Auto() { Marke = name }, new Auto() }.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Person))]
        public JsonResult ClearTsCall()
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(void))]
        public JsonResult VoidTsReturnType(string name)
        {
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(string))]
        public JsonResult StringTsReturnType(string name)
        {
            return Json(name, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(int))]
        public JsonResult IntegerTsReturnType(int age)
        {
            return Json(age, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(DateTime))]
        public JsonResult DateTsReturnType(string name)
        {
            return Json(DateTime.Now, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(Boolean))]
        public JsonResult BoolTsReturnType(bool boolValue)
        {
            return Json(boolValue, JsonRequestBehavior.AllowGet);
        }

        [CreateAngular2TsProxy(ReturnType = typeof(string))]
        public ActionResult ErrorStringReturnType(bool boolValue)
        {
            //Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Error 1", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
