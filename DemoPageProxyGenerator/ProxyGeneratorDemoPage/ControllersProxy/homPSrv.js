
//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 25.11.2015 time 22:52 from SquadWuschel.

 function homPSrv($http) { this.http = $http; } 


homPSrv.prototype.addOrUpdatePerson = function (person) { 
   return this.http.post('Home/AddOrUpdatePerson',person).then(function (result) {
        return result.data;
   });
}

homPSrv.prototype.getAllPersons = function () { 
   return this.http.get('Home/GetAllPersons').then(function (result) {
        return result.data;
   });
}

homPSrv.prototype.searchPerson = function (name) { 
   return this.http.get('Home/SearchPerson'+ '?name='+encodeURIComponent(name)).then(function (result) {
        return result.data;
   });
}




angular.module('homPSrv', []) .service('homPSrv', ['$http', homPSrv]);

