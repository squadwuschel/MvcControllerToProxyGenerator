angular.module("fileUpload", [])
    /* 
    Da man für file Inputs kein ng-model verwenden kann und angular hier keine integrierte Lösung mit sich bringt,
    gibt es diese direktive. Hier wird einfach an sq-file-model die Variable gebunden in der der Kontent geschrieben werden soll, wie ng-model.
    Beispiel:
    
    <input type="file"
           sq-file-model="ViewModel.FileImportData" 
           ng-model="ViewModel.FileImportData"/>
    */
    .directive('sqFileModel', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            require: 'ngModel', //NgModel wird nur Pseudomäßig benötigt, damit wir später in der Link Funktion darauf zugreifen können
            scope: {
                sqFileModel: "="
            },
            link: function (scope, elem, attr, ctrl) {
                var model = $parse(attr.sqFileModel);
                var modelSetter = model.assign;
                elem.bind('change', function () {
                    scope.$apply(function () {
                        modelSetter(scope, elem[0].files[0]);
                        //Auslösen unseres Validators
                        ctrl.$setViewValue(elem[0].files[0]);
                        ctrl.$render();
                    });
                });

                //Custom Validation einbinden für Required und FileType
                var validator = function (file) {
                    return file;
                }

                //Unseren Validator den passenden Listen hinzufügen.
                ctrl.$parsers.unshift(validator); //view-to-model direction
                ctrl.$formatters.unshift(validator); //model-to-view direction
            }
        };
    }]);