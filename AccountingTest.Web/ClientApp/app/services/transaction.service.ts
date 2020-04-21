import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Transaction } from '../models/transaction';

@Injectable()
export class TransactionService {

    constructor(private http: Http) { }

    private transactionsUrl = 'http://localhost:5001/api/transactions';
    
    getTransactions(): Observable<Transaction[]> {
    
        return this.http.get(this.transactionsUrl)
            .map(res => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));

    }
}