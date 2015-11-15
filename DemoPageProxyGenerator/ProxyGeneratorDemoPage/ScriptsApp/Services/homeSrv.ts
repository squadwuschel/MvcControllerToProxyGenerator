interface IHomeSrv {
    AddOrUpdatePerson(person: Person): number;
    GetPerson(id: number): Person;
    SearchPerson(name: string): Person[];
    GetAllPersons() : Person[];
}

function homeSrv($http: ng.IHttpService) {
    this.$http = $http;
}

homeSrv.prototype.AddOrUpdatePerson = function(person: Person) : number {
    return this.$http.post('/Home/AddOrUpdatePerson', person).then((result : ng.IHttpPromiseCallbackArg<number>) : number => {
        return result.data;
    });
}

homeSrv.prototype.GetPerson = function (id: number): Person {
    return this.$http.get('/Home/GetPerson?id=' + id).then((result: ng.IHttpPromiseCallbackArg<Person>) : Person => {
        return result.data;
    });
}

homeSrv.prototype.SearchPerson = function (name: string): Person[] {
    return this.$http.get('/Home/SearchPerson?name=' + name).then((result: ng.IHttpPromiseCallbackArg<Person[]>): Person[] => {
        return result.data;
    });
}

homeSrv.prototype.GetAllPersons = function (): Person[] {
    return this.$http.get('/Home/GetAllPersons').then((result: ng.IHttpPromiseCallbackArg<Person[]>): Person[] => {
        return result.data;
    });
}

angular.module("homeSrv", []).service("homeSrv", ["$http", homeSrv]);