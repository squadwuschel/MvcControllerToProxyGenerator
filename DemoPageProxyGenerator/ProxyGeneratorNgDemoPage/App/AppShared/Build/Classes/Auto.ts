class Auto implements ProxyGeneratorDemoPage.Models.Person.Models.IAuto {
    constructor(public Marke: string, public Alter: number, public Eigentuemer: ProxyGeneratorDemoPage.Models.Person.Models.IPerson) {  }
}