using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Bank.Loans.Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Bank.Loans.Business.Events;
using Newtonsoft.Json;

namespace Bank.Loans.Functions
{
    public static class RequestLoan
    {
        [FunctionName(nameof(RequestLoan))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")]HttpRequest request,
            [Queue("loan-applications")]IAsyncCollector<LoanApplicationReceived> loanApplicationsQueue,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(RequestLoan)} process started");

            var content = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
            var loanRequest = JsonConvert.DeserializeObject<LoanRequest>(content);

            logger.LogInformation("Loan application read from the request body");

            var loanApplicationReceived = new LoanApplicationReceived(loanRequest);

            logger.LogInformation("Loan application was successfully deserialized");

            await loanApplicationsQueue.AddAsync(loanApplicationReceived).ConfigureAwait(false);

            logger.LogInformation("LoanApplicationReceived event data was sent to the queue");

            return new OkObjectResult(loanApplicationReceived);
        }
    }
}
