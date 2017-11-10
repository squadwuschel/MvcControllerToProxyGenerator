export class Auto implements ProxyGeneratorNgDemoPage.Models.IAuto {
    constructor(public Marke: string, public Alter: number, public Eigentuemer: ProxyGeneratorNgDemoPage.Models.IPerson) {  }
}