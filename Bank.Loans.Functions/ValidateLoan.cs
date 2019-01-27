using System;
using System.Collections.Generic;
using System.Text;
using Bank.Loans.Business.Events;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bank.Loans.Functions
{
    public static class ValidateLoan
    {
        [FunctionName("ValidateLoan")]
        public static void Run([QueueTrigger("loan-applications")]LoanApplicationReceived applicationReceivedEvent, 
            [Blob("accepted-applications/{rand-guid}")]out string acceptedApplication,
            [Blob("rejected-applications/{rand-guid}")]out string rejectedApplication,
            ILogger logger)
        {
            acceptedApplication = null;
            rejectedApplication = null;

            logger.LogInformation($"{nameof(ValidateLoan)} started");

            var application = applicationReceivedEvent.Application;

            logger.LogInformation($"Validating the loan application for {application.Name}");

            var isValid = !string.IsNullOrWhiteSpace(application.Name) && application.Age >= 18;

            var loanApplicationValidatedEvent = new LoanApplicationValidated(application, isValid, isValid? "Valid" : "Invalid");
            var eventContent = JsonConvert.SerializeObject(loanApplicationValidatedEvent);

            if (isValid)
            {
                acceptedApplication = eventContent;
                logger.LogInformation($"Accepted the loan application for {application.Name}");
            }
            else
            {
                rejectedApplication = eventContent;
                logger.LogInformation($"Rejected the loan application for {application.Name}");
            }
        }
    }
}
