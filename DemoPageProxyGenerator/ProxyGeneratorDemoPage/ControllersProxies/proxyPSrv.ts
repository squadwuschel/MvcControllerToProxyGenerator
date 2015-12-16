//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 16.12.2015 time 16:19 from SquadWuschel.

  module App.Services { 

export interface IProxyPSrv {     getAllPersons(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]>;
    addOrUpdatePerson(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,test: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>;
 }

export class ProxyPSrv implements IProxyPSrv {
    static $inject = ['$http']; 
   constructor(private $http: ng.IHttpService) { } 

getAllPersons(name: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]> { 
    return this.$http.get('Proxy/GetAllPersons'+ '?name='+encodeURIComponent(name)).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson[] => { return response.data; } );
} 

addOrUpdatePerson(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,test: string) : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
    return this.$http.post('Proxy/AddOrUpdatePerson'+ '?test='+encodeURIComponent(test),person).then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return response.data; } );
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

