import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

import { MdlModule } from '@angular-mdl/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';

import { AppointmentModule } from './components/appointment/appointment.module';
import { HomeModule } from './components/home/home.module';
//import { LoginModule } from './components/login/login.module';
import { AppComponent } from './components/app/app.component';

import { DataService } from './components/shared/services/data.service';
import { ConfigurationService } from './components/shared/services/configuration.service';
import { StorageService } from './components/shared/services/storage.service';

import { LocalStorageModule } from 'angular-2-local-storage';
import { HomeComponent } from './components/home/home.component';
import { AppointmentListComponent } from './components/appointment/appointment-list/appointment-list.component';

import { AppointmentAddDialogComponent } from './components/appointment/appointment-add-dialog/appointment-add-dialog.component';
//import { LoginComponent } from './components/login/login.component';
import { CalendarComponent } from './components/appointment/calendar/calendar.component';
import { CalendarHeaderComponent } from './components/appointment/calendar/calendar-header.component';
import { DateTimePickerComponent } from './components/appointment/calendar/date-time-picker.component';
import { CalendarModule } from 'angular-calendar';

import {
    NgbDatepickerModule,
    NgbTimepickerModule
    } from '@ng-bootstrap/ng-bootstrap';

import 'core-js/es6/symbol';
import 'core-js/es6/object';
import 'core-js/es6/function';
import 'core-js/es6/parse-int';
import 'core-js/es6/parse-float';
import 'core-js/es6/number';
import 'core-js/es6/math';
import 'core-js/es6/string';
import 'core-js/es6/date';
import 'core-js/es6/array';
import 'core-js/es6/regexp';
import 'core-js/es6/map';
import 'core-js/es6/weak-map';
import 'core-js/es6/set';
import 'core-js/es6/reflect';
import 'core-js/es7/reflect';
import 'zone.js/dist/zone';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        CommonModule,
        NgbDatepickerModule.forRoot(),
        NgbTimepickerModule.forRoot(),
        CalendarModule.forRoot(),
        NgbModalModule.forRoot(),
        RouterModule.forRoot([
            { path: 'home', component: HomeComponent },
            { path: 'appointment', component: AppointmentListComponent },
            { path: 'calendar', component: CalendarComponent },
            //    { path: 'login', component: LoginComponent },
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
        //    LoginModule,
        MatToolbarModule,
        MatTabsModule
    ],
    declarations: [
        AppComponent,
        CalendarComponent,
        CalendarHeaderComponent,
        DateTimePickerComponent
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
    ],
    exports: [
        CalendarComponent,
        DateTimePickerComponent
    ]
})
export class AppModule {
}
