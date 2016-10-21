//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 21.10.2016 time 22:57 from squad.

  import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/observable';
import 'rxjs/add/operator/map';

@Injectable()
export class Proxyservice { 

constructor(private _http: Http) {  }

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

     public manySimpleParams(page: number,size: number,sortedCol: number,desc: number,smCompany: string,smCustomerNumber: number,smEmail: string,smLastname: string,portal: number,count: number) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
          return this._http.get('Proxy/ManySimpleParams'+ '?page='+page+'&size='+size+'&sortedCol='+sortedCol+'&desc='+desc+'&smCompany='+encodeURIComponent(smCompany)+'&smCustomerNumber='+smCustomerNumber+'&smEmail='+encodeURIComponent(smEmail)+'&smLastname='+encodeURIComponent(smLastname)+'&portal='+portal+'&count='+count).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IPerson>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IPerson);
} 

     public addAges(ages: number[]) : Observable<number[]> { 
          return this._http.post('Proxy/AddAges',ages).map((response: Response)  => <number[]>response.json() as number[]);
} 

     public addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
          return this._http.post('Proxy/AddTsEntryOnly',person).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IPerson>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IPerson);
} 

     public addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
          return this._http.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IAuto>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IAuto);
} 

     public addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
          return this._http.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IAuto>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IAuto);
} 

     public loadTsCallById(id: number) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
          return this._http.get('Proxy/LoadTsCallById' + '/' + id).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IPerson>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IPerson);
} 

     public loadTsCallByParams(name: string,vorname: string,alter: number) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
          return this._http.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IPerson>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IPerson);
} 

     public loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
          return this._http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IAuto>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IAuto);
} 

     public loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
          return this._http.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IAuto>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IAuto);
} 

     public loadAllAutosListe(name: string) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
          return this._http.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]);
} 

     public loadAllAutosArray(name: string) : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
          return this._http.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]);
} 

     public clearTsCall() : Observable<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
          return this._http.get('Proxy/ClearTsCall').map((response: Response)  => <ProxyGeneratorDemoPage.Models.Person.Models.IPerson>response.json() as ProxyGeneratorDemoPage.Models.Person.Models.IPerson);
} 

    public voidTsReturnType(name: string) : void  { 
    this._http.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)).subscribe(res => res.json()); 
 } 

     public stringTsReturnType(name: string) : Observable<string> { 
          return this._http.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <string>response.json() as string);
} 

     public integerTsReturnType(age: number) : Observable<number> { 
          return this._http.get('Proxy/IntegerTsReturnType'+ '?age='+age).map((response: Response)  => <number>response.json() as number);
} 

     public dateTsReturnType(name: string) : Observable<any> { 
          return this._http.get('Proxy/DateTsReturnType'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <any>response.json() as any);
} 

     public boolTsReturnType(boolValue: boolean) : Observable<boolean> { 
          return this._http.get('Proxy/BoolTsReturnType'+ '?boolValue='+boolValue).map((response: Response)  => <boolean>response.json() as boolean);
} 

     public errorStringReturnType(boolValue: boolean) : Observable<string> { 
          return this._http.get('Proxy/ErrorStringReturnType'+ '?boolValue='+boolValue).map((response: Response)  => <string>response.json() as string);
} 


 }

