//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 22.10.2016 time 13:27 from squad.
var App;
(function (App) {
    var Services;
    (function (Services) {
        var HomePService = (function () {
            function HomePService($http) {
                this.$http = $http;
            }
            HomePService.prototype.getDownload = function (personId, person) {
                window.location.href = 'Home/GetDownload' + '?personId=' + personId + '&' + jQuery.param(person);
            };
            HomePService.prototype.getPerson = function (id) {
                this.$http.get('Home/GetPerson' + '/' + id);
            };
            HomePService.prototype.getAllAutos = function () {
                return this.$http.get('Home/GetAllAutos').then(function (response) { return response.data; });
            };
            Object.defineProperty(HomePService, "module", {
                get: function () {
                    if (this._module) {
                        return this._module;
                    }
                    this._module = angular.module('HomePService', []);
                    this._module.service('HomePService', HomePService);
                    return this._module;
                },
                enumerable: true,
                configurable: true
            });
            HomePService.$inject = ['$http'];
            return HomePService;
        }());
        Services.HomePService = HomePService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=homePService.js.map