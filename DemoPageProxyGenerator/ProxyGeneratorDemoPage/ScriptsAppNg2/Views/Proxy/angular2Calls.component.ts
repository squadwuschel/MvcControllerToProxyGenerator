import {Component} from '@angular/core';


@Component({
    selector: 'angular-2-calls',
    template: `<div>Hallo Welt von ANGIULAR 2 mit Name: "{{name}}"</div>`,
})
export class Angular2Calls {
    public name: string = "TEST";

    constructor() {
        //Im Konstruktor einfach per DI einen Service injecten, dieser muss auch in Providers bekannt gemacht werden
    }
}