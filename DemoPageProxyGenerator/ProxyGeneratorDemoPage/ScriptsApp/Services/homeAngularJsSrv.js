//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 24.10.2017 time 09:04 from jrenatus.

 

  function homeAngularJsSrv($http) { this.http = $http; } 


homeAngularJsSrv.prototype.addOrUpdatePerson = function (person) { 
    return this.http.post('Home/AddOrUpdatePerson',person).then(function (result) {
        return result.data;
   });
}

homeAngularJsSrv.prototype.getAllPersons = function () { 
    return this.http.get('Home/GetAllPersons').then(function (result) {
        return result.data;
   });
}

homeAngularJsSrv.prototype.searchPerson = function (name) { 
    return this.http.get('Home/SearchPerson'+ '?name='+encodeURIComponent(name)).then(function (result) {
        return result.data;
   });
}


angular.module('homeAngularJsSrv', []) .service('homeAngularJsSrv', ['$http', homeAngularJsSrv]);

