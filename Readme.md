# Tasks

## Initial (2 pomodoros)

* Remove all the resource groups from the portal
* Add a "FunctionsApp" resource called "LetsGetServerless" to the portal.
* Create an empty solution - LetsGetServerless
* Add a .NET Core 2.1 class library - Bank.Loans.Business
* Add an azure functions project - Bank.Loans.Functions
* Install the nuget package `Microsoft.Azure.WebJobs.Extensions.Storage` (version 3.0.0)
* Add an http triggered function - `RequestLoan`
  * Log all the important steps.
  * Must read the content from `HttpRequest` object and create a `LoanApplicationReceived` event and add it to the queue `loan-applications`.
* Deploy the function to portal ('LetsGetServerless' function app).


## ValidateLoan (1 Pomodoro)
* Create a queue triggered function
* Input binding should be of type `LoanApplicationReceived`
* Validate the `Application` property in that event

```
Name != null && Age >= 18
```
*  Create a `LoanApplicationValidated` event and, if the application is valid, add it to a blob collection called, and  `accepted-applications` else add it to a `rejected-applications`.
*  Log all the important steps.
*  Deploy the solution to the portal.

## ProcessApplication (1 pomodoro)
* Create a blob triggered azure function.
* The blob container it will be referring to it is the `accepted-loans`.
* Create a `ActiveLoans` event and add it to another blob container called `active-loans`
* Deploy it to the portal