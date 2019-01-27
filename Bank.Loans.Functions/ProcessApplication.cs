using Bank.Loans.Business.Events;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bank.Loans.Functions
{
    public static class ProcessApplication
    {
        [FunctionName("ProcessApplication")]
        public static void Run([BlobTrigger("accepted-applications/{name}")] string acceptedLoan,
            [Blob("active-loans/{rand-guid}")] out string activeLoan,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(ProcessApplication)}");
            var eventData = JsonConvert.DeserializeObject<LoanApplicationValidated>(acceptedLoan);
            var application = eventData.Application;


            var activatedLoanEvent = new LoanApplicationActivated(application);
            logger.LogInformation($"Activated loan application event created for {application.Name}");
            var content = JsonConvert.SerializeObject(activatedLoanEvent);

            activeLoan = content;

            logger.LogInformation($"Loan is activated for {application.Name}");
        }
    }
}