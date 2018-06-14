var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { CalendarModule } from 'angular-calendar';
let AppointmentModule = class AppointmentModule {
};
AppointmentModule = __decorate([
    NgModule({
        imports: [
            BrowserAnimationsModule,
            CommonModule,
            FormsModule,
            CalendarModule,
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
            MatFormFieldModule,
            OwlDateTimeModule,
            OwlNativeDateTimeModule
        ],
        declarations: [
            AppointmentListComponent,
            AppointmentDetailComponent,
            AppointmentAddDialogComponent
        ],
        providers: [
            AppointmentService,
            AppointmentGuardService,
        ],
        exports: [
            AppointmentListComponent
        ],
        entryComponents: [
            AppointmentAddDialogComponent
        ],
        schemas: [
            CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA
        ]
    })
], AppointmentModule);
export { AppointmentModule };
//# sourceMappingURL=appointment.module.js.map