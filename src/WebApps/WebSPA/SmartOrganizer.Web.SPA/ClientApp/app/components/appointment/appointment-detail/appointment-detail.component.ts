import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AppointmentService } from '../appointment.service';
import { Appointment } from '../../shared/models/appointment.model';

@Component({
    selector: 'appointment-detail',
    templateUrl: './appointment-detail.component.html',
    styleUrls: ['./appointment-detail.component.css']
})
export class AppointmentDetailComponent implements OnInit {
    appointment: Appointment;

    constructor(private route: ActivatedRoute, private router: Router, private service: AppointmentService) {
        console.log('detail');
    }

    ngOnInit(): void {
        const param = this.route.snapshot.paramMap.get('id');
        if (param) {
            const id = +param;
            console.log(id);
            this.loadAppointmentDetail(id);
        }
    }

    onBack(): void {
        this.router.navigate(['/appointment']);
    }

    loadAppointmentDetail(id: number): void {
        this.service.getAppointment(id).subscribe(appointment => {
            this.appointment = appointment;
        });
    }
}
