import { Injectable } from '@angular/core';
import { Response } from '@angular/http';

import { DataService } from '../shared/services/data.service';
import { ConfigurationService } from '../shared/services/configuration.service';
import { Appointment } from '../shared/models/appointment.model';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AppointmentService {
    private timetableUrl: string = '';

    constructor(private dataService: DataService, private configurationService: ConfigurationService) {
        this.configurationService.settingsLoaded$.subscribe(() => {
            this.timetableUrl = this.configurationService.serverSettings.timetableUrl + '/api/appointment';
        });
    }

    getAppointments(): Observable<Appointment[]> {
        console.log(this.timetableUrl);
        return this.dataService.get(this.timetableUrl).map((response: Response) => {
            return response.json()['appointments'];
        });
    }

    getAppointment(id: number): Observable<Appointment> {
        let url = this.timetableUrl + `/${id}`;

        return this.dataService.get(url).map((response: Response) => {
            return response.json();
        });
    }
}
