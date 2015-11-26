
//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten.
//Created on 26.11.2015 time 20:25 from SquadWuschel.

 function webApiProxyPSrv($http) { this.http = $http; } 


webApiProxyPSrv.prototype.get = function () { 
   return this.http.get('WebApiProxy/Get').then(function (result) {
        return result.data;
   });
}

webApiProxyPSrv.prototype.getItem = function (id) { 
   return this.http.get('WebApiProxy/GetItem' + '/' + id).then(function (result) {
        return result.data;
   });
}

webApiProxyPSrv.prototype.put = function (id,value) { 
   return this.http.get('WebApiProxy/Put' + '/' + id+ '?value='+encodeURIComponent(value)).then(function (result) {
        return result.data;
   });
}

webApiProxyPSrv.prototype.delete = function (id) { 
   return this.http.get('WebApiProxy/Delete' + '/' + id).then(function (result) {
        return result.data;
   });
}




angular.module('webApiProxyPSrv', []) .service('webApiProxyPSrv', ['$http', webApiProxyPSrv]);

