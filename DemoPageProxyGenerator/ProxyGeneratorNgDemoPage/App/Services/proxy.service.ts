//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 10.11.2017 time 19:56 from squad.

  import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/observable';
import 'rxjs/add/operator/map';

@Injectable()
export class Proxyservice { 

constructor(private http: Http) {  }

      public addFileToServer(datei: any,detailId: number) : Observable<ProxyGeneratorNgDemoPage.Models.IPerson> { 
     var formData = new FormData(); 
 formData.append('datei', datei); 
       return this.http.post('Proxy/AddFileToServer'+ '?detailId='+detailId,formData).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IPerson>response.json() as ProxyGeneratorNgDemoPage.Models.IPerson);
     } 

    public addFileToServerNoReturnType(datei: any,detailId: number) : void  { 
  var formData = new FormData(); 
 formData.append('datei', datei); 
      this.http.post('Proxy/AddFileToServerNoReturnType'+ '?detailId='+detailId,formData).subscribe(res => res.json()); 
     } 

    //public getDownloadPerson(personId: number,person: ProxyGeneratorNgDemoPage.Models.IPerson) : void  { 
    //    window.location.href = 'Proxy/GetDownloadPerson'+ '?personId='+personId+'&'+jQuery.param(person); 
    //} 

    //public getDownloadCompany(companyId: number,company: ProxyGeneratorNgDemoPage.Models.ICompany) : void  { 
    //    window.location.href = 'Proxy/GetDownloadCompany'+ '?companyId='+companyId+'&'+jQuery.param(company); 
    //} 

    public getDownloadSimple(companyId: number,name: string) : void  { 
        window.location.href = 'Proxy/GetDownloadSimple'+ '?companyId='+companyId+'&name='+encodeURIComponent(name); 
    } 

    public getDownloadNoParams() : void  { 
        window.location.href = 'Proxy/GetDownloadNoParams'; 
    } 

     public manySimpleParams(page: number,size: number,sortedCol: number,desc: number,smCompany: string,smCustomerNumber: number,smEmail: string,smLastname: string,portal: number,count: number) : Observable<ProxyGeneratorNgDemoPage.Models.IPerson> { 
            return this.http.get('Proxy/ManySimpleParams'+ '?page='+page+'&size='+size+'&sortedCol='+sortedCol+'&desc='+desc+'&smCompany='+encodeURIComponent(smCompany)+'&smCustomerNumber='+smCustomerNumber+'&smEmail='+encodeURIComponent(smEmail)+'&smLastname='+encodeURIComponent(smLastname)+'&portal='+portal+'&count='+count).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IPerson>response.json() as ProxyGeneratorNgDemoPage.Models.IPerson);
     } 

     public addAges(ages: number[]) : Observable<number[]> { 
            return this.http.post('Proxy/AddAges',ages).map((response: Response)  => <number[]>response.json() as number[]);
     } 

     public addTsEntryOnly(person: ProxyGeneratorNgDemoPage.Models.IPerson) : Observable<ProxyGeneratorNgDemoPage.Models.IPerson> { 
            return this.http.post('Proxy/AddTsEntryOnly',person).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IPerson>response.json() as ProxyGeneratorNgDemoPage.Models.IPerson);
     } 

     public addTsEntryAndName(person: ProxyGeneratorNgDemoPage.Models.IPerson,name: string) : Observable<ProxyGeneratorNgDemoPage.Models.IAuto> { 
            return this.http.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IAuto>response.json() as ProxyGeneratorNgDemoPage.Models.IAuto);
     } 

     public addTsEntryAndParams(person: ProxyGeneratorNgDemoPage.Models.IPerson,name: string,vorname: string) : Observable<ProxyGeneratorNgDemoPage.Models.IAuto> { 
            return this.http.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IAuto>response.json() as ProxyGeneratorNgDemoPage.Models.IAuto);
     } 

     public loadTsCallById(id: number) : Observable<ProxyGeneratorNgDemoPage.Models.IPerson> { 
            return this.http.get('Proxy/LoadTsCallById' + '/' + id).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IPerson>response.json() as ProxyGeneratorNgDemoPage.Models.IPerson);
     } 

     public loadTsCallByParams(name: string,vorname: string,alter: number) : Observable<ProxyGeneratorNgDemoPage.Models.IPerson> { 
            return this.http.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IPerson>response.json() as ProxyGeneratorNgDemoPage.Models.IPerson);
     } 

     public loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : Observable<ProxyGeneratorNgDemoPage.Models.IAuto> { 
            return this.http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IAuto>response.json() as ProxyGeneratorNgDemoPage.Models.IAuto);
     } 

     public loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorNgDemoPage.Models.ClientAccess) : Observable<ProxyGeneratorNgDemoPage.Models.IAuto> { 
            return this.http.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IAuto>response.json() as ProxyGeneratorNgDemoPage.Models.IAuto);
     } 

     public loadAllAutosListe(name: string) : Observable<ProxyGeneratorNgDemoPage.Models.IAuto[]> { 
            return this.http.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IAuto[]>response.json() as ProxyGeneratorNgDemoPage.Models.IAuto[]);
     } 

     public loadAllAutosArray(name: string) : Observable<ProxyGeneratorNgDemoPage.Models.IAuto[]> { 
            return this.http.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IAuto[]>response.json() as ProxyGeneratorNgDemoPage.Models.IAuto[]);
     } 

     public clearTsCall() : Observable<ProxyGeneratorNgDemoPage.Models.IPerson> { 
            return this.http.get('Proxy/ClearTsCall').map((response: Response)  => <ProxyGeneratorNgDemoPage.Models.IPerson>response.json() as ProxyGeneratorNgDemoPage.Models.IPerson);
     } 

    public voidTsReturnType(name: string) : void  { 
        this.http.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)).subscribe(res => res.json()); 
     } 

     public stringTsReturnType(name: string) : Observable<string> { 
            return this.http.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <string>response.json() as string);
     } 

     public integerTsReturnType(age: number) : Observable<number> { 
            return this.http.get('Proxy/IntegerTsReturnType'+ '?age='+age).map((response: Response)  => <number>response.json() as number);
     } 

     public dateTsReturnType(name: string) : Observable<any> { 
            return this.http.get('Proxy/DateTsReturnType'+ '?name='+encodeURIComponent(name)).map((response: Response)  => <any>response.json() as any);
     } 

     public boolTsReturnType(boolValue: boolean) : Observable<boolean> { 
            return this.http.get('Proxy/BoolTsReturnType'+ '?boolValue='+boolValue).map((response: Response)  => <boolean>response.json() as boolean);
     } 

     public errorStringReturnType(boolValue: boolean) : Observable<string> { 
            return this.http.get('Proxy/ErrorStringReturnType'+ '?boolValue='+boolValue).map((response: Response)  => <string>response.json() as string);
     } 


 }

