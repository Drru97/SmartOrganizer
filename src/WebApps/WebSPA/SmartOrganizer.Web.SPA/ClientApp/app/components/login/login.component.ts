import { Component, OnInit } from '@angular/core';

import { LoginService } from './login.service';
import { SocialUser, GoogleLoginProvider } from 'angularx-social-login';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    private user: SocialUser;

    constructor(private loginService: LoginService) { }

    ngOnInit(): void {
        this.loginService.authService.authState.subscribe((user) => {
            this.user = user;
        });
    }

    login(): void {
        this.loginService.signIn();
    }

    logout(): void {
        this.loginService.signOut()
    }
}
