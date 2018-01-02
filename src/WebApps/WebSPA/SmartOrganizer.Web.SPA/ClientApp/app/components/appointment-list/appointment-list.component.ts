import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'appointment-list',
    templateUrl: './appointment-list.component.html'
})
export class AppointmentListComponent {
    private url = 'http://localhost:8001/api/appointment/';
    public appointments: IAppointmentTitle[];

    constructor(http: Http) {
        this.getAppointments(http);
    }

    getAppointments(http: Http) {
        http.get(this.url).subscribe(result => {
            this.appointments = result.json().appointments as IAppointmentTitle[];
        }, error => console.log(error));
    }
}

interface IAppointmentTitle {
    id: number,
    title: string;
}
