import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';

import { AppointmentService } from '../appointment.service';
import { ConfigurationService } from '../../shared/services/configuration.service';
import { Appointment } from '../../shared/models/appointment.model';
import { AppointmentAddDialogComponent } from '../appointment-add-dialog/appointment-add-dialog.component';

@Component({
    selector: 'appointment-list',
    templateUrl: './appointment-list.component.html',
    styleUrls: ['./appointment-list.css']
})
export class AppointmentListComponent implements OnInit {
    appointments: Appointment[];
    newAppointment: Appointment;

    constructor(
        private service: AppointmentService,
        private configurationService: ConfigurationService,
        private router: Router,
        public dialog: MatDialog) {
    }

    ngOnInit(): void {
        console.log('load');
        if (this.configurationService.isReady) {
            this.loadAppointments();
        } else {
            this.configurationService.settingsLoaded$.subscribe(() => {
                this.loadAppointments();
            });
        }
    }

    loadAppointments(): void {
        this.service.getAppointments()
            .subscribe(appointments => {
                this.appointments = appointments;
            });
    }

    openDialog(): void {
        let dialogRef = this.dialog.open(AppointmentAddDialogComponent,
            {
                width: '250px',
                height: '250px',
                data: this.newAppointment
            });

        dialogRef.afterClosed().subscribe(result => {
            this.newAppointment = result;
        });
    }

    editAppointment(id: number): void {
        this.router.navigate([`/appointment/${id}`]);
    }

    deleteAppointment(id: number): void {
        
    }
}
