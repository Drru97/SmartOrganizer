import { Injectable } from '@angular/core';

import { LocalStorageService } from 'angular-2-local-storage';

@Injectable()
export class StorageService {
    constructor(private storage: LocalStorageService) {
    }

    public store(key: string, value: any) {
        this.storage.set(key, JSON.stringify(value));
    }

    public retrieve(key: string): any {
        let item = this.storage.get(key);

        if (item && item !== 'undefined') {
            return JSON.parse(this.storage.get(key));
        }

        return null;
    }
}
