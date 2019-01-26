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