var App;
(function (App) {
    var MainApp = (function () {
        function MainApp() {
        }
        MainApp.createApp = function (angular) {
            //Alle Module definieren die wir verwenden.
            angular.module("app.main", [
                //Eigene Module einbinden
                "homeAngularJsSrv",
                "proxyAngularJsSrv",
                "fileUpload",
                //Module die mit TypeScript geschrieben wurden einbinden
                App.Views.Proxy.ProxyCtrl.module.name,
                App.Services.HomePService.module.name,
                App.Services.ProxyPService.module.name,
            ]);
        };
        return MainApp;
    }());
    App.MainApp = MainApp;
})(App || (App = {}));
//Unsere Anwendung intial aufrufen/starten
App.MainApp.createApp(angular);
//# sourceMappingURL=mainApp.js.map