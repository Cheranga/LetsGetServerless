using System;
using Bank.Loans.Business.DTO;

namespace Bank.Loans.Business.Events
{
    public class LoanApplicationValidated
    {
        public LoanApplicationValidated(LoanRequest application, bool status, string comments)
        {
            Application = application;
            Status = status;
            Comments = comments;

            ValidatedOn = DateTime.UtcNow;
            ValidatedBy = "SYSTEM";
        }

        public bool Status { get; }
        public string Comments { get; }

        public LoanRequest Application { get; }
        public DateTime ValidatedOn { get; }
        public string ValidatedBy { get; }
    }
}