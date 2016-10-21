//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 01.07.2016 time 21:44 from SquadWuschel.
var App;
(function (App) {
    var Services;
    (function (Services) {
        var ProxyPService = (function () {
            function ProxyPService($http) {
                this.$http = $http;
            }
            ProxyPService.prototype.addFileToServer = function (datei, detailId) {
                var formData = new FormData();
                formData.append('datei', datei);
                return this.$http.post('Proxy/AddFileToServer' + '?detailId=' + detailId, formData, { transformRequest: angular.identity, headers: { 'Content-Type': undefined } }).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.addFileToServerNoReturnType = function (datei, detailId) {
                var formData = new FormData();
                formData.append('datei', datei);
                this.$http.post('Proxy/AddFileToServerNoReturnType' + '?detailId=' + detailId, formData, { transformRequest: angular.identity, headers: { 'Content-Type': undefined } });
            };
            ProxyPService.prototype.getDownloadPerson = function (personId, person) {
                window.location.href = 'Proxy/GetDownloadPerson' + '?personId=' + personId + '&' + jQuery.param(person);
            };
            ProxyPService.prototype.getDownloadCompany = function (companyId, company) {
                window.location.href = 'Proxy/GetDownloadCompany' + '?companyId=' + companyId + '&' + jQuery.param(company);
            };
            ProxyPService.prototype.getDownloadSimple = function (companyId, name) {
                window.location.href = 'Proxy/GetDownloadSimple' + '?companyId=' + companyId + '&name=' + encodeURIComponent(name);
            };
            ProxyPService.prototype.getDownloadNoParams = function () {
                window.location.href = 'Proxy/GetDownloadNoParams';
            };
            ProxyPService.prototype.manySimpleParams = function (page, size, sortedCol, desc, smCompany, smCustomerNumber, smEmail, smLastname, portal, count) {
                return this.$http.get('Proxy/ManySimpleParams' + '?page=' + page + '&size=' + size + '&sortedCol=' + sortedCol + '&desc=' + desc + '&smCompany=' + encodeURIComponent(smCompany) + '&smCustomerNumber=' + smCustomerNumber + '&smEmail=' + encodeURIComponent(smEmail) + '&smLastname=' + encodeURIComponent(smLastname) + '&portal=' + portal + '&count=' + count).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.addAges = function (ages) {
                return this.$http.post('Proxy/AddAges', ages).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.addTsEntryOnly = function (person) {
                return this.$http.post('Proxy/AddTsEntryOnly', person).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.addTsEntryAndName = function (person, name) {
                return this.$http.post('Proxy/AddTsEntryAndName' + '?name=' + encodeURIComponent(name), person).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.addTsEntryAndParams = function (person, name, vorname) {
                return this.$http.post('Proxy/AddTsEntryAndParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname), person).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.loadTsCallById = function (id) {
                return this.$http.get('Proxy/LoadTsCallById' + '/' + id).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.loadTsCallByParams = function (name, vorname, alter) {
                return this.$http.get('Proxy/LoadTsCallByParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.loadTsCallByParamsAndId = function (name, vorname, alter, id) {
                return this.$http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.loadTsCallByParamsWithEnum = function (name, vorname, alter, access) {
                return this.$http.get('Proxy/LoadTsCallByParamsWithEnum' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter + '&access=' + access).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.loadAllAutosListe = function (name) {
                return this.$http.get('Proxy/LoadAllAutosListe' + '?name=' + encodeURIComponent(name)).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.loadAllAutosArray = function (name) {
                return this.$http.get('Proxy/LoadAllAutosArray' + '?name=' + encodeURIComponent(name)).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.clearTsCall = function () {
                return this.$http.get('Proxy/ClearTsCall').then(function (response) { return response.data; });
            };
            ProxyPService.prototype.voidTsReturnType = function (name) {
                this.$http.get('Proxy/VoidTsReturnType' + '?name=' + encodeURIComponent(name));
            };
            ProxyPService.prototype.stringTsReturnType = function (name) {
                return this.$http.get('Proxy/StringTsReturnType' + '?name=' + encodeURIComponent(name)).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.integerTsReturnType = function (age) {
                return this.$http.get('Proxy/IntegerTsReturnType' + '?age=' + age).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.dateTsReturnType = function (name) {
                return this.$http.get('Proxy/DateTsReturnType' + '?name=' + encodeURIComponent(name)).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.boolTsReturnType = function (boolValue) {
                return this.$http.get('Proxy/BoolTsReturnType' + '?boolValue=' + boolValue).then(function (response) { return response.data; });
            };
            ProxyPService.prototype.errorStringReturnType = function (boolValue) {
                return this.$http.get('Proxy/ErrorStringReturnType' + '?boolValue=' + boolValue).then(function (response) { return response.data; });
            };
            Object.defineProperty(ProxyPService, "module", {
                get: function () {
                    if (this._module) {
                        return this._module;
                    }
                    this._module = angular.module('ProxyPService', []);
                    this._module.service('ProxyPService', ProxyPService);
                    return this._module;
                },
                enumerable: true,
                configurable: true
            });
            ProxyPService.$inject = ['$http'];
            return ProxyPService;
        }());
        Services.ProxyPService = ProxyPService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=proxyPService.js.map