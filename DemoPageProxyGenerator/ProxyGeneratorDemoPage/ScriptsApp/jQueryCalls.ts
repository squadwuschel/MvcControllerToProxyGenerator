module App.JQueryApp {

    export class jQueryApp {
        private jQuerySrv: App.JqueryServices.IProxyjQueryTs;

       constructor() {
           jQuery("#javaScriptCalls").click(this.callJqueryJavaScriptFunctions);
           jQuery("#typeScriptCalls").click(this.callJQueryTypeScriptFunctions);
           this.jQuerySrv = new App.JqueryServices.ProxyjQueryTs();
       }

       public callJQueryTypeScriptFunctions(event: Event): void {
           event.preventDefault();
           var srv = new App.JqueryServices.ProxyjQueryTs();

           var person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson = new Person(1337, "Squad", new Date(), "Wuschel", true);
           var auto: ProxyGeneratorDemoPage.Models.Person.Models.IAuto = new Auto("BMW", 5, person);

           console.clear();
           console.log("Some TypeScript Angular Service Calls: \r\n");

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

       public callJqueryJavaScriptFunctions(event : Event): void {
           event.preventDefault();
        }
    }
}

var app = new App.JQueryApp.jQueryApp();