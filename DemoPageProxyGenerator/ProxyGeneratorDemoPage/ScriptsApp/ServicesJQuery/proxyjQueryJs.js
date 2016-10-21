//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 21.10.2016 time 22:57 from squad.

  window.proxyjQueryJs = function() { } 


proxyjQueryJs.prototype.addFileToServer = function (datei,detailId) { 
 var formData = new FormData(); 
 formData.append('datei', datei); 
   return jQuery.ajax( { url : 'Proxy/AddFileToServer'+ '?detailId='+detailId, data : formData, processData : false, contentType: false, type : "POST" }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.addFileToServerNoReturnType = function (datei,detailId) { 
 var formData = new FormData(); 
 formData.append('datei', datei); 
   return jQuery.ajax( { url : 'Proxy/AddFileToServerNoReturnType'+ '?detailId='+detailId, data : formData, processData : false, contentType: false, type : "POST" }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.getDownloadPerson = function (personId,person) { 
    window.location.href = 'Proxy/GetDownloadPerson'+ '?personId='+personId+'&'+jQuery.param(person) } 

 proxyjQueryJs.prototype.getDownloadCompany = function (companyId,company) { 
    window.location.href = 'Proxy/GetDownloadCompany'+ '?companyId='+companyId+'&'+jQuery.param(company) } 

 proxyjQueryJs.prototype.getDownloadSimple = function (companyId,name) { 
    window.location.href = 'Proxy/GetDownloadSimple'+ '?companyId='+companyId+'&name='+encodeURIComponent(name) } 

 proxyjQueryJs.prototype.getDownloadNoParams = function () { 
    window.location.href = 'Proxy/GetDownloadNoParams' } 

 proxyjQueryJs.prototype.addJsEntryOnly = function (person) { 
    return jQuery.ajax( { url : 'Proxy/AddJsEntryOnly', data : JSON.stringify(person), type : "POST", contentType: "application/json; charset=utf-8" }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.addJsEntryAndName = function (person,name) { 
    return jQuery.ajax( { url : 'Proxy/AddJsEntryAndName'+ '?name='+encodeURIComponent(name), data : JSON.stringify(person), type : "POST", contentType: "application/json; charset=utf-8" }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.addJsEntryAndParams = function (person,name,vorname) { 
    return jQuery.ajax( { url : 'Proxy/AddJsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname), data : JSON.stringify(person), type : "POST", contentType: "application/json; charset=utf-8" }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.clearJsCall = function () { 
    return jQuery.get('Proxy/ClearJsCall').then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.loadJsCallById = function (id) { 
    return jQuery.get('Proxy/LoadJsCallById' + '/' + id).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.loadJsCallByParams = function (name,vorname,alter) { 
    return jQuery.get('Proxy/LoadJsCallByParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.loadJsCallByParamsAndId = function (name,vorname,alter,id) { 
    return jQuery.get('Proxy/LoadJsCallByParamsAndId' + '/' + id+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.loadJsCallByParamsWithEnum = function (name,vorname,alter,access) { 
    return jQuery.get('Proxy/LoadJsCallByParamsWithEnum'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname)+'&alter='+alter+'&access='+access).then(function (result) {
        return result;
   });
}




