using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    public class Account
    {
        public int id { get; set; }
        public double balance { get; set; }

        public Account()
        {

        }

        public Account(int id, double balance)
        {
            this.id = id;
            this.balance = balance;
        }

        public void deposit(double amount)
        {
            this.balance = this.balance + amount;
        }

        public void withdraw(double amount)
        {
            this.balance = this.balance - amount;
        }
    }
}
