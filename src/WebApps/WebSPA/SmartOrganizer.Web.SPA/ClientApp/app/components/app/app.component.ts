import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ConfigurationService } from '../../components/shared/services/configuration.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    activeTabIndex = 0;

    constructor(private configurationService: ConfigurationService, private router: Router) { }

    ngOnInit(): void {
        this.configurationService.load();
    }

    tabChanged({ index }): void {
        console.log(index);
        this.activeTabIndex = index;
        switch (this.activeTabIndex) {
            case 0:
                this.router.navigate(['/home']);
                break;
            case 1:
                this.router.navigate(['/appointment']);
                break;
            case 2:
                this.router.navigate(['/statistics']);
                break;
        }
    }

    tabClicked(event): void {
        console.log(event);
        switch (event) {
            case 0:
                this.router.navigate(['/home']);
                break;
            case 1:
                this.router.navigate(['/appointment']);
                break;
            case 2:
                this.router.navigate(['/statistics']);
                break;
            default:
                return;
        }
    }
}
