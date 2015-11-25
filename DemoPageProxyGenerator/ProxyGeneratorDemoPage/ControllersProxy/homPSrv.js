
//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 25.11.2015 time 22:58 from SquadWuschel.

 function homPSrv($http) { this.http = $http; } 


homPSrv.prototype.addOrUpdatePerson = function (person) { 
   return this.http.post('HomeC/AddOrUpdatePerson',person).then(function (result) {
        return result.data;
   });
}

homPSrv.prototype.getAllPersons = function () { 
   return this.http.get('HomeC/GetAllPersons').then(function (result) {
        return result.data;
   });
}

homPSrv.prototype.searchPerson = function (name) { 
   return this.http.get('HomeC/SearchPerson'+ '?name='+encodeURIComponent(name)).then(function (result) {
        return result.data;
   });
}




angular.module('homPSrv', []) .service('homPSrv', ['$http', homPSrv]);

