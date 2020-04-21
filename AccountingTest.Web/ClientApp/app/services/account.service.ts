import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { AccountModel } from '../models/account';


@Injectable()
export class AccountService {
    // Resolve HTTP using the constructor
    constructor(private http: Http) { }
    // private instance variable to hold base url
    private accountsUrl = 'http://localhost:5001/api/accounts';


    getAccount(): Observable<AccountModel> {

        return this.http.get(this.accountsUrl)
            .map(res => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));

    }
}