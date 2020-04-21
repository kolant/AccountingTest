import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { TransactionLogComponent } from './components/transaction-log/transaction-log.component';

import { BrowserModule } from '@angular/platform-browser';
import { TransactionService } from './services/transaction.service';
import { AccountService } from './services/account.service';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        TransactionLogComponent,
        HomeComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'transaction-log', component: TransactionLogComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        TransactionService,
        AccountService
    ]
})
export class AppModuleShared {
}
