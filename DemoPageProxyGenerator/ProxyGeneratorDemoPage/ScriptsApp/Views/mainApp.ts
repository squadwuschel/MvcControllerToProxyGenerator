module App {
    export class MainApp {
        static createApp(angular: ng.IAngularStatic) {
            //Alle Module definieren die wir verwenden.
            angular.module("app.main", [
                //Eigene Module einbinden
                "homeAngularJsSrv",
                "proxyAngularJsSrv",
                "fileUpload",
                //Module die mit TypeScript geschrieben wurden einbinden
                App.Views.Proxy.ProxyCtrl.module.name,
                App.Services.ProxyPSrv.module.name,
                App.Services.HomePSrv.module.name,
            ]);
        }
    }
}

//Unsere Anwendung intial aufrufen/starten
App.MainApp.createApp(angular);