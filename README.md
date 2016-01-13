# MvcControllerToProxyGenerator
Creates JavaScript or TypeScript AJAX proxies in jQuery or AngularJs for .NET Controller or WebApi functions.

You can download and install the [NuGet package for "TypeScriptAngularJsProxyGenerator"](https://www.nuget.org/packages/TypeScriptAngularJsProxyGenerator/).

---------
## The NuGet Package "TypeScriptAngularJsProxyGenerator"
The package installs a T4 Template into your WebProject under the path

`ControllersProxies\ProxyGeneratorScript.tt`

and adds a refrence to a installed DLL named

`ProxyGenerator.dll`

which is set in the T4 template as needed reference.

The NuGet package also installs the depended [NuGet Package "Microsoft.VisualStudio.TextTemplating.14.0"](https://www.nuget.org/packages/Microsoft.VisualStudio.TextTemplating.14.0/).

If you want to **create TypeScript proxies** then, you **need to install manually** the [NuGet Package for TypeLite](https://www.nuget.org/packages/TypeLite/)

(If you use TypeScript don't forget to install the TypeDefinitions for jQuery and/or AngularJs)

## T4 Configruation Settings
When you have installed all needed NuGet Packages, you **need to configure** the T4 Tempalte `ProxyGeneratorScript.tt` in its config Section **"SETTINGS for MANUAL adjustments"**.
Here you have to set the name of your current WebPoject.

	settings.WebProjectName = "ProxyGeneratorDemoPage";

If you want to create a TypeScript Proxy, don't forget to install TypeLite and you need to edit the TypeLite T4 Template with the following line:

    .WithFormatter((type, f) => "I" + ((TypeLite.TsModels.TsClass)type).Name)

or if you use the original TypeLite Interface name without the "I" then, you need to remove the "I" from my T4 Template.
     
    settings.TypeLiteInterfacePrefix = "";

## How to tell the T4 template to create a proxy 
The T4 Template only creates proxies for controller functions which are decorated with the right Attribute.
For each controller, framework and language a new file with the ControllerName (Classname) + Suffix is created (you can change the Suffix in the T4 Template).

The ProxyGenerator DLL provides four different Attributes.

| Attribute Name | Language | Framework | needed Params |
|----------------|----------|-----------|-----------------|
|CreateAngularJsProxyAttribute| JavaScript | AngularJs | -|
|CreateAngularTsProxyAttribute| TypeScript | AngularJs | ReturnType|
|CreateJQueryJsProxyAttribute| JavaScript | jQuery | -|
|CreateJQueryTsProxyAttribute| TypeScript | jQuery | ReturnType|

You can mix these attributes in any combination. It is possible to use all on the same controller function, then for this function four different proxies are create (one for each language and framework).


To start the proxy creation right click on the T4 Template `ProxyGeneratorScript.tt` and choose **Run Custom Tool**.

(**Hint:** Take a look at the GitHub code, there you find a solution with the T4 template and also a Website with examples for the attribute usage shown below)

### Example: AngularJs JavaScript Proxy - CreateAngularJsProxyAttribute
Creates a proxy for AngukarJs in JavaScript.

The .NET controller functions are decorated with the attribute "**CreateAngularJsProxyAttribute**"

    using ProxyGenerator.ProxyTypeAttributes;
   
    public class ProxyController : Controller
    {     
        [CreateAngularJsProxy]
        public JsonResult AddJsEntryOnly(Person person)
        { 
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult AddJsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke =  name}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult AddJsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult ClearJsCall()
        {
            return Json("ClearJsCall was Called", JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult LoadJsCallById(int id)
        {
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularJsProxy]
        public JsonResult LoadJsCallByParams(string name, string vorname, int alter)
        {
            return Json(vorname, JsonRequestBehavior.AllowGet);
        }
    }

this will create the following AngularJs JavaScript proxy directly localted in VS "below" the T4 template.

    //Warning this file was dynamicly created.
    //Please don't change any code it will be overwritten next time the template is executed.
    //Created on 13.01.2016 time 20:48 from SquadWuschel.
    
    function proxyAngularJsSrv($http) { this.http = $http; } 
    
    
    proxyAngularJsSrv.prototype.addJsEntryOnly = function (person) { 
       return this.http.post('Proxy/AddJsEntryOnly',person).then(function (result) {
            return result.data;
       });
    }
    
    proxyAngularJsSrv.prototype.addJsEntryAndName = function (person,name) { 
       return this.http.post('Proxy/AddJsEntryAndName'+ '?name='+encodeURIComponent(name),person).then(function (result) {
            return result.data;
       });
    }
    
    proxyAngularJsSrv.prototype.addJsEntryAndParams = function (person,name,vorname) { 
       return this.http.post('Proxy/AddJsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then(function (result) {
            return result.data;
       });
    }
    
    proxyAngularJsSrv.prototype.clearJsCall = function () { 
       return this.http.get('Proxy/ClearJsCall').then(function (result) {
            return result.data;
       });
    }
    
    proxyAngularJsSrv.prototype.loadJsCallById = function (id) { 
       return this.http.get('Proxy/LoadJsCallById' + '/' + id).then(function (result) {
            return result.data;
       });
    }
    
    proxyAngularJsSrv.prototype.loadJsCallByParams = function (name,vorname,alter) { 
       return this.http.get('Proxy/LoadJsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then(function (result) {
            return result.data;
       });
    }
    
    angular.module('proxyAngularJsSrv', []) .service('proxyAngularJsSrv', ['$http', proxyAngularJsSrv]);

### Example: AngularJs TypeScript Proxy - CreateAngularTsProxyAttribute
Creates a proxy for AngukarJs in TypeScript.

The .NET controller functions are decorated with the attribute "**CreateAngularTsProxyAttribute**" and you also need to add the "ReturnType" to the attribute params.
The "ReturnType" is the .NET type of the Json which is returned by the Json Function.

    using ProxyGenerator.ProxyTypeAttributes;

    public class ProxyController : Controller
    {  
        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult AddTsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallById(int id)
        {
            return Json(new Person() { Id = id}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallByParams(string name, string vorname, int alter)
        {
            return Json(new Person() { Name = name, Id = alter}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsAndId(string name, string vorname, int alter, int id)
        {
            return Json(new Auto() { Alter = alter, Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto))]
        public JsonResult LoadTsCallByParamsWithEnum(string name, string vorname, int alter, ClientAccess access)
        {
            return Json(new Auto() { Marke = name, Alter = alter}, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(List<Auto>))]
        public JsonResult LoadAllAutosListe(string name)
        {
            return Json(new List<Auto>() { new Auto() { Marke = name}, new Auto() }, JsonRequestBehavior.AllowGet);
        }

        [CreateAngularTsProxy(ReturnType = typeof(Auto[]))]
        public JsonResult LoadAllAutosArray(string name)
        {
            return Json(new List<Auto>() { new Auto() { Marke = name}, new Auto() }.ToArray(), JsonRequestBehavior.AllowGet);
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
            return Json(name, JsonRequestBehavior.AllowGet);
        } 
    }

 this will create the following AngularJs TypeScript proxy. With an interface and the right "ReturnTypes" for each proxy call, please install TypeLite to create the TypeScript interfaces for each type. 
 
**Hint:** Also TypeLite uses attributes to create the interfaces for your classes, you need to set the "[TsClass]" attribute on the classes which are returned by your Json Calls to create the interfaces with TypeLite T4 template.

How to use the TypeScript module, take a look at my the GitHub code for this Project.

    module App.Services { 
       export interface IProxyPSrv { 
          addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
         addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
         addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
         loadTsCallById(id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
         loadTsCallByParams(name: string,vorname: string,alter: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
         loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
         loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
         loadAllAutosListe(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>;
         loadAllAutosArray(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>;
         clearTsCall() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
         voidTsReturnType(name: string): void;
         stringTsReturnType(name: string) : ng.IPromise<string>;
       
       
       export class ProxyPSrv implements IProxyPSrv {
         static $inject = ['$http']; 
         constructor(private $http: ng.IHttpService) { } 
       
         public addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
             return this.$http.post('Proxy/AddTsEntryOnly',person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
         } 
         
         public addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
             return this.$http.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
         } 
         
         public addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
             return this.$http.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
         } 
         
         public loadTsCallById(id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
             return this.$http.get('Proxy/LoadTsCallById' + '/' + id).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
         } 
         
         public loadTsCallByParams(name: string,vorname: string,alter: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
             return this.$http.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
         } 
         
         public loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
             return this.$http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
         } 
         
         public loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
             return this.$http.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
         } 
         
         public loadAllAutosListe(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
             return this.$http.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return response.data; });
         } 
         
         public loadAllAutosArray(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
             return this.$http.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return response.data; });
         } 
         
         public clearTsCall() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
             return this.$http.get('Proxy/ClearTsCall').then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
         } 
         
         public voidTsReturnType(name: string) : void  { 
             this.$http.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)); 
          } 
         
         public stringTsReturnType(name: string) : ng.IPromise<string> { 
             return this.$http.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<string>) : string => { return response.data; });
         } 
       
       //#region Angular Module Definition 
         private static _module: ng.IModule; 
         public static get module(): ng.IModule {
             if (this._module) { return this._module; }
             this._module = angular.module('ProxyPSrv', []);
             this._module.service('ProxyPSrv', ProxyPSrv);
             return this._module; 
          }
        //#endregion 
          } 
     }

