import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material';

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

    constructor(public dialog: MatDialog,
        private service: AppointmentService,
        private configurationService: ConfigurationService,
        private router: Router) {
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
                width: '50%',
                height: '50%',
                data:
                {
                    action: 'Add',
                    app: this.newAppointment
                }
            });

        dialogRef.afterClosed().subscribe(result => {
            this.newAppointment = result;
        });
    }

    editAppointment(id: number): void {
        let appointment = this.appointments.find(i => i.id === id);

        let dialogRef = this.dialog.open(AppointmentAddDialogComponent,
            {
                width: '50%',
                height: '50%',
                data: {
                    selectedAppointment: appointment,
                    action: 'Edit'
                }
            });
        
        //  this.router.navigate([`/appointment/${id}`]);
    }

    deleteAppointment(id: number): void {
        let index = this.appointments.findIndex(i => i.id === id);
        this.appointments.splice(index, 1);
        this.service.deleteAppointment(id).subscribe(() => console.log('deleted'));
    }
}
