var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MdlModule } from '@angular-mdl/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { AppointmentModule } from './components/appointment/appointment.module';
import { HomeModule } from './components/home/home.module';
import { LoginModule } from './components/login/login.module';
import { AppComponent } from './components/app/app.component';
import { DataService } from './components/shared/services/data.service';
import { ConfigurationService } from './components/shared/services/configuration.service';
import { StorageService } from './components/shared/services/storage.service';
import { LocalStorageModule } from 'angular-2-local-storage';
import { HomeComponent } from './components/home/home.component';
import { AppointmentListComponent } from './components/appointment/appointment-list/appointment-list.component';
import { AppointmentAddDialogComponent } from './components/appointment/appointment-add-dialog/appointment-add-dialog.component';
import { LoginComponent } from './components/login/login.component';
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        imports: [
            BrowserModule,
            FormsModule,
            HttpModule,
            RouterModule.forRoot([
                { path: 'home', component: HomeComponent },
                { path: 'appointment', component: AppointmentListComponent },
                { path: 'login', component: LoginComponent },
                { path: '', redirectTo: 'home', pathMatch: 'full' },
                { path: '**', redirectTo: 'home' }
            ]),
            MdlModule,
            NoopAnimationsModule,
            AppointmentModule,
            LocalStorageModule.withConfig({
                prefix: 'app',
                storageType: 'localStorage'
            }),
            HomeModule,
            LoginModule,
            MatToolbarModule,
            MatTabsModule
        ],
        declarations: [
            AppComponent
        ],
        providers: [
            DataService,
            ConfigurationService,
            StorageService
        ],
        bootstrap: [
            AppComponent
        ],
        entryComponents: [
            AppointmentAddDialogComponent
        ]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map