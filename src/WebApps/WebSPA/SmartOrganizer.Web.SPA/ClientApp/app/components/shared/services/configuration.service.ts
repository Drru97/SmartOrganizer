import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { StorageService } from './storage.service';

import { Subject } from 'rxjs/Subject';

@Injectable()
export class ConfigurationService {
    private settingsLoadedSource = new Subject();

    serverSettings: IConfiguration;
    settingsLoaded$ = this.settingsLoadedSource.asObservable();
    isReady: boolean = false;

    constructor(private http: Http, private storageService: StorageService) { }

    load() {
        const baseUrl = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
        console.log(baseUrl);
        const url = `${baseUrl}home/configuration`;

        this.http.get(url).subscribe(result => {
            this.serverSettings = result.json() as IConfiguration;
            this.storageService.store('timetableUrl', this.serverSettings.timetableUrl);
            this.storageService.store('analyticsUrl', this.serverSettings.analyticsUrl);
            this.storageService.store('identityUrl', this.serverSettings.identityUrl);

            console.log('server settings loaded');
            this.isReady = true;
            this.settingsLoadedSource.next();
        });
    }
}

interface IConfiguration {
    timetableUrl: string;
    analyticsUrl: string;
    identityUrl: string;
}
