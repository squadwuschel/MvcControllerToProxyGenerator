var ac_app =
webpackJsonpac__name_([1],{

/***/ 282:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
// Hot Module Replacement
__export(__webpack_require__(707));
//# sourceMappingURL=index.js.map

/***/ }),

/***/ 704:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_dynamic_1 = __webpack_require__(181);
var environment_1 = __webpack_require__(705);
var hmr_1 = __webpack_require__(282);
//App
var app_module_1 = __webpack_require__(708);
/*
 * Bootstrap our Angular app with a top level NgModule
 */
function main() {
    return platform_browser_dynamic_1.platformBrowserDynamic()
        .bootstrapModule(app_module_1.AppModule).then(function(MODULE_REF) {
  if (false) {
    module["hot"]["accept"]();
    
    if (MODULE_REF.instance["hmrOnInit"]) {
      module["hot"]["data"] && MODULE_REF.instance["hmrOnInit"](module["hot"]["data"]);
    }
    if (MODULE_REF.instance["hmrOnStatus"]) {
      module["hot"]["apply"](function(status) {
        MODULE_REF.instance["hmrOnStatus"](status);
      });
    }
    if (MODULE_REF.instance["hmrOnCheck"]) {
      module["hot"]["check"](function(err, outdatedModules) {
        MODULE_REF.instance["hmrOnCheck"](err, outdatedModules);
      });
    }
    if (MODULE_REF.instance["hmrOnDecline"]) {
      module["hot"]["decline"](function(dependencies) {
        MODULE_REF.instance["hmrOnDecline"](dependencies);
      });
    }
    module["hot"]["dispose"](function(store) {
      MODULE_REF.instance["hmrOnDestroy"] && MODULE_REF.instance["hmrOnDestroy"](store);
      MODULE_REF.destroy();
      MODULE_REF.instance["hmrAfterDestroy"] && MODULE_REF.instance["hmrAfterDestroy"](store);
    });
  }
  return MODULE_REF;
})
        .then(environment_1.decorateModuleRef)
        .catch(function (err) { return console.error(err); });
}
exports.main = main;
// needed for hmr
// in prod this is replace for document ready
hmr_1.bootloader(main);


/***/ }),

/***/ 705:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
// Angular 2
var platform_browser_1 = __webpack_require__(39);
var core_1 = __webpack_require__(22);
// Environment Providers
var PROVIDERS = [];
// Angular debug tools in the dev console
// https://github.com/angular/angular/blob/86405345b781a9dc2438c0fbe3e9409245647019/TOOLS_JS.md
var _decorateModuleRef = function (value) { return value; };
if (false) {
    core_1.enableProdMode();
    // Production
    _decorateModuleRef = function (modRef) {
        platform_browser_1.disableDebugTools();
        return modRef;
    };
    PROVIDERS = PROVIDERS.slice();
}
else {
    _decorateModuleRef = function (modRef) {
        var appRef = modRef.injector.get(core_1.ApplicationRef);
        var cmpRef = appRef.components[0];
        var _ng = window.ng;
        platform_browser_1.enableDebugTools(cmpRef);
        window.ng.probe = _ng.probe;
        window.ng.coreTokens = _ng.coreTokens;
        return modRef;
    };
    // Development and test laut angular.io
    Error['stackTraceLimit'] = Infinity;
    __webpack_require__(706);
    // Development
    PROVIDERS = PROVIDERS.slice();
}
exports.decorateModuleRef = _decorateModuleRef;
exports.ENV_PROVIDERS = PROVIDERS.slice();


/***/ }),

