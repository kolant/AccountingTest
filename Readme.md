# Accounting notebook

## Requirements

We are looking to build a money accounting system. The application should be a web service. It should not do any real “transactional” work, just emulate the financial transactions logic (debit and credit).

We emulate debit and credit operations for a single user, so we always have just one financial account.

No security is required. So don't worry about authentication.

No real persistence is expected. Please don't invest time into DB integration.

Please avoid wasting time for complex project configuration. Use configuration from an existing project, if you have one, or use project skeleton generation tools for your technologies. Default configuration would be completely enough.

## Must have

1. Service must store the account value of the single user.
2. Service must be able to accept credit and debit financial transactions and update the account value correspondingly.
3. Any transaction, which leads to negative amount within the system, should be refused. Please provide http response code, which you think suits best for this case.
4. Application must store transactions history. Use in-memory storage. Pay attention that several transactions can be sent at the same time. The storage should be able to handle several transactions at the same time with concurrent access, where read transactions should not lock the storage and write transactions should lock both read and write operations.
5. It is necessary to design REST API by your vision in the scope of this task. There are some API recommendations. Please use these recommendations as the minimal scope, to avoid wasting time for not-needed operations.
6. In general, the service will be used programmatically via its RESTful API. For testing purposes Postman or any similar app can be used.
7. It should be possible to launch project/projects by a single-line-command. Please provide README.md
8. Target completion time is 3 hours. We would rather see what you were able to do in 3 hours than a full-blown application you’ve spent days implementing. Note that in addition to quality, time used is also factored into scoring the task.

## UX/UI requirements

1. We need a simple UI application for this web service.
2. Please don't spend time for making it beautiful. Use a standard CSS library, like Bootstrap with a theme (or any other).
3. UI application should display the transactions history list only. No other operation is required.
4. Transactions list should be done in accordion manner. By default the list shows short summary (type and amount) for each transaction. Full info for a transaction should be shown on user's click.
It would be good to have some coloring for credit and debit transactions.

## Expected Deliverables

1. Source code.
2. Binary versions of your applications that are ready to run. No build should be required.
3. Readme.

## Solution

This is accounting test app.
App works on :5001 port, so be sure it's available.

To start app simply run from cmd line `dotnet run` in AccountingTest.Web folder.

### Dotnet SDK

App requires dotnet-sdk to be installed. You can easly get it by going to

[dotnet-sdk](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install)

### Postman

You can easily check how api works with the next postman calls:
[Postman Collection](https://www.getpostman.com/collections/5ff90b08a7855c696cfa)
