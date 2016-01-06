//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 06.01.2016 time 22:10 from SquadWuschel.

  module App.Services { 

export interface IHomePSrv {     getPerson(id: number): void;
    getAllAutos() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]>;
 }

export class HomePSrv implements IHomePSrv {
    static $inject = ['$http']; 
   constructor(private $http: ng.IHttpService) { } 

getPerson(id: number) : void  { 
    this.$http.get('Home/GetPerson' + '/' + id); 
 } 

getAllAutos() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]> { 
    return this.$http.get('Home/GetAllAutos').then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson[] => { return response.data; } );
} 

//#region Angular Module Definition 
  private static _module: ng.IModule; 
  public static get module(): ng.IModule {
      if (this._module) { return this._module; }
      this._module = angular.module('HomePSrv', []);
      this._module.service('HomePSrv', HomePSrv);
      return this._module; 
   }
 //#endregion 

   } 
 }

