import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'appointment-detail',
    templateUrl: './appointment-detail.component.html',
    styleUrls: ['./appointment-detail.component.css']
})
export class AppointmentDetailComponent implements OnInit {
    private url = 'http://localhost:8001/api/appointment/';
    public appointmentDetail: IAppointmentDetail;

    constructor(private http: Http, private route: ActivatedRoute, private router: Router) {
    }

    ngOnInit(): void {
        const param = this.route.snapshot.paramMap.get('id');
        if (param) {
            const id = +param;
            this.getAppointmentDetail(this.http, id);
        }
    }

    onBack(): void {
        this.router.navigate(['/appointment']);
    }

    getAppointmentDetail(http: Http, id: number) {
        http.get(this.url + id).subscribe(result => {
            this.appointmentDetail = result.json() as IAppointmentDetail;
        }, error => console.log(error));
    }
}

interface IAppointmentDetail {
    id: number;
    title: string;
    description: string;
    location: string;
    startDate: Date;
    duration: string;
}