/***/ 706:
/***/ (function(module, exports, __webpack_require__) {

/**
* @license
* Copyright Google Inc. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://angular.io/license
*/
(function (global, factory) {
	 true ? factory() :
	typeof define === 'function' && define.amd ? define(factory) :
	(factory());
}(this, (function () { 'use strict';

/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
/**
 * @fileoverview
 * @suppress {globalThis}
 */
var NEWLINE = '\n';
var IGNORE_FRAMES = {};
var creationTrace = '__creationTrace__';
var ERROR_TAG = 'STACKTRACE TRACKING';
var SEP_TAG = '__SEP_TAG__';
var sepTemplate = SEP_TAG + '@[native]';
var LongStackTrace = (function () {
    function LongStackTrace() {
        this.error = getStacktrace();
        this.timestamp = new Date();
    }
    return LongStackTrace;
}());
function getStacktraceWithUncaughtError() {
    return new Error(ERROR_TAG);
}
function getStacktraceWithCaughtError() {
    try {
        throw getStacktraceWithUncaughtError();
    }
    catch (err) {
        return err;
    }
}
// Some implementations of exception handling don't create a stack trace if the exception
// isn't thrown, however it's faster not to actually throw the exception.
var error = getStacktraceWithUncaughtError();
var caughtError = getStacktraceWithCaughtError();
var getStacktrace = error.stack ?
    getStacktraceWithUncaughtError :
    (caughtError.stack ? getStacktraceWithCaughtError : getStacktraceWithUncaughtError);
function getFrames(error) {
    return error.stack ? error.stack.split(NEWLINE) : [];
}
function addErrorStack(lines, error) {
    var trace = getFrames(error);
    for (var i = 0; i < trace.length; i++) {
        var frame = trace[i];
        // Filter out the Frames which are part of stack capturing.
        if (!IGNORE_FRAMES.hasOwnProperty(frame)) {
            lines.push(trace[i]);
        }
    }
}
function renderLongStackTrace(frames, stack) {
    var longTrace = [stack ? stack.trim() : ''];
    if (frames) {
        var timestamp = new Date().getTime();
        for (var i = 0; i < frames.length; i++) {
            var traceFrames = frames[i];
            var lastTime = traceFrames.timestamp;
            var separator = "____________________Elapsed " + (timestamp - lastTime.getTime()) + " ms; At: " + lastTime;
            separator = separator.replace(/[^\w\d]/g, '_');
            longTrace.push(sepTemplate.replace(SEP_TAG, separator));
            addErrorStack(longTrace, traceFrames.error);
            timestamp = lastTime.getTime();
        }
    }
    return longTrace.join(NEWLINE);
}
Zone['longStackTraceZoneSpec'] = {
    name: 'long-stack-trace',
    longStackTraceLimit: 10,
    // add a getLongStackTrace method in spec to
    // handle handled reject promise error.
    getLongStackTrace: function (error) {
        if (!error) {
            return undefined;
        }
        var task = error[Zone.__symbol__('currentTask')];
        var trace = task && task.data && task.data[creationTrace];
        if (!trace) {
            return error.stack;
        }
        return renderLongStackTrace(trace, error.stack);
    },
    onScheduleTask: function (parentZoneDelegate, currentZone, targetZone, task) {
        if (Error.stackTraceLimit > 0) {
            // if Error.stackTraceLimit is 0, means stack trace
            // is disabled, so we don't need to generate long stack trace
            // this will improve performance in some test(some test will
            // set stackTraceLimit to 0, https://github.com/angular/zone.js/issues/698
            var currentTask = Zone.currentTask;
            var trace = currentTask && currentTask.data && currentTask.data[creationTrace] || [];
            trace = [new LongStackTrace()].concat(trace);
            if (trace.length > this.longStackTraceLimit) {
                trace.length = this.longStackTraceLimit;
            }
            if (!task.data)
                task.data = {};
            task.data[creationTrace] = trace;
        }
        return parentZoneDelegate.scheduleTask(targetZone, task);
    },
    onHandleError: function (parentZoneDelegate, currentZone, targetZone, error) {
        if (Error.stackTraceLimit > 0) {
            // if Error.stackTraceLimit is 0, means stack trace
            // is disabled, so we don't need to generate long stack trace
            // this will improve performance in some test(some test will
            // set stackTraceLimit to 0, https://github.com/angular/zone.js/issues/698
            var parentTask = Zone.currentTask || error.task;
            if (error instanceof Error && parentTask) {
                var longStack = renderLongStackTrace(parentTask.data && parentTask.data[creationTrace], error.stack);
                try {
                    error.stack = error.longStack = longStack;
                }
                catch (err) {
                }
            }
        }
        return parentZoneDelegate.handleError(targetZone, error);
    }
};
function captureStackTraces(stackTraces, count) {
    if (count > 0) {
        stackTraces.push(getFrames((new LongStackTrace()).error));
        captureStackTraces(stackTraces, count - 1);
    }
}
function computeIgnoreFrames() {
    if (Error.stackTraceLimit <= 0) {
        return;
    }
    var frames = [];
    captureStackTraces(frames, 2);
    var frames1 = frames[0];
    var frames2 = frames[1];
    for (var i = 0; i < frames1.length; i++) {
        var frame1 = frames1[i];
        if (frame1.indexOf(ERROR_TAG) == -1) {
            var match = frame1.match(/^\s*at\s+/);
            if (match) {
                sepTemplate = match[0] + SEP_TAG + ' (http://localhost)';
                break;
            }
        }
    }
    for (var i = 0; i < frames1.length; i++) {
        var frame1 = frames1[i];
        var frame2 = frames2[i];
        if (frame1 === frame2) {
            IGNORE_FRAMES[frame1] = true;
        }
        else {
            break;
        }
    }
}
computeIgnoreFrames();

})));


/***/ }),

