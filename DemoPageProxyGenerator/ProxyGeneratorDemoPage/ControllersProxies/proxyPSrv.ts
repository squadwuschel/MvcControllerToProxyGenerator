//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 13.01.2016 time 20:48 from SquadWuschel.

  module App.Services { 

export interface IProxyPSrv { 
     addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    loadTsCallById(id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    loadTsCallByParams(name: string,vorname: string,alter: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>;
    loadAllAutosListe(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>;
    loadAllAutosArray(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>;
    clearTsCall() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
    voidTsReturnType(name: string): void;
    stringTsReturnType(name: string) : ng.IPromise<string>;
    integerTsReturnType(age: number) : ng.IPromise<number>;
    dateTsReturnType(name: string) : ng.IPromise<Date>;
    boolTsReturnType(boolValue: boolean) : ng.IPromise<boolean>;
    errorStringReturnType(boolValue: boolean) : ng.IPromise<string>;
 }

export class ProxyPSrv implements IProxyPSrv {
    static $inject = ['$http']; 
   constructor(private $http: ng.IHttpService) { } 

public addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.post('Proxy/AddTsEntryOnly',person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
} 

public addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
} 

public addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
} 

public loadTsCallById(id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.get('Proxy/LoadTsCallById' + '/' + id).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
} 

public loadTsCallByParams(name: string,vorname: string,alter: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
} 

public loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
} 

public loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; });
} 

public loadAllAutosListe(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
    return this.$http.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return response.data; });
} 

public loadAllAutosArray(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
    return this.$http.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return response.data; });
} 

public clearTsCall() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.get('Proxy/ClearTsCall').then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; });
} 

public voidTsReturnType(name: string) : void  { 
    this.$http.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)); 
 } 

public stringTsReturnType(name: string) : ng.IPromise<string> { 
    return this.$http.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<string>) : string => { return response.data; });
} 

public integerTsReturnType(age: number) : ng.IPromise<number> { 
    return this.$http.get('Proxy/IntegerTsReturnType'+ '?age='+age).then((response: ng.IHttpPromiseCallbackArg<number>) : number => { return response.data; });
} 

public dateTsReturnType(name: string) : ng.IPromise<Date> { 
    return this.$http.get('Proxy/DateTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<Date>) : Date => { return response.data; });
} 

public boolTsReturnType(boolValue: boolean) : ng.IPromise<boolean> { 
    return this.$http.get('Proxy/BoolTsReturnType'+ '?boolValue='+boolValue).then((response: ng.IHttpPromiseCallbackArg<boolean>) : boolean => { return response.data; });
} 

public errorStringReturnType(boolValue: boolean) : ng.IPromise<string> { 
    return this.$http.get('Proxy/ErrorStringReturnType'+ '?boolValue='+boolValue).then((response: ng.IHttpPromiseCallbackArg<string>) : string => { return response.data; });
} 

//#region Angular Module Definition 
  private static _module: ng.IModule; 
  public static get module(): ng.IModule {
      if (this._module) { return this._module; }
      this._module = angular.module('ProxyPSrv', []);
      this._module.service('ProxyPSrv', ProxyPSrv);
      return this._module; 
   }
 //#endregion 

   } 
 }

