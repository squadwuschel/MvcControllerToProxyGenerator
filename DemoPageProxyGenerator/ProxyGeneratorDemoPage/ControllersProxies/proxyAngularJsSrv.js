//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 23.01.2016 time 19:10 from SquadWuschel.

  function proxyAngularJsSrv($http) { this.http = $http; } 


proxyAngularJsSrv.prototype.addJsEntryOnly = function (person) { 
   return this.http.post('Proxy/AddJsEntryOnly',person).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.addJsEntryAndName = function (person,name) { 
   return this.http.post('Proxy/AddJsEntryAndName'+ '?name='+encodeURIComponent(name),person).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.addJsEntryAndParams = function (person,name,vorname) { 
   return this.http.post('Proxy/AddJsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname),person).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.clearJsCall = function () { 
   return this.http.get('Proxy/ClearJsCall').then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.loadJsCallById = function (id) { 
   return this.http.get('Proxy/LoadJsCallById' + '/' + id).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.loadJsCallByParams = function (name,vorname,alter) { 
   return this.http.get('Proxy/LoadJsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.loadJsCallByParamsAndId = function (name,vorname,alter,id) { 
   return this.http.get('Proxy/LoadJsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.loadJsCallByParamsWithEnum = function (name,vorname,alter,access) { 
   return this.http.get('Proxy/LoadJsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then(function (result) {
        return result.data;
   });
}


angular.module('proxyAngularJsSrv', []) .service('proxyAngularJsSrv', ['$http', proxyAngularJsSrv]);

