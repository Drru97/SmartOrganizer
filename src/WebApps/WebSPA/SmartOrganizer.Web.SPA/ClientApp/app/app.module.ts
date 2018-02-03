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
import { AppComponent } from './components/app/app.component';

import { DataService } from './components/shared/services/data.service';
import { ConfigurationService } from './components/shared/services/configuration.service';
import { StorageService } from './components/shared/services/storage.service';

import { LocalStorageModule } from 'angular-2-local-storage';
import { HomeComponent } from './components/home/home.component';
import { AppointmentListComponent } from './components/appointment/appointment-list/appointment-list.component';

import { AppointmentAddDialogComponent } from './components/appointment/appointment-add-dialog/appointment-add-dialog.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot([
            { path: 'home', component: HomeComponent },
            { path: 'appointment', component: AppointmentListComponent },
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
export class AppModule {
}
