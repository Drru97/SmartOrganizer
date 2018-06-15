var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ConfigurationService } from '../../components/shared/services/configuration.service';
let AppComponent = class AppComponent {
    constructor(configurationService, router) {
        this.configurationService = configurationService;
        this.router = router;
        this.activeTabIndex = 0;
    }
    ngOnInit() {
        this.configurationService.load();
    }
    tabChanged({ index }) {
        console.log(index);
        this.activeTabIndex = index;
        switch (this.activeTabIndex) {
            case 0:
                this.router.navigate(['/home']);
                break;
            case 1:
                this.router.navigate(['/appointment']);
                break;
            case 2:
                this.router.navigate(['/calendar']);
                break;
        }
    }
    tabClicked(event) {
        console.log(event);
        switch (event) {
            case 0:
                this.router.navigate(['/home']);
                break;
            case 1:
                this.router.navigate(['/appointment']);
                break;
            case 2:
                this.router.navigate(['/calendar']);
                break;
            default:
                return;
        }
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    }),
    __metadata("design:paramtypes", [ConfigurationService, Router])
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map