//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 21.10.2016 time 23:09 from squad.

  module App.JqueryServices { 

export interface IproxyjQueryTs { 
     testView() : JQueryPromise<string>;
    addFileToServer(datei: any,detailId: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    addFileToServerNoReturnType(datei: any,detailId: number): void;
    getDownloadPerson(personId: number,person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson): void;
    getDownloadCompany(companyId: number,company: ProxyGeneratorDemoPage.Helper.ICompany): void;
    getDownloadSimple(companyId: number,name: string): void;
    getDownloadNoParams(): void;
    manySimpleParams(page: number,size: number,sortedCol: number,desc: number,smCompany: string,smCustomerNumber: number,smEmail: string,smLastname: string,portal: number,count: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    addAges(ages: number[]) : JQueryPromise<number[]>;
    addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    loadTsCallById(id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    loadTsCallByParams(name: string,vorname: string,alter: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    loadAllAutosListe(name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>;
    loadAllAutosArray(name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>;
    clearTsCall() : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    voidTsReturnType(name: string): void;
    stringTsReturnType(name: string) : JQueryPromise<string>;
    integerTsReturnType(age: number) : JQueryPromise<number>;
    dateTsReturnType(name: string) : JQueryPromise<any>;
    boolTsReturnType(boolValue: boolean) : JQueryPromise<boolean>;
    errorStringReturnType(boolValue: boolean) : JQueryPromise<string>;
 }

export class proxyjQueryTs implements IproxyjQueryTs {

    public testView() : JQueryPromise<string> { 
       return jQuery.get('Proxy/TestView').then((result: string) : string => { return result; });
    } 

    public addFileToServer(datei: any,detailId: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
 var formData = new FormData(); 
 formData.append('datei', datei); 
      return jQuery.ajax( { url : 'Proxy/AddFileToServer'+ '?detailId='+detailId, data : formData, processData : false, contentType: false, type : "POST" }).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public addFileToServerNoReturnType(datei: any,detailId: number) : void { 
 var formData = new FormData(); 
 formData.append('datei', datei); 
 jQuery.ajax( { url : 'Proxy/AddFileToServerNoReturnType'+ '?detailId='+detailId, data : formData, processData : false, contentType: false, type : "POST" }); 
} 

    public getDownloadPerson(personId: number,person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : void  { 
    window.location.href = 'Proxy/GetDownloadPerson'+ '?personId='+personId+'&'+jQuery.param(person); 
 } 

    public getDownloadCompany(companyId: number,company: ProxyGeneratorDemoPage.Helper.ICompany) : void  { 
    window.location.href = 'Proxy/GetDownloadCompany'+ '?companyId='+companyId+'&'+jQuery.param(company); 
 } 

    public getDownloadSimple(companyId: number,name: string) : void  { 
    window.location.href = 'Proxy/GetDownloadSimple'+ '?companyId='+companyId+'&name='+encodeURIComponent(name); 
 } 

    public getDownloadNoParams() : void  { 
    window.location.href = 'Proxy/GetDownloadNoParams'; 
 } 

    public manySimpleParams(page: number,size: number,sortedCol: number,desc: number,smCompany: string,smCustomerNumber: number,smEmail: string,smLastname: string,portal: number,count: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
       return jQuery.get('Proxy/ManySimpleParams'+ '?page='+page+'&size='+size+'&sortedCol='+sortedCol+'&desc='+desc+'&smCompany='+encodeURIComponent(smCompany)+'&smCustomerNumber='+smCustomerNumber+'&smEmail='+encodeURIComponent(smEmail)+'&smLastname='+encodeURIComponent(smLastname)+'&portal='+portal+'&count='+count).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public addAges(ages: number[]) : JQueryPromise<number[]> { 
       return jQuery.ajax( { url : 'Proxy/AddAges', data : JSON.stringify(ages), type : "POST", contentType: "application/json; charset=utf-8" }).then((result: number[]) : number[] => { return result; });
    } 

    public addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
       return jQuery.ajax( { url : 'Proxy/AddTsEntryOnly', data : JSON.stringify(person), type : "POST", contentType: "application/json; charset=utf-8" }).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
       return jQuery.ajax( { url : 'Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name), data : JSON.stringify(person), type : "POST", contentType: "application/json; charset=utf-8" }).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
       return jQuery.ajax( { url : 'Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname), data : JSON.stringify(person), type : "POST", contentType: "application/json; charset=utf-8" }).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public loadTsCallById(id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
       return jQuery.get('Proxy/LoadTsCallById' + '/' + id).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public loadTsCallByParams(name: string,vorname: string,alter: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
       return jQuery.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
       return jQuery.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
       return jQuery.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public loadAllAutosListe(name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
       return jQuery.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return result; });
    } 

    public loadAllAutosArray(name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
       return jQuery.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).then((result: ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return result; });
    } 

    public clearTsCall() : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
       return jQuery.get('Proxy/ClearTsCall').then((result: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public voidTsReturnType(name: string) : void { 
  jQuery.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)); 
} 

    public stringTsReturnType(name: string) : JQueryPromise<string> { 
       return jQuery.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).then((result: string) : string => { return result; });
    } 

    public integerTsReturnType(age: number) : JQueryPromise<number> { 
       return jQuery.get('Proxy/IntegerTsReturnType'+ '?age='+age).then((result: number) : number => { return result; });
    } 

    public dateTsReturnType(name: string) : JQueryPromise<any> { 
       return jQuery.get('Proxy/DateTsReturnType'+ '?name='+encodeURIComponent(name)).then((result: any) : any => { return result; });
    } 

    public boolTsReturnType(boolValue: boolean) : JQueryPromise<boolean> { 
       return jQuery.get('Proxy/BoolTsReturnType'+ '?boolValue='+boolValue).then((result: boolean) : boolean => { return result; });
    } 

    public errorStringReturnType(boolValue: boolean) : JQueryPromise<string> { 
       return jQuery.get('Proxy/ErrorStringReturnType'+ '?boolValue='+boolValue).then((result: string) : string => { return result; });
    } 

 
  }
}