/***/ 707:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

// Hot Module Replacement
function bootloader(main) {
    if (document.readyState === 'complete') {
        main();
    }
    else {
        document.addEventListener('DOMContentLoaded', main);
    }
}
exports.bootloader = bootloader;
// create new elements
function createNewHosts(cmps) {
    var components = cmps.map(function (componentNode) {
        var newNode = document.createElement(componentNode.tagName);
        // display none
        var currentDisplay = newNode.style.display;
        newNode.style.display = 'none';
        var parentNode = componentNode.parentNode;
        parentNode.insertBefore(newNode, componentNode);
        return { currentDisplay: currentDisplay, newNode: newNode };
    });
    return function () {
        components.forEach(function (cmp) {
            cmp.newNode.style.display = cmp.currentDisplay;
            cmp.newNode = null;
            cmp.currentDisplay = null;
        });
    };
}
exports.createNewHosts = createNewHosts;
// remove old styles
function removeNgStyles() {
    Array.prototype.slice.call(document.head.querySelectorAll('style'), 0)
        .filter(function (style) { return style.innerText.indexOf('_ng') !== -1; })
        .map(function (el) { return el.remove(); });
}
exports.removeNgStyles = removeNgStyles;
// get input values
function getInputValues() {
    var inputs = document.querySelectorAll('input');
    return Array.prototype.slice.call(inputs).map(function (input) { return input.value; });
}
exports.getInputValues = getInputValues;
// set input values
function setInputValues($inputs) {
    var inputs = document.querySelectorAll('input');
    if ($inputs && inputs.length === $inputs.length) {
        $inputs.forEach(function (value, i) {
            var el = inputs[i];
            el.value = value;
            el.dispatchEvent(new CustomEvent('input', { detail: el.value }));
        });
    }
}
exports.setInputValues = setInputValues;
// get/set input values
function createInputTransfer() {
    var $inputs = getInputValues();
    return function restoreInputValues() {
        setInputValues($inputs);
    };
}
exports.createInputTransfer = createInputTransfer;
//# sourceMappingURL=helpers.js.map

/***/ }),

/***/ 708:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

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
var core_1 = __webpack_require__(22);
var http_1 = __webpack_require__(114);
var platform_browser_1 = __webpack_require__(39);
//Basic App Components
var app_component_1 = __webpack_require__(709);
//HMR (Hot module Replacement)
var app_service_1 = __webpack_require__(713);
var hmr_1 = __webpack_require__(282);
var AppModule = /** @class */ (function () {
    function AppModule(appRef, appState) {
        this.appRef = appRef;
        this.appState = appState;
    }
    AppModule.prototype.hmrOnInit = function (store) {
        if (!store || !store.state)
            return;
        console.log('HMR store', JSON.stringify(store, null, 2));
        // set state
        this.appState._state = store.state;
        // set input values
        if ('restoreInputValues' in store) {
            var restoreInputValues = store.restoreInputValues;
            setTimeout(restoreInputValues);
        }
        this.appRef.tick();
        delete store.state;
        delete store.restoreInputValues;
    };
    AppModule.prototype.hmrOnDestroy = function (store) {
        var cmpLocation = this.appRef.components.map(function (cmp) { return cmp.location.nativeElement; });
        // save state
        var state = this.appState._state;
        store.state = state;
        // recreate root elements
        store.disposeOldHosts = hmr_1.createNewHosts(cmpLocation);
        // save input values
        store.restoreInputValues = hmr_1.createInputTransfer();
        // remove styles
        hmr_1.removeNgStyles();
    };
    AppModule.prototype.hmrAfterDestroy = function (store) {
        // display new elements
        store.disposeOldHosts();
        delete store.disposeOldHosts;
    };
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                //Ng Modules
                platform_browser_1.BrowserModule,
                http_1.HttpModule
            ],
            declarations: [
                app_component_1.AppComponent,
            ],
            exports: [
                app_component_1.AppComponent,
            ],
            providers: [
                app_service_1.AppState,
                platform_browser_1.Title //Titleservice um den Pagetitle anzupassen
            ],
            bootstrap: [app_component_1.AppComponent]
        }),
        __metadata("design:paramtypes", [core_1.ApplicationRef, app_service_1.AppState])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;


