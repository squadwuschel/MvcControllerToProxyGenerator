"use strict";
//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 10.11.2017 time 20:45 from squad.
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var Proxyservice = /** @class */ (function () {
    function Proxyservice(http) {
        this.http = http;
    }
    Proxyservice.prototype.addFileToServer = function (datei, detailId) {
        var formData = new FormData();
        formData.append('datei', datei);
        return this.http.post('Proxy/AddFileToServer' + '?detailId=' + detailId, formData);
    };
    Proxyservice.prototype.addFileToServerNoReturnType = function (datei, detailId) {
        var formData = new FormData();
        formData.append('datei', datei);
        this.http.post('Proxy/AddFileToServerNoReturnType' + '?detailId=' + detailId, formData).subscribe(function (res) { return res; });
    };
    Proxyservice.prototype.getDownloadPerson = function (personId) {
        window.location.href = 'Proxy/GetDownloadPerson' + '?personId=' + personId;
    };
    Proxyservice.prototype.getDownloadCompany = function (companyId) {
        window.location.href = 'Proxy/GetDownloadCompany' + '?companyId=' + companyId;
    };
    Proxyservice.prototype.getDownloadSimple = function (companyId, name) {
        window.location.href = 'Proxy/GetDownloadSimple' + '?companyId=' + companyId + '&name=' + encodeURIComponent(name);
    };
    Proxyservice.prototype.getDownloadNoParams = function () {
        window.location.href = 'Proxy/GetDownloadNoParams';
    };
    Proxyservice.prototype.manySimpleParams = function (page, size, sortedCol, desc, smCompany, smCustomerNumber, smEmail, smLastname, portal, count) {
        return this.http.get('Proxy/ManySimpleParams' + '?page=' + page + '&size=' + size + '&sortedCol=' + sortedCol + '&desc=' + desc + '&smCompany=' + encodeURIComponent(smCompany) + '&smCustomerNumber=' + smCustomerNumber + '&smEmail=' + encodeURIComponent(smEmail) + '&smLastname=' + encodeURIComponent(smLastname) + '&portal=' + portal + '&count=' + count);
    };
    Proxyservice.prototype.addAges = function (ages) {
        return this.http.post('Proxy/AddAges', ages);
    };
    Proxyservice.prototype.addTsEntryOnly = function (person) {
        return this.http.post('Proxy/AddTsEntryOnly', person);
    };
    Proxyservice.prototype.addTsEntryAndName = function (person, name) {
        return this.http.post('Proxy/AddTsEntryAndName' + '?name=' + encodeURIComponent(name), person);
    };
    Proxyservice.prototype.addTsEntryAndParams = function (person, name, vorname) {
        return this.http.post('Proxy/AddTsEntryAndParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname), person);
    };
    Proxyservice.prototype.loadTsCallById = function (id) {
        return this.http.get('Proxy/LoadTsCallById' + '/' + id);
    };
    Proxyservice.prototype.loadTsCallByParams = function (name, vorname, alter) {
        return this.http.get('Proxy/LoadTsCallByParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter);
    };
    Proxyservice.prototype.loadTsCallByParamsAndId = function (name, vorname, alter, id) {
        return this.http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter);
    };
    Proxyservice.prototype.loadTsCallByParamsWithEnum = function (name, vorname, alter, access) {
        return this.http.get('Proxy/LoadTsCallByParamsWithEnum' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter + '&access=' + access);
    };
    Proxyservice.prototype.loadAllAutosListe = function (name) {
        return this.http.get('Proxy/LoadAllAutosListe' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.loadAllAutosArray = function (name) {
        return this.http.get('Proxy/LoadAllAutosArray' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.clearTsCall = function () {
        return this.http.get('Proxy/ClearTsCall');
    };
    Proxyservice.prototype.voidTsReturnType = function (name) {
        this.http.get('Proxy/VoidTsReturnType' + '?name=' + encodeURIComponent(name)).subscribe(function (res) { return res; });
    };
    Proxyservice.prototype.stringTsReturnType = function (name) {
        return this.http.get('Proxy/StringTsReturnType' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.integerTsReturnType = function (age) {
        return this.http.get('Proxy/IntegerTsReturnType' + '?age=' + age);
    };
    Proxyservice.prototype.dateTsReturnType = function (name) {
        return this.http.get('Proxy/DateTsReturnType' + '?name=' + encodeURIComponent(name));
    };
    Proxyservice.prototype.boolTsReturnType = function (boolValue) {
        return this.http.get('Proxy/BoolTsReturnType' + '?boolValue=' + boolValue);
    };
    Proxyservice.prototype.errorStringReturnType = function (boolValue) {
        return this.http.get('Proxy/ErrorStringReturnType' + '?boolValue=' + boolValue);
    };
    Proxyservice = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], Proxyservice);
    return Proxyservice;
}());
exports.Proxyservice = Proxyservice;
//# sourceMappingURL=proxy.service.js.map