import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AppointmentDetailComponent } from './appointment-detail/appointment-detail.component';
import { AppointmentGuardService } from '../appointment/appointment-guard/appointment-guard.service';

import { AppointmentService } from './appointment.service';

import { ModelModule } from '../../components/shared/models/model.module';

import { MdlExpansionPanelModule } from '@angular-mdl/expansion-panel';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild([
            { path: 'appointment', component: AppointmentListComponent },
            { path: 'appointment/:id', canActivate: [AppointmentGuardService], component: AppointmentDetailComponent }
        ]),
        ModelModule,
        MdlExpansionPanelModule
    ],
    declarations: [
        AppointmentListComponent,
        AppointmentDetailComponent
    ],
    providers: [
        AppointmentService,
        AppointmentGuardService
    ],
    exports: [
        AppointmentListComponent
    ]
})
export class AppointmentModule { }
