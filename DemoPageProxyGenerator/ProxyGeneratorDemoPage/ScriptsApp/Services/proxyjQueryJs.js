//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 22.02.2016 time 22:31 from SquadWuschel.

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

proxyjQueryJs.prototype.addJsEntryOnly = function (person) { 
    return jQuery.ajax( { url : 'Proxy/AddJsEntryOnly', data : person }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.addJsEntryAndName = function (person,name) { 
    return jQuery.ajax( { url : 'Proxy/AddJsEntryAndName'+ '?name='+encodeURIComponent(name), data : person }).then(function (result) {
        return result;
   });
}

proxyjQueryJs.prototype.addJsEntryAndParams = function (person,name,vorname) { 
    return jQuery.ajax( { url : 'Proxy/AddJsEntryAndParams'+ '?name='+encodeURIComponent(name)+'&vorname='+encodeURIComponent(vorname), data : person }).then(function (result) {
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




