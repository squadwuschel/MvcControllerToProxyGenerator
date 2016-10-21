"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var proxy_service_1 = require("../../Services/proxy.service");
var Angular2Calls = (function () {
    function Angular2Calls(proxyService) {
        this.proxyService = proxyService;
        this.name = "TEST";
        //Im Konstruktor einfach per DI einen Service injecten, dieser muss auch in Providers bekannt gemacht werden
    }
    Angular2Calls.prototype.startFileUploadTypeScript = function () {
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
    Angular2Calls.prototype.startFileDownloadCompanyTypeScript = function () {
        var company = new Company("MyCompany", 12, 2 /* Admin */);
        this.proxyService.getDownloadCompany(1337, company);
    };
    Angular2Calls.prototype.startFileDownloadPersonTypeScript = function () {
        var ages = [1, 2, 3, 4, 5, 66];
        var person = new Person(16667, "SquadJs", "Wuschel", true, ages);
        this.proxyService.getDownloadPerson(7331, person);
    };
    Angular2Calls.prototype.startFileDownloadNoParamsTypeScript = function () {
        this.proxyService.getDownloadNoParams();
    };
    Angular2Calls.prototype.startTypeScriptServiceCalls = function () {
        var _this = this;
        var ages = [1, 2, 3, 4, 5, 66];
        var person = new Person(1337, "Squad", "Wuschel", true, ages);
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
    __decorate([
        core_1.ViewChild("fileInput"), 
        __metadata('design:type', Object)
    ], Angular2Calls.prototype, "fileInput", void 0);
    Angular2Calls = __decorate([
        core_1.Component({
            selector: 'angular-2-calls',
            templateUrl: "ScriptsAppNg2/Views/Proxy/angular2Calls.component.html",
            providers: [proxy_service_1.Proxyservice]
        }), 
        __metadata('design:paramtypes', [proxy_service_1.Proxyservice])
    ], Angular2Calls);
    return Angular2Calls;
}());
exports.Angular2Calls = Angular2Calls;
//# sourceMappingURL=angular2Calls.component.js.map