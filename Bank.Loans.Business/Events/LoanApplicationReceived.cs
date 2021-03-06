﻿using System;
using Bank.Loans.Business.DTO;

namespace Bank.Loans.Business.Events
{
    public class LoanApplicationReceived
    {
        public LoanApplicationReceived(LoanRequest application)
        {
            Application = application;
            ReceivedOn = DateTime.UtcNow;
        }

        public LoanRequest Application { get; }
        public DateTime ReceivedOn { get; }
    }
}