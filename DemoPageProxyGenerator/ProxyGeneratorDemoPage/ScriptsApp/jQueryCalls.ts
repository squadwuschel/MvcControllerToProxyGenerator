module App.JQueryApp {

    export class jQueryApp {
        private jQuerySrv: App.JqueryServices.proxyjQueryTs;

        constructor() {
            this.jQuerySrv = new App.JqueryServices.proxyjQueryTs();

            //Damit wir in der aufgerufenen Funktion auch den passenden this Pointer haben, müssen wir diesen
            //hier entsprechend übergeben mit bind
            jQuery("#javaScriptCalls").click(this.callJqueryJavaScriptFunctions.bind(this));
            jQuery("#typeScriptCalls").click(this.callJQueryTypeScriptFunctions.bind(this));

            jQuery("#uploadFileTypeScript").click(this.uploadJQueryTypeScriptFile.bind(this));
            jQuery("#uploadFileJavaScript").click(this.uploadJQueryJavaScriptFile.bind(this));

        }

        public uploadJQueryTypeScriptFile(event: Event): void {
            event.preventDefault();

            //http://stackoverflow.com/questions/9622901/how-to-upload-a-file-using-jquery-ajax-and-formdata
            //Die Datei ermitteln, ACHTUNG am Input muss das ID Attribute existieren und nicht der name
            var fileData = jQuery("#fuTypeScript").prop("files")[0];
            this.jQuerySrv.addFileToServer(fileData, 12).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'addFileToServer' Result: ");
                console.log(result);
            });
        }

        public uploadJQueryJavaScriptFile(event: Event): void {
            event.preventDefault();

            //Init Proxy Function
            var calls = new window.proxyjQueryJs();
            var fileData = jQuery("#fujavaScript").prop("files")[0];
            calls.addFileToServer(fileData, 12).then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'addFileToServer' Result: ");
                console.log(result);
            });
        }

        public callJQueryTypeScriptFunctions(event: Event): void {
            event.preventDefault();
            var srv = this.jQuerySrv;

            var person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson = new Person(1337, "Squad", new Date(), "Wuschel", true);

            console.clear();
            console.log("Some TypeScript jQuery Service Calls: \r\n");

            srv.testView().then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'testView' Result: ");
                console.log(result);
            });

            srv.manySimpleParams(12, 345, 1, 1, "test", 12, "squad@web.de", "Squad", 12, 32).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'manySimpleParams' Result: ");
                console.log(result);
            });

            srv.addTsEntryAndName(person, "Johannes").then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndName' Result: ");
                console.log(result);
            });

            srv.addTsEntryAndParams(person, "Squad", "Wuschel").then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndParams' Result: ");
                console.log(result);
            });

            srv.addTsEntryOnly(person).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'addTsEntryOnly' Result: ");
                console.log(result);
            });

            srv.boolTsReturnType(true).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'boolTsReturnType' Result: ");
                console.log(result);
            });

            srv.clearTsCall().then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'clearTsCall' Result: ");
                console.log(result);
            });

            srv.dateTsReturnType("SquadWuschel").then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'dateTsReturnType' Result: ");
                console.log(result);
            });

            srv.integerTsReturnType(1337).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'integerTsReturnType' Result: ");
                console.log(result);
            });

            srv.loadAllAutosArray("SquadWuschel").then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosArray' Result: ");
                console.log(result);
            });

            srv.loadAllAutosListe("SquadWuschel").then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosListe' Result: ");
                console.log(result);
            });

            srv.loadTsCallById(16667).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'loadTsCallById' Result: ");
                console.log(result);
            });

            srv.loadTsCallByParams("Squad", "Wuschel", 33).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParams' Result: ");
                console.log(result);
            });

            srv.loadTsCallByParamsAndId("Squad", "Wuschel", 33, 1337).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
                console.log(result);
            });

            srv.loadTsCallByParamsWithEnum("Squad", "Wuschel", 33, ProxyGeneratorDemoPage.Helper.ClientAccess.Admin).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
                console.log(result);
            });

            srv.errorStringReturnType(true).then(result => {
                console.log("\r\nSuccess TypeScript Service Call 'errorStringReturnType' Result: ");
                console.log(result);
            }, errorResult => {
                //Only gets Called if the ErrorResponse is active and returns only the errorResult and not only the Data.
                console.log("\r\nError TypeScript Service Call 'errorStringReturnType' Result: ");
                console.log(errorResult);
            });

        }

        public callJqueryJavaScriptFunctions(event: Event): void {
            event.preventDefault();
            var person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson = new Person(1337, "Squad", new Date(), "Wuschel", true);

            //Init Proxy Function
            var calls = new window.proxyjQueryJs();

            console.clear();
            console.log("Some JavaScript jQuery Service Calls: \r\n");

            calls.addJsEntryOnly(person).then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'addJsEntryOnly' Result: ");
                console.log(result);
            });

            calls.addJsEntryAndName(person, "Wuschel").then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'addJsEntryAndName' Result: ");
                console.log(result);
            });

            calls.addJsEntryAndParams(person, "Squad", "Wuschel").then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'addJsEntryAndParams' Result: ");
                console.log(result);
            });

            calls.clearJsCall().then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'clearJsCall' Result: ");
                console.log(result);
            });

            calls.loadJsCallById(1337).then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'loadJsCallById' Result: ");
                console.log(result);
            });

            calls.loadJsCallByParamsAndId("Squad", "Wuschel", 34, 1337).then(result => {
                console.log("\r\nSuccess JavaScript Service Call 'loadJsCallByParamsAndId' Result: ");
                console.log(result);
            });
        }
    }
}

/*Window Interface erweitern, damit wir auch hier auf z.b. eigene Properties zugreifen können die wir z.B: in alten JS dateien definiert haben */
interface Window {
    proxyjQueryJs: any;
}


var app = new App.JQueryApp.jQueryApp();