### Example: jQuery JavaScript Proxy - CreateJQueryJsProxyAttribute
Creates a proxy for jQuery in JavaScript.

The .NET controller functions are decorated with the attribute "**CreateJQueryJsProxyAttribute**"

    using ProxyGenerator.ProxyTypeAttributes;

    public class ProxyController : Controller
    { 
        [CreateJQueryJsProxy]
        public JsonResult AddJsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        public JsonResult AddJsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke =  name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryJsProxy]
        public JsonResult AddJsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }
    }

    
this will create the following jQuery JavaScript proxy directly localted in VS "below" the T4 template.

    window.proxyjQueryJs = function() { } 
    
    proxyjQueryJs.prototype.addJsEntryOnly = function (person) { 
       return jQuery.post('Proxy/AddJsEntryOnly',person).then(function (result) {
            return result;
       });
    }
    
    proxyjQueryJs.prototype.addJsEntryAndName = function (person,name) { 
       return jQuery.post('Proxy/AddJsEntryAndName'+ '?name='+encodeURIComponent(name),person).then(function (result) {
            return result;
       });
    }
    
    proxyjQueryJs.prototype.addJsEntryAndParams = function (person,name,vorname) { 
       return jQuery.post('Proxy/AddJsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then(function (result) {
            return result;
       });
    }
    
