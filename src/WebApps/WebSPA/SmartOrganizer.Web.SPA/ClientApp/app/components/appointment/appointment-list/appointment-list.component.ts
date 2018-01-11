import { Component, OnInit } from '@angular/core';

import { AppointmentService } from '../appointment.service';
import { ConfigurationService } from '../../shared/services/configuration.service';
import { Appointment } from '../../shared/models/appointment.model';

@Component({
    selector: 'appointment-list',
    templateUrl: './appointment-list.component.html',
    styleUrls: ['./appointment-list.css']
})
export class AppointmentListComponent implements OnInit {
    appointments: Appointment[];

    constructor(private service: AppointmentService, private configurationService: ConfigurationService) {
    }

    ngOnInit(): void {
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
}
