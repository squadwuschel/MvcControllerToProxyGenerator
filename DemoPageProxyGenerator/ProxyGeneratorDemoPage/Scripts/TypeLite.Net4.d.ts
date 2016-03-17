
 
 

 

/// <reference path="Enums.ts" />

declare module ProxyGeneratorDemoPage.Models.Person.Models {
	interface Auto {
		Marke: string;
		Alter: number;
		Eigentuemer: ProxyGeneratorDemoPage.Models.Person.Models.Person;
	}
	interface Person {
		Id: number;
		Name: string;
		Passwort: string;
		IsAktiv: boolean;
		CounterValues: number[];
	}
}
declare module ProxyGeneratorDemoPage.Helper {
	interface Oberklasse<T> {
		DatenklassenListe: T[];
		Test: T[];
		Dict: System.Collections.Generic.KeyValuePair<string, T>[];
		Abc: string;
		Info: ProxyGeneratorDemoPage.Helper.Infoklasse;
	}
	interface Infoklasse {
		InfoNr: number;
		Bemerkungen: string;
	}
	interface Datenklasse {
		Id: number;
		Textdaten: string;
		Info: ProxyGeneratorDemoPage.Helper.Infoklasse;
	}
}
declare module System.Collections.Generic {
	interface KeyValuePair<TKey, TValue> {
		Key: TKey;
		Value: TValue;
	}
}


