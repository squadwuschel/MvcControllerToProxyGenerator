
//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 26.11.2015 time 20:25 from SquadWuschel.

 function homePSrv($http) { this.http = $http; } 


homePSrv.prototype.addOrUpdatePerson = function (person) { 
   return this.http.post('Home/AddOrUpdatePerson',person).then(function (result) {
        return result.data;
   });
}

homePSrv.prototype.getAllPersons = function () { 
   return this.http.get('Home/GetAllPersons').then(function (result) {
        return result.data;
   });
}

homePSrv.prototype.searchPerson = function (name) { 
   return this.http.get('Home/SearchPerson'+ '?name='+encodeURIComponent(name)).then(function (result) {
        return result.data;
   });
}




angular.module('homePSrv', []) .service('homePSrv', ['$http', homePSrv]);

