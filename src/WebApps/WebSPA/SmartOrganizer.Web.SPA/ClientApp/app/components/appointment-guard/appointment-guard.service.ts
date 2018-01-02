﻿import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';

@Injectable()
export class AppointmentGuardService implements CanActivate {
    constructor(private router: Router) {  }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        const id = +route.url[1].path;

        if (isNaN(id) || id < 0) {
            console.log('Invalid appointment id');
            this.router.navigate(['/appointment']);
            return false;
        }

        return true;
    }
}
