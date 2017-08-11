var App;
(function (App) {
    var Views;
    (function (Views) {
        var Proxy;
        (function (Proxy) {
            var ProxyCtrl = (function () {
                function ProxyCtrl(proxyTsSrv, homeTsSrv, homeJsSrv, proxyJsSrv) {
                    this.proxyTsSrv = proxyTsSrv;
                    this.homeTsSrv = homeTsSrv;
                    this.homeJsSrv = homeJsSrv;
                    this.proxyJsSrv = proxyJsSrv;
                    this.init();
                }
                /**
                * Initialisieren der wichtigsten lokalen Variablen
                */
                ProxyCtrl.prototype.init = function () { };
                //#region Downloads und Uploads
                ProxyCtrl.prototype.startFileUploadTypeScript = function () {
                    this.proxyTsSrv.addFileToServer(this.fileImportDataTypeScript, 12).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'addFileToServer' Result: ");
                        console.log(result);
                    });
                };
                ProxyCtrl.prototype.startFileUploadJavaScript = function () {
                    this.proxyJsSrv.addFileToServer(this.fileImportDataJavaScript, 12).then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'addFileToServer' Result: ");
                        console.log(result);
                    });
                };
                ProxyCtrl.prototype.startFileDownloadCompanyTypeScript = function () {
                    var company = new Company("MyCompany", 12, 2 /* Admin */);
                    this.proxyTsSrv.getDownloadCompany(1337, company);
                };
                ProxyCtrl.prototype.startFileDownloadPersonTypeScript = function () {
                    var ages = [1, 2, 3, 4, 5, 66];
                    var person = new Person(16667, "SquadJs", "Wuschel", true, ages);
                    this.proxyTsSrv.getDownloadPerson(7331, person);
                };
                ProxyCtrl.prototype.startFileDownloadNoParamsTypeScript = function () {
                    this.proxyTsSrv.getDownloadNoParams();
                };
                ProxyCtrl.prototype.startFileDownloadCompanyJavaScript = function () {
                    var company = new Company("MyCompany", 12, 2 /* Admin */);
                    this.proxyJsSrv.getDownloadCompany(1337, company);
                };
                ProxyCtrl.prototype.startFileDownloadPersonJavaScript = function () {
                    var ages = [1, 2, 3, 4, 5, 66];
                    var person = new Person(16667, "SquadJs", "Wuschel", true, ages);
                    this.proxyJsSrv.getDownloadPerson(7331, person);
                };
                ProxyCtrl.prototype.startFileDownloadNoParamsJavaScript = function () {
                    this.proxyJsSrv.getDownloadNoParams();
                };
                //#endregion
                ProxyCtrl.prototype.startJavaScriptServiceCalls = function () {
                    var ages = [1, 2, 3, 4, 5, 66];
                    var person = new Person(16667, "SquadJs", "Wuschel", true, ages);
                    var auto = new Auto("BMW Js", 12, person);
                    console.clear();
                    console.log("Some JavaScript Angular Service Calls: \r\n");
                    this.proxyJsSrv.addJsEntryOnly(person).then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'addJsEntryOnly' Result: ");
                        console.log(result);
                    });
                    this.proxyJsSrv.addJsEntryAndName(person, "Wuschel").then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'addJsEntryAndName' Result: ");
                        console.log(result);
                    });
                    this.proxyJsSrv.addJsEntryAndParams(person, "Squad", "Wuschel").then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'addJsEntryAndParams' Result: ");
                        console.log(result);
                    });
                    this.proxyJsSrv.clearJsCall().then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'clearJsCall' Result: ");
                        console.log(result);
                    });
                    this.proxyJsSrv.loadJsCallById(1337).then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'loadJsCallById' Result: ");
                        console.log(result);
                    });
                    this.proxyJsSrv.loadJsCallByParamsAndId("Squad", "Wuschel", 34, 1337).then(function (result) {
                        console.log("\r\nSuccess JavaScript Service Call 'loadJsCallByParamsAndId' Result: ");
                        console.log(result);
                    });
                };
                ProxyCtrl.prototype.startTypeScriptServiceCalls = function () {
                    var _this = this;
                    var ages = [1, 2, 3, 4, 5, 66];
                    var person = new Person(1337, "Squad", "Wuschel", true, ages);
                    console.clear();
                    console.log("Some TypeScript Angular Service Calls: \r\n");
                    this.proxyTsSrv.addAges(ages).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'addAges' Result: ");
                        console.log(result);
                        _this.proxyTsSrv.addAges(result);
                    });
                    this.proxyTsSrv.addTsEntryAndName(person, "Johannes").then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndName' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.manySimpleParams(12, 345, 1, 1, "test", 12, "squad@web.de", "Squad", 12, 32).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'manySimpleParams' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.addTsEntryAndParams(person, "Squad", "Wuschel").then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndParams' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.addTsEntryOnly(person).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'addTsEntryOnly' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.boolTsReturnType(true).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'boolTsReturnType' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.clearTsCall().then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'clearTsCall' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.dateTsReturnType("SquadWuschel").then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'dateTsReturnType' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.integerTsReturnType(1337).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'integerTsReturnType' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.loadAllAutosArray("SquadWuschel").then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosArray' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.loadAllAutosListe("SquadWuschel").then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosListe' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.loadTsCallById(16667).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'loadTsCallById' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.loadTsCallByParams("Squad", "Wuschel", 33).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParams' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.loadTsCallByParamsAndId("Squad", "Wuschel", 33, 1337).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.loadTsCallByParamsWithEnum("Squad", "Wuschel", 33, 2 /* Admin */).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
                        console.log(result);
                    });
                    this.proxyTsSrv.errorStringReturnType(true).then(function (result) {
                        console.log("\r\nSuccess TypeScript Service Call 'errorStringReturnType' Result: ");
                        console.log(result);
                    }, function (errorResult) {
                        //Only gets Called if the ErrorResponse is active and returns only the errorResult and not only the Data.
                        console.log("\r\nError TypeScript Service Call 'errorStringReturnType' Result: ");
                        console.log(errorResult);
                    });
                };
                Object.defineProperty(ProxyCtrl, "module", {
                    /**
                     * Stellt das aktuelle Angular Modul für den "Proxy" bereit.
                     */
                    get: function () {
                        if (this._module) {
                            return this._module;
                        }
                        //Hier die abhängigen Module für diesen controller definieren, damit brauchen wir von außen nur den Controller einbinden
                        //und müssen seine Abhängkeiten nicht wissen.
                        this._module = angular.module('proxyCtrl', []);
                        this._module.controller('proxyCtrl', ProxyCtrl);
                        return this._module;
                    },
                    enumerable: true,
                    configurable: true
                });
                return ProxyCtrl;
            }());
            ProxyCtrl.$inject = [
                App.Services.ProxyPService.module.name,
                App.Services.HomePService.module.name,
                "homeAngularJsSrv",
                "proxyAngularJsSrv",
            ];
            Proxy.ProxyCtrl = ProxyCtrl;
        })(Proxy = Views.Proxy || (Views.Proxy = {}));
    })(Views = App.Views || (App.Views = {}));
})(App || (App = {}));
//# sourceMappingURL=proxyCtrl.js.map