var App;
(function (App) {
    var JQueryApp;
    (function (JQueryApp) {
        var jQueryApp = /** @class */ (function () {
            function jQueryApp() {
                this.jQueryTypeScriptSrv = new App.JqueryServices.proxyjQueryTs();
                //Damit wir in der aufgerufenen Funktion auch den passenden this Pointer haben, müssen wir diesen
                //hier entsprechend übergeben mit bind
                jQuery("#javaScriptCalls").click(this.callJqueryJavaScriptFunctions.bind(this));
                jQuery("#typeScriptCalls").click(this.callJQueryTypeScriptFunctions.bind(this));
                jQuery("#uploadFileTypeScript").click(this.uploadJQueryTypeScriptFile.bind(this));
                jQuery("#uploadFileJavaScript").click(this.uploadJQueryJavaScriptFile.bind(this));
                jQuery("#startFileDownloadCompanyTypeScript").click(this.startFileDownloadCompanyTypeScript.bind(this));
                jQuery("#startFileDownloadPersonTypeScript").click(this.startFileDownloadPersonTypeScript.bind(this));
                jQuery("#startFileDownloadNoParamsTypeScript").click(this.startFileDownloadNoParamsTypeScript.bind(this));
                jQuery("#startFileDownloadCompanyJavaScript").click(this.startFileDownloadCompanyJavaScript.bind(this));
                jQuery("#startFileDownloadPersonJavaScript").click(this.startFileDownloadPersonJavaScript.bind(this));
                jQuery("#startFileDownloadNoParamsJavaScript").click(this.startFileDownloadNoParamsJavaScript.bind(this));
            }
            //#region Downloads und Uploads
            jQueryApp.prototype.uploadJQueryTypeScriptFile = function (event) {
                event.preventDefault();
                //http://stackoverflow.com/questions/9622901/how-to-upload-a-file-using-jquery-ajax-and-formdata
                //Die Datei ermitteln, ACHTUNG am Input muss das ID Attribute existieren und nicht der name
                var fileData = jQuery("#fuTypeScript").prop("files")[0];
                this.jQueryTypeScriptSrv.addFileToServer(fileData, 12).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'addFileToServer' Result: ");
                    console.log(result);
                });
            };
            jQueryApp.prototype.uploadJQueryJavaScriptFile = function (event) {
                event.preventDefault();
                //Init Proxy Function
                var calls = new window.proxyjQueryJs();
                var fileData = jQuery("#fujavaScript").prop("files")[0];
                calls.addFileToServer(fileData, 12).then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'addFileToServer' Result: ");
                    console.log(result);
                });
            };
            jQueryApp.prototype.startFileDownloadCompanyJavaScript = function (event) {
                event.preventDefault();
                var company = new Company("MyCompany", 12, 2 /* Admin */);
                var calls = new window.proxyjQueryJs();
                calls.getDownloadCompany(1336, company);
            };
            jQueryApp.prototype.startFileDownloadPersonJavaScript = function (event) {
                event.preventDefault();
                var ages = [1, 2, 3, 4, 5, 66];
                var person = new Person(16667, "SquadJs", "Wuschel", true, ages);
                var calls = new window.proxyjQueryJs();
                calls.getDownloadPerson(66, person);
            };
            jQueryApp.prototype.startFileDownloadNoParamsJavaScript = function (event) {
                event.preventDefault();
                var calls = new window.proxyjQueryJs();
                calls.getDownloadNoParams();
            };
            jQueryApp.prototype.startFileDownloadCompanyTypeScript = function (event) {
                event.preventDefault();
                var company = new Company("MyCompany", 12, 2 /* Admin */);
                this.jQueryTypeScriptSrv.getDownloadCompany(1337, company);
            };
            jQueryApp.prototype.startFileDownloadPersonTypeScript = function (event) {
                event.preventDefault();
                var ages = [1, 2, 3, 4, 5, 66];
                var person = new Person(16667, "SquadJs", "Wuschel", true, ages);
                this.jQueryTypeScriptSrv.getDownloadPerson(1337, person);
            };
            jQueryApp.prototype.startFileDownloadNoParamsTypeScript = function (event) {
                event.preventDefault();
                this.jQueryTypeScriptSrv.getDownloadNoParams();
            };
            //#endregion
            jQueryApp.prototype.callJQueryTypeScriptFunctions = function (event) {
                event.preventDefault();
                var proxyjQueryTs = this.jQueryTypeScriptSrv;
                var ages = [1, 2, 3, 4, 5, 66];
                var person = new Person(1337, "Squad", "Wuschel", true, ages);
                console.clear();
                console.log("Some TypeScript jQuery Service Calls: \r\n");
                proxyjQueryTs.addAges(ages).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'addAges' Result: ");
                    console.log(result);
                    proxyjQueryTs.addAges(result);
                });
                proxyjQueryTs.manySimpleParams(12, 345, 1, 1, "test", 12, "squad@web.de", "Squad", 12, 32).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'manySimpleParams' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.addTsEntryAndName(person, "Johannes").then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndName' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.addTsEntryAndParams(person, "Squad", "Wuschel").then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndParams' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.addTsEntryOnly(person).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'addTsEntryOnly' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.boolTsReturnType(true).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'boolTsReturnType' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.clearTsCall().then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'clearTsCall' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.dateTsReturnType("SquadWuschel").then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'dateTsReturnType' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.integerTsReturnType(1337).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'integerTsReturnType' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.loadAllAutosArray("SquadWuschel").then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosArray' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.loadAllAutosListe("SquadWuschel").then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosListe' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.loadTsCallById(16667).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'loadTsCallById' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.loadTsCallByParams("Squad", "Wuschel", 33).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParams' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.loadTsCallByParamsAndId("Squad", "Wuschel", 33, 1337).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.loadTsCallByParamsWithEnum("Squad", "Wuschel", 33, 2 /* Admin */).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.testView().then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'testView' Result: ");
                    console.log(result);
                });
                proxyjQueryTs.errorStringReturnType(true).then(function (result) {
                    console.log("\r\nSuccess TypeScript Service Call 'errorStringReturnType' Result: ");
                    console.log(result);
                }, function (errorResult) {
                    //Only gets Called if the ErrorResponse is active and returns only the errorResult and not only the Data.
                    console.log("\r\nError TypeScript Service Call 'errorStringReturnType' Result: ");
                    console.log(errorResult);
                });
            };
            jQueryApp.prototype.callJqueryJavaScriptFunctions = function (event) {
                event.preventDefault();
                var ages = [1, 2, 3, 4, 5, 66];
                var person = new Person(1337, "Squad", "Wuschel", true, ages);
                //Init Proxy Function
                var calls = new window.proxyjQueryJs();
                console.clear();
                console.log("Some JavaScript jQuery Service Calls: \r\n");
                calls.addJsEntryOnly(person).then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'addJsEntryOnly' Result: ");
                    console.log(result);
                });
                calls.addJsEntryAndName(person, "Wuschel").then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'addJsEntryAndName' Result: ");
                    console.log(result);
                });
                calls.addJsEntryAndParams(person, "Squad", "Wuschel").then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'addJsEntryAndParams' Result: ");
                    console.log(result);
                });
                calls.clearJsCall().then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'clearJsCall' Result: ");
                    console.log(result);
                });
                calls.loadJsCallById(1337).then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'loadJsCallById' Result: ");
                    console.log(result);
                });
                calls.loadJsCallByParamsAndId("Squad", "Wuschel", 34, 1337).then(function (result) {
                    console.log("\r\nSuccess JavaScript Service Call 'loadJsCallByParamsAndId' Result: ");
                    console.log(result);
                });
            };
            return jQueryApp;
        }());
        JQueryApp.jQueryApp = jQueryApp;
    })(JQueryApp = App.JQueryApp || (App.JQueryApp = {}));
})(App || (App = {}));
var app = new App.JQueryApp.jQueryApp();
//# sourceMappingURL=jQueryCalls.js.map