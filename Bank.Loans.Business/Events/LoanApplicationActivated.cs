using System;
using Bank.Loans.Business.DTO;

namespace Bank.Loans.Business.Events
{
    public class LoanApplicationActivated
    {
        public LoanApplicationActivated(LoanRequest application)
        {
            Application = application;
            ActivatedOn = DateTime.UtcNow;
            ActivatedBy = "SYSTEM";
        }

        public LoanRequest Application { get; }
        public DateTime ActivatedOn { get; }
        public string ActivatedBy { get; }
    }
}