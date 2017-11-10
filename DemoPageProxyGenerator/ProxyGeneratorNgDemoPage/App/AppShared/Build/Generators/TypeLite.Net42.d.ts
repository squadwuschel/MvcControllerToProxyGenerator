
 
 

 

/// <reference path="Enums.ts" />

declare module ProxyGeneratorNgDemoPage.Models {
	interface IAuto {
		Alter: number;
		Eigentuemer: ProxyGeneratorNgDemoPage.Models.IPerson;
		Marke: string;
	}
	interface ICompany {
		Age: number;
		ClientAccess: ProxyGeneratorNgDemoPage.Models.ClientAccess;
		Name: string;
	}
	interface IPerson {
		CounterValues: number[];
		Id: number;
		IsAktiv: boolean;
		Name: string;
		Passwort: string;
	}
}


