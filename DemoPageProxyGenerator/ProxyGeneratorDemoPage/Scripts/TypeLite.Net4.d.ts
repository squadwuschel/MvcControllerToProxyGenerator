
 
 

 

/// <reference path="Enums.ts" />

declare  module ProxyGeneratorDemoPage.Models.Person.Models {
   interface IAuto {
		Marke: string;
		Alter: number;
		Eigentuemer: ProxyGeneratorDemoPage.Models.Person.Models.IPerson;
	}
	interface IPerson {
		Id: number;
		Name: string;
		Passwort: string;
		IsAktiv: boolean;
		CounterValues: number[];
	}
}
declare module ProxyGeneratorDemoPage.Helper {
	interface ICompany {
		Name: string;
		Age: number;
		ClientAccess: ProxyGeneratorDemoPage.Helper.ClientAccess;
	}
}


