export class Person implements ProxyGeneratorNgDemoPage.Models.IPerson {
    constructor(public Id: number, public Name: string, public Passwort: string, public IsAktiv: boolean, public CounterValues: number[]) {  }
}