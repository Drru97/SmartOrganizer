import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Appointment } from '../../shared/models/appointment.model';

@Component({
    selector: 'appointment-add-dialog',
    templateUrl: './appointment-add-dialog.component.html',
    styleUrls: ['./appointment-add-dialog.component.css']
})
export class AppointmentAddDialogComponent {
    title = new FormControl('', [Validators.required]);
    location = new FormControl('', [Validators.required]);

    constructor(public dialogRef: MatDialogRef<AppointmentAddDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

    onCancelClick() {
        this.dialogRef.close();
    }
}
