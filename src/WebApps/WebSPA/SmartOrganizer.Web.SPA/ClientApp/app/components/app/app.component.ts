import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../components/shared/services/configuration.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    constructor(private configurationService: ConfigurationService) { }

    ngOnInit(): void {
        this.configurationService.load();
    }
}
