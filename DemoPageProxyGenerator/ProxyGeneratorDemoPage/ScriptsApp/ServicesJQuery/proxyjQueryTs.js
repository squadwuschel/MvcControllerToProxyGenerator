//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 01.07.2016 time 21:25 from SquadWuschel.
var App;
(function (App) {
    var JqueryServices;
    (function (JqueryServices) {
        var proxyjQueryTs = (function () {
            function proxyjQueryTs() {
            }
            proxyjQueryTs.prototype.testView = function () {
                return jQuery.get('Proxy/TestView').then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.addFileToServer = function (datei, detailId) {
                var formData = new FormData();
                formData.append('datei', datei);
                return jQuery.ajax({ url: 'Proxy/AddFileToServer' + '?detailId=' + detailId, data: formData, processData: false, contentType: false, type: "POST" }).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.addFileToServerNoReturnType = function (datei, detailId) {
                var formData = new FormData();
                formData.append('datei', datei);
                jQuery.ajax({ url: 'Proxy/AddFileToServerNoReturnType' + '?detailId=' + detailId, data: formData, processData: false, contentType: false, type: "POST" });
            };
            proxyjQueryTs.prototype.getDownloadPerson = function (personId, person) {
                window.location.href = 'Proxy/GetDownloadPerson' + '?personId=' + personId + '&' + jQuery.param(person);
            };
            proxyjQueryTs.prototype.getDownloadCompany = function (companyId, company) {
                window.location.href = 'Proxy/GetDownloadCompany' + '?companyId=' + companyId + '&' + jQuery.param(company);
            };
            proxyjQueryTs.prototype.getDownloadSimple = function (companyId, name) {
                window.location.href = 'Proxy/GetDownloadSimple' + '?companyId=' + companyId + '&name=' + encodeURIComponent(name);
            };
            proxyjQueryTs.prototype.getDownloadNoParams = function () {
                window.location.href = 'Proxy/GetDownloadNoParams';
            };
            proxyjQueryTs.prototype.manySimpleParams = function (page, size, sortedCol, desc, smCompany, smCustomerNumber, smEmail, smLastname, portal, count) {
                return jQuery.get('Proxy/ManySimpleParams' + '?page=' + page + '&size=' + size + '&sortedCol=' + sortedCol + '&desc=' + desc + '&smCompany=' + encodeURIComponent(smCompany) + '&smCustomerNumber=' + smCustomerNumber + '&smEmail=' + encodeURIComponent(smEmail) + '&smLastname=' + encodeURIComponent(smLastname) + '&portal=' + portal + '&count=' + count).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.addAges = function (ages) {
                return jQuery.ajax({ url: 'Proxy/AddAges', data: JSON.stringify(ages), type: "POST", contentType: "application/json; charset=utf-8" }).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.addTsEntryOnly = function (person) {
                return jQuery.ajax({ url: 'Proxy/AddTsEntryOnly', data: JSON.stringify(person), type: "POST", contentType: "application/json; charset=utf-8" }).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.addTsEntryAndName = function (person, name) {
                return jQuery.ajax({ url: 'Proxy/AddTsEntryAndName' + '?name=' + encodeURIComponent(name), data: JSON.stringify(person), type: "POST", contentType: "application/json; charset=utf-8" }).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.addTsEntryAndParams = function (person, name, vorname) {
                return jQuery.ajax({ url: 'Proxy/AddTsEntryAndParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname), data: JSON.stringify(person), type: "POST", contentType: "application/json; charset=utf-8" }).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.loadTsCallById = function (id) {
                return jQuery.get('Proxy/LoadTsCallById' + '/' + id).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.loadTsCallByParams = function (name, vorname, alter) {
                return jQuery.get('Proxy/LoadTsCallByParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.loadTsCallByParamsAndId = function (name, vorname, alter, id) {
                return jQuery.get('Proxy/LoadTsCallByParamsAndId' + '/' + id + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.loadTsCallByParamsWithEnum = function (name, vorname, alter, access) {
                return jQuery.get('Proxy/LoadTsCallByParamsWithEnum' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter + '&access=' + access).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.loadAllAutosListe = function (name) {
                return jQuery.get('Proxy/LoadAllAutosListe' + '?name=' + encodeURIComponent(name)).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.loadAllAutosArray = function (name) {
                return jQuery.get('Proxy/LoadAllAutosArray' + '?name=' + encodeURIComponent(name)).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.clearTsCall = function () {
                return jQuery.get('Proxy/ClearTsCall').then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.voidTsReturnType = function (name) {
                jQuery.get('Proxy/VoidTsReturnType' + '?name=' + encodeURIComponent(name));
            };
            proxyjQueryTs.prototype.stringTsReturnType = function (name) {
                return jQuery.get('Proxy/StringTsReturnType' + '?name=' + encodeURIComponent(name)).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.integerTsReturnType = function (age) {
                return jQuery.get('Proxy/IntegerTsReturnType' + '?age=' + age).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.dateTsReturnType = function (name) {
                return jQuery.get('Proxy/DateTsReturnType' + '?name=' + encodeURIComponent(name)).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.boolTsReturnType = function (boolValue) {
                return jQuery.get('Proxy/BoolTsReturnType' + '?boolValue=' + boolValue).then(function (result) { return result; });
            };
            proxyjQueryTs.prototype.errorStringReturnType = function (boolValue) {
                return jQuery.get('Proxy/ErrorStringReturnType' + '?boolValue=' + boolValue).then(function (result) { return result; });
            };
            return proxyjQueryTs;
        })();
        JqueryServices.proxyjQueryTs = proxyjQueryTs;
    })(JqueryServices = App.JqueryServices || (App.JqueryServices = {}));
})(App || (App = {}));
//# sourceMappingURL=proxyjQueryTs.js.map