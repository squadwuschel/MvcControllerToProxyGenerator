class Company implements ProxyGeneratorDemoPage.Helper.ICompany {
    constructor(public Name: string, public Age: number, public ClientAccess: ProxyGeneratorDemoPage.Helper.ClientAccess) { }
}