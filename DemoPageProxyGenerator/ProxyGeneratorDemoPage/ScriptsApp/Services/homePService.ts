//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 25.02.2016 time 21:28 from SquadWuschel.

  module App.Services { 

export interface IHomePService { 
     getPerson(id: number): void;
    getAllAutos() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]>;
 }

export class HomePService implements IHomePService {
    static $inject = ['$http']; 
   constructor(private $http: ng.IHttpService) { } 

public getPerson(id: number) : void  { 
    this.$http.get('Home/GetPerson' + '/' + id); 
 } 

public getAllAutos() : ng.IPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]> { 
     return this.$http.get('Home/GetAllAutos').then((response: ng.IHttpPromiseCallbackArg<ProxyGeneratorDemoPage.Models.Person.Models.IPerson[]>) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson[] => { return response.data; });
} 

//#region Angular Module Definition 
  private static _module: ng.IModule; 
  public static get module(): ng.IModule {
      if (this._module) { return this._module; }
      this._module = angular.module('HomePService', []);
      this._module.service('HomePService', HomePService);
      return this._module; 
   }
 //#endregion 

   } 
 }

