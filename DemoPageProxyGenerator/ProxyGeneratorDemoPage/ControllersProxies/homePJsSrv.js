//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 16.12.2015 time 16:19 from SquadWuschel.

  function homePJsSrv($http) { this.http = $http; } 


homePJsSrv.prototype.addOrUpdatePerson = function (person) { 
   return this.http.post('Home/AddOrUpdatePerson',person).then(function (result) {
        return result.data;
   });
}

homePJsSrv.prototype.getAllPersons = function () { 
   return this.http.get('Home/GetAllPersons').then(function (result) {
        return result.data;
   });
}

homePJsSrv.prototype.searchPerson = function (name) { 
   return this.http.get('Home/SearchPerson'+ '?name='+encodeURIComponent(name)).then(function (result) {
        return result.data;
   });
}


angular.module('homePJsSrv', []) .service('homePJsSrv', ['$http', homePJsSrv]);

