//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 21.12.2015 time 13:47 from SquadWuschel.

  module App.Services { 

export interface IProxyPSrv {     addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
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
    integerTsReturnType(name: string) : ng.IPromise<number>;
    dateTsReturnType(name: string) : ng.IPromise<number>;
    boolTsReturnType(name: string) : ng.IPromise<boolean>;
 }

export class ProxyPSrv implements IProxyPSrv {
    static $inject = ['$http']; 
   constructor(private $http: ng.IHttpService) { } 

addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.post('Proxy/AddTsEntryOnly',person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; } );
} 

addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; } );
} 

addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; } );
} 

loadTsCallById(id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.get('Proxy/LoadTsCallById' + '/' + id).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; } );
} 

loadTsCallByParams(name: string,vorname: string,alter: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; } );
} 

loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; } );
} 

loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
    return this.$http.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return response.data; } );
} 

loadAllAutosListe(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
    return this.$http.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return response.data; } );
} 

loadAllAutosArray(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
    return this.$http.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return response.data; } );
} 

clearTsCall() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.get('Proxy/ClearTsCall').then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; } );
} 

voidTsReturnType(name: string) : void  { 
    this.$http.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)); 
 } 

stringTsReturnType(name: string) : ng.IPromise<string> { 
    return this.$http.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<string>) : string => { return response.data; } );
} 

integerTsReturnType(name: string) : ng.IPromise<number> { 
    return this.$http.get('Proxy/IntegerTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<number>) : number => { return response.data; } );
} 

dateTsReturnType(name: string) : ng.IPromise<number> { 
    return this.$http.get('Proxy/DateTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<number>) : number => { return response.data; } );
} 

boolTsReturnType(name: string) : ng.IPromise<boolean> { 
    return this.$http.get('Proxy/BoolTsReturnType'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<boolean>) : boolean => { return response.data; } );
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

