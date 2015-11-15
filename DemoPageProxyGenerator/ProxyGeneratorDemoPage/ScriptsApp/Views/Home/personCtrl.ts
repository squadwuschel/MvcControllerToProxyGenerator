
class personLocals {
    showNewUser: boolean = false;
    newUserModel: Person;
    searchResult : Person[] = [];
}

function personCtrl(homeSrv: IHomeSrv) {
    this.homeSrv = homeSrv;
    this.Name = "Johannes";
    this.locals = new personLocals();
}

personCtrl.prototype.AddNewUser = function() {
    this.locals.showNewUser = true;
    this.locals.newUserModel = new Person(0, "", new Date(),"",true);
}

personCtrl.prototype.CreateUser = function () {
    this.homeSrv.AddOrUpdatePerson(this.locals.newUserModel).then((result) => {
        this.Search();
    });
}

personCtrl.prototype.Search = function () {
    this.homeSrv.GetAllPersons().then((result) => {
        this.locals.searchResult = result;
    });
}


angular.module("personCtrl", [])
    .controller("personCtrl", ["homeSrv", personCtrl]);