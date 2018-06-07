import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider } from "angularx-social-login";

import { LoginService } from './login.service';

import { LoginComponent } from './login.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild([
            { path: 'login', component: LoginComponent }
        ])
    ],
    providers: [
        LoginService
    ],
    declarations: [
        LoginComponent
    ]
})
export class LoginModule { }
