import { NgModule, ApplicationRef } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule, Title } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Basic App Components
import { AppComponent } from "./app.component";

//HMR (Hot module Replacement)
import { AppState, InternalStateType } from "./AppShared/Build/app.service";
import { removeNgStyles, createNewHosts, createInputTransfer } from '@angularclass/hmr';
type StoreType = {
    state: InternalStateType;
    restoreInputValues: () => void;
    disposeOldHosts: () => void;
};

@NgModule({
    imports: [
        //Ng Modules
        BrowserModule,
        HttpModule
    ],
    declarations: [
        AppComponent,
    ],
    exports: [
        AppComponent,
    ],
    providers: [
        AppState, //Für HMR verwendet
        Title //Titleservice um den Pagetitle anzupassen
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
    constructor(public appRef: ApplicationRef, public appState: AppState) { }

    hmrOnInit(store: StoreType) {
        if (!store || !store.state) return;
        console.log('HMR store', JSON.stringify(store, null, 2));
        // set state
        this.appState._state = store.state;
        // set input values
        if ('restoreInputValues' in store) {
            let restoreInputValues = store.restoreInputValues;
            setTimeout(restoreInputValues);
        }

        this.appRef.tick();
        delete store.state;
        delete store.restoreInputValues;
    }

    hmrOnDestroy(store: StoreType) {
        const cmpLocation = this.appRef.components.map(cmp => cmp.location.nativeElement);
        // save state
        const state = this.appState._state;
        store.state = state;
        // recreate root elements
        store.disposeOldHosts = createNewHosts(cmpLocation);
        // save input values
        store.restoreInputValues = createInputTransfer();
        // remove styles
        removeNgStyles();
    }

    hmrAfterDestroy(store: StoreType) {
        // display new elements
        store.disposeOldHosts();
        delete store.disposeOldHosts;
    }
}