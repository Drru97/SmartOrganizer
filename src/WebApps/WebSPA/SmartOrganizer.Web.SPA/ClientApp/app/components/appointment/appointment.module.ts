import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AppointmentDetailComponent } from './appointment-detail/appointment-detail.component';
import { AppointmentGuardService } from './appointment-guard/appointment-guard.service';
import { AppointmentAddDialogComponent } from './appointment-add-dialog/appointment-add-dialog.component';

import { AppointmentService } from './appointment.service';

import { ModelModule } from '../../components/shared/models/model.module';

import { MdlExpansionPanelModule } from '@angular-mdl/expansion-panel';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogRef } from '@angular/material';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild([
            { path: 'appointment', component: AppointmentListComponent },
            { path: 'appointment/:id', canActivate: [AppointmentGuardService], component: AppointmentDetailComponent }
        ]),
        ModelModule,
        MdlExpansionPanelModule,
        MatExpansionModule,
        MatButtonModule,
        MatDialogModule,
        MatInputModule,
        MatFormFieldModule
    ],
    declarations: [
        AppointmentListComponent,
        AppointmentDetailComponent,
        AppointmentAddDialogComponent
    ],
    providers: [
        AppointmentService,
        AppointmentGuardService,
        MatDialogRef
    ],
    exports: [
        AppointmentListComponent
    ],
    entryComponents: [
        AppointmentAddDialogComponent
    ]
})
export class AppointmentModule { }
