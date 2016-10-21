import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, Http } from '@angular/http'
import { Angular2Calls } from "./Views/Proxy/angular2Calls.component";

// Create an Angular 2 root NgModule
@NgModule({
    // import the Ng1ToNg2Module
    imports: [
        BrowserModule,
        HttpModule,
    ],
    declarations: [
        Angular2Calls
    ],
    bootstrap : [Angular2Calls]
    
}) export class AppModule { }