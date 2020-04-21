import { Component, Inject } from '@angular/core';
import { TransactionService } from '../../services/transaction.service';
import { Transaction } from '../../models/transaction';
import { TransactionType } from '../../enum/transaction-type';
import { AccountService } from '../../services/account.service';
import { AccountModel } from '../../models/account';


@Component({
    selector: 'transaction-log',
    templateUrl: './transaction-log.component.html'
})
export class TransactionLogComponent {

    public isLoading: boolean = false;
    public accountModel: AccountModel = new AccountModel();
    public transactions: Transaction[] = [];
    public transactionType: any = TransactionType;

    public serverError: any;

    constructor(private _transactionService: TransactionService,
        private _accountService: AccountService) { }

    ngOnInit() {
        this.refresh();
    }

    refresh() {
        this.isLoading = true;
        this._transactionService.getTransactions().subscribe(transactions => {
            this.transactions = transactions;

                this._accountService.getAccount().subscribe(account => {
                    this.accountModel = account;

                    this.isLoading = false;
                });
            });
    }

    getLabelClassByType(type: TransactionType) {
        return type == TransactionType.Debit ? "success" : "danger";
    }
}
