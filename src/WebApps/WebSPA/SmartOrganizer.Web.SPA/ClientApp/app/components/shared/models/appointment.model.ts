import { Injectable } from '@angular/core';

@Injectable()
export class Appointment {
    id: number;
    title: string;
    description: string;
    location: string;
    startDate: Date;
    duration: string;
}
