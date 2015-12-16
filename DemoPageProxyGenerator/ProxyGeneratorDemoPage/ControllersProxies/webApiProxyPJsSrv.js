//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 16.12.2015 time 16:19 from SquadWuschel.

  function webApiProxyPJsSrv($http) { this.http = $http; } 


webApiProxyPJsSrv.prototype.get = function () { 
   return this.http.get('WebApiProxy/Get').then(function (result) {
        return result.data;
   });
}

webApiProxyPJsSrv.prototype.getItem = function (id) { 
   return this.http.get('WebApiProxy/GetItem' + '/' + id).then(function (result) {
        return result.data;
   });
}

webApiProxyPJsSrv.prototype.put = function (id,value) { 
   return this.http.get('WebApiProxy/Put' + '/' + id+ '?value='+encodeURIComponent(value)).then(function (result) {
        return result.data;
   });
}

webApiProxyPJsSrv.prototype.delete = function (id) { 
   return this.http.get('WebApiProxy/Delete' + '/' + id).then(function (result) {
        return result.data;
   });
}


angular.module('webApiProxyPJsSrv', []) .service('webApiProxyPJsSrv', ['$http', webApiProxyPJsSrv]);

