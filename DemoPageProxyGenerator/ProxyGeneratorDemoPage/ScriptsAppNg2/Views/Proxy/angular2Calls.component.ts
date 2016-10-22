import {Component, ViewChild} from '@angular/core';
import {Proxyservice} from "../../Services/proxy.service"

@Component({
    selector: 'angular-2-calls',
    templateUrl: `ScriptsAppNg2/Views/Proxy/angular2Calls.component.html`,
    providers: [ Proxyservice ]
})
export class Angular2Calls {
    public name: string = "TEST";

    constructor(public proxyService : Proxyservice) {
        //Im Konstruktor einfach per DI einen Service injecten, dieser muss in Providers bekannt gemacht werden
    }

    @ViewChild("fileInput") fileInput;
    public startFileUploadTypeScript(): void {
        //File Upload
        //https://devblog.dymel.pl/2016/09/02/upload-file-image-angular2-aspnetcore/

        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];
            this.proxyService.addFileToServer(fileToUpload, 12).subscribe(_ => {
                console.log(_);
            });
        }
    }

    public startFileDownloadCompanyTypeScript() {
        var company: ProxyGeneratorDemoPage.Helper.ICompany = new Company("MyCompany", 12, ProxyGeneratorDemoPage.Helper.ClientAccess.Admin);
        this.proxyService.getDownloadCompany(1337, company);
    }
    
    public startFileDownloadPersonTypeScript() : void {
        var ages: number[] = [1, 2, 3, 4, 5, 66];
        var person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson = new Person(16667, "SquadJs", "Wuschel", true, ages);
        this.proxyService.getDownloadPerson(7331, person);
    }

    public startFileDownloadNoParamsTypeScript()  : void {
        this.proxyService.getDownloadNoParams();
    }

    public startTypeScriptServiceCalls() {
        var ages: number[] = [1, 2, 3, 4, 5, 66];
        var person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson = new Person(1337, "Squad", "Wuschel", true, ages);

        console.clear();
        console.log("Some TypeScript Angular Service Calls: \r\n");

        this.proxyService.addAges(ages).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'addAges' Result: ");
            console.log(result);
            this.proxyService.addAges(result);
        });

        this.proxyService.addTsEntryAndName(person, "Johannes").subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndName' Result: ");
            console.log(result);
        });

        this.proxyService.manySimpleParams(12, 345, 1, 1, "test", 12, "squad@web.de", "Squad", 12, 32).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'manySimpleParams' Result: ");
            console.log(result);
        });

        this.proxyService.addTsEntryAndParams(person, "Squad", "Wuschel").subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndParams' Result: ");
            console.log(result);
        });

        this.proxyService.addTsEntryOnly(person).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryOnly' Result: ");
            console.log(result);
        });

        this.proxyService.boolTsReturnType(true).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'boolTsReturnType' Result: ");
            console.log(result);
        });

        this.proxyService.clearTsCall().subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'clearTsCall' Result: ");
            console.log(result);
        });

        this.proxyService.dateTsReturnType("SquadWuschel").subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'dateTsReturnType' Result: ");
            console.log(result);
        });

        this.proxyService.integerTsReturnType(1337).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'integerTsReturnType' Result: ");
            console.log(result);
        });

        this.proxyService.loadAllAutosArray("SquadWuschel").subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosArray' Result: ");
            console.log(result);
        });

        this.proxyService.loadAllAutosListe("SquadWuschel").subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosListe' Result: ");
            console.log(result);
        });

        this.proxyService.loadTsCallById(16667).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallById' Result: ");
            console.log(result);
        });

        this.proxyService.loadTsCallByParams("Squad", "Wuschel", 33).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParams' Result: ");
            console.log(result);
        });

        this.proxyService.loadTsCallByParamsAndId("Squad", "Wuschel", 33, 1337).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
            console.log(result);
        });

        this.proxyService.voidTsReturnType("test");

        this.proxyService.loadTsCallByParamsWithEnum("Squad", "Wuschel", 33, ProxyGeneratorDemoPage.Helper.ClientAccess.Admin).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
            console.log(result);
        });

        this.proxyService.errorStringReturnType(true).subscribe(result => {
            console.log("\r\nSuccess TypeScript Service Call 'errorStringReturnType' Result: ");
            console.log(result);
        }, errorResult => {
            //Only gets Called if the ErrorResponse is active and returns only the errorResult and not only the Data.
            console.log("\r\nError TypeScript Service Call 'errorStringReturnType' Result: ");
            console.log(errorResult);
        });
    }
}