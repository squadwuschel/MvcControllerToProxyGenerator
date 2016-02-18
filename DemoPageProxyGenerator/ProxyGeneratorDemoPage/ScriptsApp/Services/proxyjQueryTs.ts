//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 18.02.2016 time 22:02 from SquadWuschel.

  module App.JqueryServices { 

export interface IproxyjQueryTs { 
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

    public addTsEntryOnly(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
      return jQuery.post('Proxy/AddTsEntryOnly',person).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public addTsEntryAndName(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
      return jQuery.post('Proxy/AddTsEntryAndName'+ '?name='+encodeURIComponent(name),person).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public addTsEntryAndParams(person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson,name: string,vorname: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
      return jQuery.post('Proxy/AddTsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public loadTsCallById(id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
      return jQuery.get('Proxy/LoadTsCallById' + '/' + id).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public loadTsCallByParams(name: string,vorname: string,alter: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
      return jQuery.get('Proxy/LoadTsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public loadTsCallByParamsAndId(name: string,vorname: string,alter: number,id: number) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
      return jQuery.get('Proxy/LoadTsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public loadTsCallByParamsWithEnum(name: string,vorname: string,alter: number,access: ProxyGeneratorDemoPage.Helper.ClientAccess) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto> { 
      return jQuery.get('Proxy/LoadTsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto => { return result; });
    } 

    public loadAllAutosListe(name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
      return jQuery.get('Proxy/LoadAllAutosListe'+ '?name='+encodeURIComponent(name)).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return result; });
    } 

    public loadAllAutosArray(name: string) : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IAuto[]> { 
      return jQuery.get('Proxy/LoadAllAutosArray'+ '?name='+encodeURIComponent(name)).then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IAuto[] => { return result; });
    } 

    public clearTsCall() : JQueryPromise<ProxyGeneratorDemoPage.Models.Person.Models.IPerson> { 
      return jQuery.get('Proxy/ClearTsCall').then((result: {#ControllerProxyFileFunctionReturnType#}) : ProxyGeneratorDemoPage.Models.Person.Models.IPerson => { return result; });
    } 

    public voidTsReturnType(name: string) : void { jQuery.get('Proxy/VoidTsReturnType'+ '?name='+encodeURIComponent(name)) 
} 

    public stringTsReturnType(name: string) : JQueryPromise<string> { 
      return jQuery.get('Proxy/StringTsReturnType'+ '?name='+encodeURIComponent(name)).then((result: {#ControllerProxyFileFunctionReturnType#}) : string => { return result; });
    } 

    public integerTsReturnType(age: number) : JQueryPromise<number> { 
      return jQuery.get('Proxy/IntegerTsReturnType'+ '?age='+age).then((result: {#ControllerProxyFileFunctionReturnType#}) : number => { return result; });
    } 

    public dateTsReturnType(name: string) : JQueryPromise<any> { 
      return jQuery.get('Proxy/DateTsReturnType'+ '?name='+encodeURIComponent(name)).then((result: {#ControllerProxyFileFunctionReturnType#}) : any => { return result; });
    } 

    public boolTsReturnType(boolValue: boolean) : JQueryPromise<boolean> { 
      return jQuery.get('Proxy/BoolTsReturnType'+ '?boolValue='+boolValue).then((result: {#ControllerProxyFileFunctionReturnType#}) : boolean => { return result; });
    } 

    public errorStringReturnType(boolValue: boolean) : JQueryPromise<string> { 
      return jQuery.get('Proxy/ErrorStringReturnType'+ '?boolValue='+boolValue).then((result: {#ControllerProxyFileFunctionReturnType#}) : string => { return result; });
    } 

 
  }
}

