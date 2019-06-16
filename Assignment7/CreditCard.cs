using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    public class CreditCard
    {
        public int id { get; set; }
        public Account account { get; set; }
        public String date { get; set; }
        public int pinCode { get; set; }
        public int wrongPinCodeAttempts { get; set; }
        public Boolean block { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(int id, Account account, String date, int pinCode, int wrong, Boolean block)
        {
            this.id = id;
            this.account = account;
            this.date = date;
            this.pinCode = pinCode;
            this.wrongPinCodeAttempts = wrong;
            this.block = block;
        }
    }
}
