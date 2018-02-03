import { Injectable } from '@angular/core';
import { Http, Response, RequestOptionsArgs } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class DataService {
    constructor(private http: Http) { }

    public get(url: string, params?: any): Observable<Response> {
        let options: RequestOptionsArgs = {};
        return this.http.get(url, options)
            .map((response: Response) => {
                return response;
            }).catch(this.handleError);
    }

    public post(url: string, data: any, params?: any) {
        let options: RequestOptionsArgs = {};

        return this.http.post(url, data, options).map(
            (response: Response) => {
                return response;
            }).catch(this.handleError);
    }

    public put(url: string, data: any, params?: any) {
        let options: RequestOptionsArgs = {};

        return this.http.put(url, data, options).map((response: Response) => {
            return response;
        }).catch(this.handleError);
    }

    public delete(url: string, params?: any) {
        return this.http.delete(url).map((response: Response) => {
            return response;
        }).catch(this.handleError);
    }

    private handleError(error: any) {
        console.error('Server error: ', error);

        if (error instanceof Response) {
            let errorMessage = '';
            try {
                errorMessage = error.json();
            } catch (e) {
                errorMessage = error.statusText;
            }

            return Observable.throw(errorMessage);
        }

        return Observable.throw(error || 'Server error');
    }
}