/***/ }),

/***/ 709:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

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
var core_1 = __webpack_require__(22);
var proxy_service_1 = __webpack_require__(710);
var Person_1 = __webpack_require__(711);
var AppComponent = /** @class */ (function () {
    function AppComponent(proxyService) {
        this.proxyService = proxyService;
        this.name = "TEST";
        //Im Konstruktor einfach per DI einen Service injecten, dieser muss in Providers bekannt gemacht werden
    }
    AppComponent.prototype.startFileUploadTypeScript = function () {
        //File Upload
        //https://devblog.dymel.pl/2016/09/02/upload-file-image-angular2-aspnetcore/
        var fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            var fileToUpload = fi.files[0];
            this.proxyService.addFileToServer(fileToUpload, 12).subscribe(function (_) {
                console.log(_);
            });
        }
    };
    //public startFileDownloadCompanyTypeScript() {
    //    var company: ProxyGeneratorDemoPage.Helper.ICompany = new Company("MyCompany", 12, ProxyGeneratorDemoPage.Helper.ClientAccess.Admin);
    //    this.proxyService.getDownloadCompany(1337, company);
    //}
    //public startFileDownloadPersonTypeScript(): void {
    //    var ages: number[] = [1, 2, 3, 4, 5, 66];
    //    var person: ProxyGeneratorDemoPage.Models.Person.Models.IPerson = new Person(16667, "SquadJs", "Wuschel", true, ages);
    //    this.proxyService.getDownloadPerson(7331, person);
    //}
    AppComponent.prototype.startFileDownloadNoParamsTypeScript = function () {
        this.proxyService.getDownloadNoParams();
    };
    AppComponent.prototype.startTypeScriptServiceCalls = function () {
        var _this = this;
        var ages = [1, 2, 3, 4, 5, 66];
        var person = new Person_1.Person(1337, "Squad", "Wuschel", true, ages);
        console.clear();
        console.log("Some TypeScript Angular Service Calls: \r\n");
        this.proxyService.addAges(ages).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addAges' Result: ");
            console.log(result);
            _this.proxyService.addAges(result);
        });
        this.proxyService.addTsEntryAndName(person, "Johannes").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndName' Result: ");
            console.log(result);
        });
        this.proxyService.manySimpleParams(12, 345, 1, 1, "test", 12, "squad@web.de", "Squad", 12, 32).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'manySimpleParams' Result: ");
            console.log(result);
        });
        this.proxyService.addTsEntryAndParams(person, "Squad", "Wuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryAndParams' Result: ");
            console.log(result);
        });
        this.proxyService.addTsEntryOnly(person).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'addTsEntryOnly' Result: ");
            console.log(result);
        });
        this.proxyService.boolTsReturnType(true).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'boolTsReturnType' Result: ");
            console.log(result);
        });
        this.proxyService.clearTsCall().subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'clearTsCall' Result: ");
            console.log(result);
        });
        this.proxyService.dateTsReturnType("SquadWuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'dateTsReturnType' Result: ");
            console.log(result);
        });
        this.proxyService.integerTsReturnType(1337).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'integerTsReturnType' Result: ");
            console.log(result);
        });
        this.proxyService.loadAllAutosArray("SquadWuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosArray' Result: ");
            console.log(result);
        });
        this.proxyService.loadAllAutosListe("SquadWuschel").subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadAllAutosListe' Result: ");
            console.log(result);
        });
        this.proxyService.loadTsCallById(16667).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallById' Result: ");
            console.log(result);
        });
        this.proxyService.loadTsCallByParams("Squad", "Wuschel", 33).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParams' Result: ");
            console.log(result);
        });
        this.proxyService.loadTsCallByParamsAndId("Squad", "Wuschel", 33, 1337).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
            console.log(result);
        });
        this.proxyService.voidTsReturnType("test");
        this.proxyService.loadTsCallByParamsWithEnum("Squad", "Wuschel", 33, 2 /* Admin */).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'loadTsCallByParamsAndId' Result: ");
            console.log(result);
        });
        this.proxyService.errorStringReturnType(true).subscribe(function (result) {
            console.log("\r\nSuccess TypeScript Service Call 'errorStringReturnType' Result: ");
            console.log(result);
        }, function (errorResult) {
            //Only gets Called if the ErrorResponse is active and returns only the errorResult and not only the Data.
            console.log("\r\nError TypeScript Service Call 'errorStringReturnType' Result: ");
            console.log(errorResult);
        });
    };
    __decorate([
        core_1.ViewChild("fileInput"),
        __metadata("design:type", Object)
    ], AppComponent.prototype, "fileInput", void 0);
    AppComponent = __decorate([
        core_1.Component({
            selector: 'angular-2-calls',
            template: __webpack_require__(712),
            providers: [proxy_service_1.Proxyservice]
        }),
        __metadata("design:paramtypes", [proxy_service_1.Proxyservice])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;


/***/ }),

