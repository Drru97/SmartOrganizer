import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AppointmentService } from '../appointment.service';

import { Appointment } from '../../shared/models/appointment.model';

@Component({
    selector: 'appointment-add-dialog',
    templateUrl: './appointment-add-dialog.component.html',
    styleUrls: ['./appointment-add-dialog.component.css']
})
export class AppointmentAddDialogComponent implements OnInit {
    title = new FormControl('', [Validators.required]);
    description = new FormControl('', []);
    location = new FormControl('', [Validators.required]);
    startDate = new FormControl('', [Validators.required]);
    endDate = new FormControl('', [Validators.required]);

    isEdit: boolean = false;

    private appointment: Appointment;

    constructor(public dialogRef: MatDialogRef<AppointmentAddDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private service: AppointmentService) {
    }

    ngOnInit(): void {
        if (this.data && this.data.selectedAppointment) {
            this.isEdit = true;
            let selectedAppointment = this.data.selectedAppointment;

            this.title.setValue(selectedAppointment.title);
            this.description.setValue(selectedAppointment.description);
            this.location.setValue(selectedAppointment.location);
            this.startDate.setValue(selectedAppointment.startDate);
            this.endDate.setValue(selectedAppointment.endDate);
        }
    }


    cancel() {
        this.dialogRef.close();
    }

    getErrorMessage() {
        return 'You must input a value';
    }

    save() {
        this.appointment = new Appointment();
        this.appointment.title = this.title.value;
        this.appointment.description = this.description.value;
        this.appointment.location = this.location.value;
        this.appointment.startDate = this.startDate.value;
        this.appointment.endDate = this.endDate.value;
        
        if (this.isEdit) {
            this.service.addAppointment(this.appointment).subscribe(() => console.log('appointment added'));
        }
        else {
            let appointmentId = this.data.selectedAppointment.id;
            this.service.editAppointment(appointmentId, this.appointment).subscribe(() => console.log("Appointment modified"));
        }
                
        this.cancel();
    }
}

