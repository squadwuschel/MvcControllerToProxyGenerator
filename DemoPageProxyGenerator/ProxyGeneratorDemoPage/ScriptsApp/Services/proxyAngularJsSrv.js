//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 24.10.2017 time 09:04 from jrenatus.

 

  function proxyAngularJsSrv($http) { this.http = $http; } 


proxyAngularJsSrv.prototype.addFileToServer = function (datei,detailId) { 
 var formData = new FormData(); 
 formData.append('datei', datei); 
   return this.http.post('Proxy/AddFileToServer'+ '?detailId='+detailId,formData, { transformRequest: angular.identity, headers: { 'Content-Type': undefined }}).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.addFileToServerNoReturnType = function (datei,detailId) { 
 var formData = new FormData(); 
 formData.append('datei', datei); 
   return this.http.post('Proxy/AddFileToServerNoReturnType'+ '?detailId='+detailId,formData, { transformRequest: angular.identity, headers: { 'Content-Type': undefined }}).then(function (result) {
        return result.data;
   });
}

proxyAngularJsSrv.prototype.getDownloadPerson = function (personId,person) { 
    window.location.href = 'Proxy/GetDownloadPerson'+ '?personId='+personId+'&'+jQuery.param(person) } 

 proxyAngularJsSrv.prototype.getDownloadCompany = function (companyId,company) { 
    window.location.href = 'Proxy/GetDownloadCompany'+ '?companyId='+companyId+'&'+jQuery.param(company) } 

 proxyAngularJsSrv.prototype.getDownloadSimple = function (companyId,name) { 
    window.location.href = 'Proxy/GetDownloadSimple'+ '?companyId='+companyId+'&name='+encodeURIComponent(name) } 

 proxyAngularJsSrv.prototype.getDownloadNoParams = function () { 
    window.location.href = 'Proxy/GetDownloadNoParams' } 

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

