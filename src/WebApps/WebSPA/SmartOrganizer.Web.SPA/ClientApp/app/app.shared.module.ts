import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { AppointmentListComponent } from './components/appointment-list/appointment-list.component';
import { AppointmentDetailComponent } from './components/appointment-detail/appointment-detail.component';
import { AppointmentGuardService } from './components/appointment-guard/appointment-guard.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        AppointmentListComponent,
        AppointmentDetailComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'appointment', component: AppointmentListComponent },
            {
                path: 'appointment/:id',
                canActivate: [AppointmentGuardService],
                component: AppointmentDetailComponent
            },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        AppointmentGuardService
    ]
})
export class AppModuleShared {
}
