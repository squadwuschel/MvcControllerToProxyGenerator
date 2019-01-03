(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/Build/Classes/Person.ts":
/*!*****************************************!*\
  !*** ./src/app/Build/Classes/Person.ts ***!
  \*****************************************/
/*! exports provided: Person */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Person", function() { return Person; });
var Person = /** @class */ (function () {
    function Person(Id, Name, Passwort, IsAktiv, CounterValues) {
        this.Id = Id;
        this.Name = Name;
        this.Passwort = Passwort;
        this.IsAktiv = IsAktiv;
        this.CounterValues = CounterValues;
    }
    return Person;
}());



/***/ }),

/***/ "./src/app/Services/proxy.service.ts":
/*!*******************************************!*\
  !*** ./src/app/Services/proxy.service.ts ***!
  \*******************************************/
/*! exports provided: Proxyservice */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Proxyservice", function() { return Proxyservice; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 03.01.2019 time 13:11 from jrenatus.



var Proxyservice = /** @class */ (function () {
    function Proxyservice(http) {
        this.http = http;
    }
    Proxyservice.prototype.addFileToServer = function (datei, detailId) {
        var formData = new FormData();
        formData.append('datei', datei);
        return this.http.post('Proxy/AddFileToServer' + '?detailId=' + detailId, formData);
    };
    Proxyservice.prototype.addFileToServerNoReturnType = function (datei, detailId) {
        var formData = new FormData();
        formData.append('datei', datei);
        this.http.post('Proxy/AddFileToServerNoReturnType' + '?detailId=' + detailId, formData).subscribe(function (res) { return res; });
    };
    Proxyservice.prototype.getDownloadPerson = function (personId) {
        window.location.href = 'Proxy/GetDownloadPerson' + '?personId=' + personId;
    };
    Proxyservice.prototype.getDownloadCompany = function (companyId) {
        window.location.href = 'Proxy/GetDownloadCompany' + '?companyId=' + companyId;
    };
    Proxyservice.prototype.getDownloadSimple = function (companyId, name) {
        window.location.href = 'Proxy/GetDownloadSimple' + '?companyId=' + companyId + '&name=' + encodeURIComponent(name);
    };
    Proxyservice.prototype.getDownloadNoParams = function () {
        window.location.href = 'Proxy/GetDownloadNoParams';
    };
    Proxyservice.prototype.manySimpleParams = function (page, size, sortedCol, desc, smCompany, smCustomerNumber, smEmail, smLastname, portal, count) {
        return this.http.get('Proxy/ManySimpleParams' + '?page=' + page + '&size=' + size + '&sortedCol=' + sortedCol + '&desc=' + desc + '&smCompany=' + encodeURIComponent(smCompany) + '&smCustomerNumber=' + smCustomerNumber + '&smEmail=' + encodeURIComponent(smEmail) + '&smLastname=' + encodeURIComponent(smLastname) + '&portal=' + portal + '&count=' + count);
    };
    Proxyservice.prototype.addAges = function (ages) {
        return this.http.post('Proxy/AddAges', ages);
    };
    Proxyservice.prototype.addTsEntryOnly = function (person) {
        return this.http.post('Proxy/AddTsEntryOnly', person);
    };
    Proxyservice.prototype.addTsEntryAndName = function (person, name) {
        return this.http.post('Proxy/AddTsEntryAndName' + '?name=' + encodeURIComponent(name), person);
    };
    Proxyservice.prototype.addTsEntryAndParams = function (person, name, vorname) {
        return this.http.post('Proxy/AddTsEntryAndParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname), person);
    };
    Proxyservice.prototype.loadTsCallById = function (id) {
        return this.http.get('Proxy/LoadTsCallById' + '/' + id);
    };
    Proxyservice.prototype.loadTsCallByParams = function (name, vorname, alter) {
        return this.http.get('Proxy/LoadTsCallByParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter);
    };
    Proxyservice.prototype.loadTsCallByParamsAndId = function (name, vorname, alter, id) {
        return this.http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter);
    };
    Proxyservice.prototype.loadTsCallByParamsWithEnum = function (name, vorname, alter, access) {
        return this.http.get('Proxy/LoadTsCallByParamsWithEnum' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter + '&access=' + access);
    };
    Proxyservice.prototype.loadAllAutosListe = function (name) {
        return this.http.get('Proxy/LoadAllAutosListe' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.loadAllAutosArray = function (name) {
        return this.http.get('Proxy/LoadAllAutosArray' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.clearTsCall = function () {
        return this.http.get('Proxy/ClearTsCall');
    };
    Proxyservice.prototype.voidTsReturnType = function (name) {
        this.http.get('Proxy/VoidTsReturnType' + '?name=' + encodeURIComponent(name)).subscribe(function (res) { return res; });
    };
    Proxyservice.prototype.stringTsReturnType = function (name) {
        return this.http.get('Proxy/StringTsReturnType' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.integerTsReturnType = function (age) {
        return this.http.get('Proxy/IntegerTsReturnType' + '?age=' + age);
    };
    Proxyservice.prototype.dateTsReturnType = function (name) {
        return this.http.get('Proxy/DateTsReturnType' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.boolTsReturnType = function (boolValue) {
        return this.http.get('Proxy/BoolTsReturnType' + '?boolValue=' + boolValue);
    };
    Proxyservice.prototype.errorStringReturnType = function (boolValue) {
        return this.http.get('Proxy/ErrorStringReturnType' + '?boolValue=' + boolValue);
    };
    Proxyservice = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"]])
    ], Proxyservice);
    return Proxyservice;
}());



/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<!--The content below is only a placeholder and can be replaced.-->\n<div class=\"container body-content\" style=\"margin-top: 25px;\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>\r\n                Angular 2 Proxy Calls\r\n            </h3>\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            <hr />\r\n        </div>\r\n    </div>\r\n  <div class=\"row\">\r\n    <div class=\"col-md-3 col-md-offset-3\">\r\n      <button (click)=\"startTypeScriptServiceCalls()\" class=\"btn btn-primary btn-block\">Test TypeScript Service Calls</button>\r\n    </div>\r\n  </div>\r\n  <div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n      <br />\r\n      <p class=\"text-center\">\r\n        <strong>Please open the Chrome developer Console to see the service Calls and returned Objects.</strong>\r\n      </p>\r\n    </div>\r\n  </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>Datei Upload Tests f�r Angular 2</h3>\r\n            <p>The IIS tries to store the uploaded files in the diretory: \"C:\\Temp\\\"</p>\r\n            <br />\r\n            <br />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <input #fileInput type=\"file\" class=\"form-control input-sm\" />\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <a (click)=\"startFileUploadTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileUpload TypeScript</a>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\"><hr /></div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            <a (click)=\"startFileDownloadCompanyTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileDownload Company TypeScript</a>\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <a (click)=\"startFileDownloadPersonTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileDownload Person TypeScript</a>\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <a (click)=\"startFileDownloadNoParamsTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileDownload NoParams TypeScript</a>\r\n        </div>\r\n    </div>\r\n</div>\n\n"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _Services_proxy_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./Services/proxy.service */ "./src/app/Services/proxy.service.ts");
/* harmony import */ var _Build_Classes_Person__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./Build/Classes/Person */ "./src/app/Build/Classes/Person.ts");




var AppComponent = /** @class */ (function () {
    function AppComponent(proxyService) {
        this.proxyService = proxyService;
        this.name = "TEST";
        //Im Konstruktor einfach per DI einen Service injecten, dieser muss in Providers bekannt gemacht werden
    }
    AppComponent.prototype.startFileUploadTypeScript = function () {
        //File Upload
        //https://devblog.dymel.pl/2016/09/02/upload-file-image-angular2-aspnetcore/
        var fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            var fileToUpload = fi.files[0];
            this.proxyService.addFileToServer(fileToUpload, 12).subscribe(function (_) {
                console.log(_);
            });
        }
    };
    AppComponent.prototype.startFileDownloadCompanyTypeScript = function () {
        this.proxyService.getDownloadCompany(1337);
    };
    AppComponent.prototype.startFileDownloadPersonTypeScript = function () {
        this.proxyService.getDownloadPerson(7331);
    };
    AppComponent.prototype.startFileDownloadNoParamsTypeScript = function () {
        this.proxyService.getDownloadNoParams();
    };
    AppComponent.prototype.startTypeScriptServiceCalls = function () {
        var _this = this;
        var ages = [1, 2, 3, 4, 5, 66];
        var person = new _Build_Classes_Person__WEBPACK_IMPORTED_MODULE_3__["Person"](1337, "Squad", "Wuschel", true, ages);
        console.clear();
        console.log("Some TypeScript Angular Service Calls: \r\n");
        this.proxyService.addAges(ages).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addAges' Result: ");
            console.log(result);
            _this.proxyService.addAges(result);
        });
        this.proxyService.addTsEntryAndName(person, "Johannes").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndName' Result: ");
            console.log(result);
        });
        this.proxyService.manySimpleParams(12, 345, 1, 1, "test", 12, "squad@web.de", "Squad", 12, 32).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'manySimpleParams' Result: ");
            console.log(result);
        });
        this.proxyService.addTsEntryAndParams(person, "Squad", "Wuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndParams' Result: ");
            console.log(result);
        });
        this.proxyService.addTsEntryOnly(person).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryOnly' Result: ");
            console.log(result);
        });
        this.proxyService.boolTsReturnType(true).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'boolTsReturnType' Result: ");
            console.log(result);
        });
        this.proxyService.clearTsCall().subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'clearTsCall' Result: ");
            console.log(result);
        });
        this.proxyService.dateTsReturnType("SquadWuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'dateTsReturnType' Result: ");
            console.log(result);
        });
        this.proxyService.integerTsReturnType(1337).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'integerTsReturnType' Result: ");
            console.log(result);
        });
        this.proxyService.loadAllAutosArray("SquadWuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosArray' Result: ");
            console.log(result);
        });
        this.proxyService.loadAllAutosListe("SquadWuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosListe' Result: ");
            console.log(result);
        });
        this.proxyService.loadTsCallById(16667).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallById' Result: ");
            console.log(result);
        });
        this.proxyService.loadTsCallByParams("Squad", "Wuschel", 33).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParams' Result: ");
            console.log(result);
        });
        this.proxyService.loadTsCallByParamsAndId("Squad", "Wuschel", 33, 1337).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
            console.log(result);
        });
        this.proxyService.voidTsReturnType("test");
        this.proxyService.loadTsCallByParamsWithEnum("Squad", "Wuschel", 33, 2 /* Admin */).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
            console.log(result);
        });
        this.proxyService.errorStringReturnType(true).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'errorStringReturnType' Result: ");
            console.log(result);
        }, function (errorResult) {
            //Only gets Called if the ErrorResponse is active and returns only the errorResult and not only the Data.
            console.log("\r\nError TypeScript Service Call 'errorStringReturnType' Result: ");
            console.log(errorResult);
        });
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewChild"])("fileInput"),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object)
    ], AppComponent.prototype, "fileInput", void 0);
    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'angular-2-calls',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            providers: [_Services_proxy_service__WEBPACK_IMPORTED_MODULE_2__["Proxyservice"]]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_Services_proxy_service__WEBPACK_IMPORTED_MODULE_2__["Proxyservice"]])
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");





var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClientModule"]
            ],
            providers: [],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\jrenatus\source\repos\MvcControllerToProxyGenerator\DemoPageProxyGenerator\ProxyGeneratorNgDemoPage\Web\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map