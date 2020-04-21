import { TransactionType } from '../enum/transaction-type';

export class Transaction {
    public id: string;
    public amount: number;
    public effectiveDate: Date;
    public type: TransactionType;
}