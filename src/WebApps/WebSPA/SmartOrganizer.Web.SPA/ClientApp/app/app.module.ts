import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { MdlModule } from '@angular-mdl/core';

import { AppointmentModule } from './components/appointment/appointment.module';
import { AppComponent } from './components/app/app.component';

import { DataService } from './components/shared/services/data.service';
import { ConfigurationService } from './components/shared/services/configuration.service';
import { StorageService } from './components/shared/services/storage.service';

import { LocalStorageModule } from 'angular-2-local-storage';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: '**', redirectTo: 'home' }
        ]),
        MdlModule,
        NoopAnimationsModule,
        AppointmentModule,
        LocalStorageModule.withConfig({
            prefix: 'app',
            storageType: 'localStorage'
        })
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
    ]
})
export class AppModule {
}