### Example: jQuery TypeScript Proxy - CreateJQueryTsProxyAttribute
Creates a proxy for jQuery in TypeScript.

The .NET controller functions are decorated with the attribute "**CreateJQueryTsProxyAttribute**" and you also need to add the "ReturnType" to the attribute params.
The "ReturnType" is the .NET type of the Json which is returned by the Json Function.

    using ProxyGenerator.ProxyTypeAttributes;

    public class ProxyController : Controller
    { 
        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        public JsonResult AddTsEntryOnly(Person person)
        {
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndName(Person person, string name)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Auto))]
        public JsonResult AddTsEntryAndParams(Person person, string name, string vorname)
        {
            return Json(new Auto() { Marke = name}, JsonRequestBehavior.AllowGet);
        }

        [CreateJQueryTsProxy(ReturnType = typeof(Person))]
        public JsonResult LoadTsCallById(int id)
        {
            return Json(new Person() { Id = id}, JsonRequestBehavior.AllowGet);
        }
    }

 this will create the following jQuery TypeScript proxy. With an interface and the right "ReturnTypes" for each proxy call, please install TypeLite to create the TypeScript interfaces for each type. 

      module App.JqueryServices { 
        export interface IProxyjQueryTs { 
            addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
            addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
            addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
            loadTsCallById(id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
        }
        
        export class ProxyjQueryTs implements IProxyjQueryTs {
            public addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
              return jQuery.post('Proxy/AddTsEntryOnly',person).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
            } 
        
            public addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
              return jQuery.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
            } 
        
            public addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
              return jQuery.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
            } 
        
            public loadTsCallById(id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
              return jQuery.get('Proxy/LoadTsCallById' + '/' + id).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
            } 
        }
    }

