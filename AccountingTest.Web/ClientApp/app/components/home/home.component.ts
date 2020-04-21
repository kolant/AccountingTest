import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { AccountModel } from '../../models/account';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public account: AccountModel;

    constructor(private _accountService: AccountService) {

        this.account = new AccountModel();
        this.account.balanceValue = 0;

        this._accountService.getAccount().subscribe(res => {
            this.account = res;
        });
    }
}
