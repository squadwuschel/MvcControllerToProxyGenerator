angular.module("fileUpload", [])
    .directive('sqFileModel', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            require: 'ngModel',
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
                };
                //Unseren Validator den passenden Listen hinzufügen.
                ctrl.$parsers.unshift(validator); //view-to-model direction
                ctrl.$formatters.unshift(validator); //model-to-view direction
            }
        };
    }]);
//# sourceMappingURL=fileUpload.js.map