import { Injectable } from '@angular/core';

import { SocialLoginModule, AuthService, AuthServiceConfig, GoogleLoginProvider, SocialUser } from "angularx-social-login";

@Injectable()
export class LoginService {
    private authorizedUser: SocialUser;

    constructor(public authService: AuthService) { }

    signIn(): void {
        this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
    }

    signOut(): void {
        this.authService.signOut();
    }
}