/***/ 710:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

//Warning this file was dynamicly created.
//Please don't change any code it will be overwritten next time the template is executed.
//Created on 10.11.2017 time 19:56 from squad.
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
var core_1 = __webpack_require__(22);
var http_1 = __webpack_require__(114);
__webpack_require__(229);
var Proxyservice = /** @class */ (function () {
    function Proxyservice(http) {
        this.http = http;
    }
    Proxyservice.prototype.addFileToServer = function (datei, detailId) {
        var formData = new FormData();
        formData.append('datei', datei);
        return this.http.post('Proxy/AddFileToServer' + '?detailId=' + detailId, formData).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.addFileToServerNoReturnType = function (datei, detailId) {
        var formData = new FormData();
        formData.append('datei', datei);
        this.http.post('Proxy/AddFileToServerNoReturnType' + '?detailId=' + detailId, formData).subscribe(function (res) { return res.json(); });
    };
    //public getDownloadPerson(personId: number,person: ProxyGeneratorNgDemoPage.Models.IPerson) : void  { 
    //    window.location.href = 'Proxy/GetDownloadPerson'+ '?personId='+personId+'&'+jQuery.param(person); 
    //} 
    //public getDownloadCompany(companyId: number,company: ProxyGeneratorNgDemoPage.Models.ICompany) : void  { 
    //    window.location.href = 'Proxy/GetDownloadCompany'+ '?companyId='+companyId+'&'+jQuery.param(company); 
    //} 
    Proxyservice.prototype.getDownloadSimple = function (companyId, name) {
        window.location.href = 'Proxy/GetDownloadSimple' + '?companyId=' + companyId + '&name=' + encodeURIComponent(name);
    };
    Proxyservice.prototype.getDownloadNoParams = function () {
        window.location.href = 'Proxy/GetDownloadNoParams';
    };
    Proxyservice.prototype.manySimpleParams = function (page, size, sortedCol, desc, smCompany, smCustomerNumber, smEmail, smLastname, portal, count) {
        return this.http.get('Proxy/ManySimpleParams' + '?page=' + page + '&size=' + size + '&sortedCol=' + sortedCol + '&desc=' + desc + '&smCompany=' + encodeURIComponent(smCompany) + '&smCustomerNumber=' + smCustomerNumber + '&smEmail=' + encodeURIComponent(smEmail) + '&smLastname=' + encodeURIComponent(smLastname) + '&portal=' + portal + '&count=' + count).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.addAges = function (ages) {
        return this.http.post('Proxy/AddAges', ages).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.addTsEntryOnly = function (person) {
        return this.http.post('Proxy/AddTsEntryOnly', person).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.addTsEntryAndName = function (person, name) {
        return this.http.post('Proxy/AddTsEntryAndName' + '?name=' + encodeURIComponent(name), person).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.addTsEntryAndParams = function (person, name, vorname) {
        return this.http.post('Proxy/AddTsEntryAndParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname), person).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.loadTsCallById = function (id) {
        return this.http.get('Proxy/LoadTsCallById' + '/' + id).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.loadTsCallByParams = function (name, vorname, alter) {
        return this.http.get('Proxy/LoadTsCallByParams' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.loadTsCallByParamsAndId = function (name, vorname, alter, id) {
        return this.http.get('Proxy/LoadTsCallByParamsAndId' + '/' + id + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.loadTsCallByParamsWithEnum = function (name, vorname, alter, access) {
        return this.http.get('Proxy/LoadTsCallByParamsWithEnum' + '?name=' + encodeURIComponent(name) + '&vorname=' + encodeURIComponent(vorname) + '&alter=' + alter + '&access=' + access).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.loadAllAutosListe = function (name) {
        return this.http.get('Proxy/LoadAllAutosListe' + '?name=' + encodeURIComponent(name)).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.loadAllAutosArray = function (name) {
        return this.http.get('Proxy/LoadAllAutosArray' + '?name=' + encodeURIComponent(name)).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.clearTsCall = function () {
        return this.http.get('Proxy/ClearTsCall').map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.voidTsReturnType = function (name) {
        this.http.get('Proxy/VoidTsReturnType' + '?name=' + encodeURIComponent(name)).subscribe(function (res) { return res.json(); });
    };
    Proxyservice.prototype.stringTsReturnType = function (name) {
        return this.http.get('Proxy/StringTsReturnType' + '?name=' + encodeURIComponent(name)).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.integerTsReturnType = function (age) {
        return this.http.get('Proxy/IntegerTsReturnType' + '?age=' + age).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.dateTsReturnType = function (name) {
        return this.http.get('Proxy/DateTsReturnType' + '?name=' + encodeURIComponent(name)).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.boolTsReturnType = function (boolValue) {
        return this.http.get('Proxy/BoolTsReturnType' + '?boolValue=' + boolValue).map(function (response) { return response.json(); });
    };
    Proxyservice.prototype.errorStringReturnType = function (boolValue) {
        return this.http.get('Proxy/ErrorStringReturnType' + '?boolValue=' + boolValue).map(function (response) { return response.json(); });
    };
    Proxyservice = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], Proxyservice);
    return Proxyservice;
}());
exports.Proxyservice = Proxyservice;


/***/ }),

/***/ 711:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var Person = /** @class */ (function () {
    function Person(Id, Name, Passwort, IsAktiv, CounterValues) {
        this.Id = Id;
        this.Name = Name;
        this.Passwort = Passwort;
        this.IsAktiv = IsAktiv;
        this.CounterValues = CounterValues;
    }
    return Person;
}());
exports.Person = Person;


/***/ }),

/***/ 712:
/***/ (function(module, exports) {

module.exports = "<div class=\"container body-content\" style=\"margin-top: 25px;\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>\r\n                Angular 2 Proxy Calls\r\n            </h3>\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3 col-md-offset-6\">\r\n            <a (click)=\"startTypeScriptServiceCalls()\" class=\"btn btn-primary btn-block\">Test TypeScript Service Calls</a>\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            <br />\r\n            <p class=\"text-center\">\r\n                <strong>Please open the Chrome developer Console to see the service Calls and returned Objects.</strong>\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>Datei Upload Tests für Angular 2</h3>\r\n            <p>The IIS tries to store the uploaded files in the diretory: \"C:\\Temp\\\"</p>\r\n            <br />\r\n            <br />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <input #fileInput type=\"file\" class=\"form-control input-sm\" />\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <a (click)=\"startFileUploadTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileUpload TypeScript</a>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\"><hr /></div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            <a (click)=\"startFileDownloadCompanyTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileDownload Company TypeScript</a>\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <a (click)=\"startFileDownloadPersonTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileDownload Person TypeScript</a>\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <a (click)=\"startFileDownloadNoParamsTypeScript()\" class=\"btn btn-sm btn-primary btn-block\">Test FileDownload NoParams TypeScript</a>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ }),

/***/ 713:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

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
var core_1 = __webpack_require__(22);
var AppState = /** @class */ (function () {
    function AppState() {
        this._state = {};
    }
    Object.defineProperty(AppState.prototype, "state", {
        // already return a clone of the current state
        get: function () {
            return this._state = this._clone(this._state);
        },
        // never allow mutation
        set: function (value) {
            throw new Error('do not mutate the `.state` directly');
        },
        enumerable: true,
        configurable: true
    });
    AppState.prototype.get = function (prop) {
        // use our state getter for the clone
        var state = this.state;
        return state.hasOwnProperty(prop) ? state[prop] : state;
    };
    AppState.prototype.set = function (prop, value) {
        // internally mutate our state
        return this._state[prop] = value;
    };
    AppState.prototype._clone = function (object) {
        // simple object clone
        return JSON.parse(JSON.stringify(object));
    };
    AppState = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [])
    ], AppState);
    return AppState;
}());
exports.AppState = AppState;


/***/ })

},[704]);
//# sourceMappingURL=app.map