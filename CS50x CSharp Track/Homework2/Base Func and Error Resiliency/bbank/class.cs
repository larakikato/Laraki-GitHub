//CS50xMiami C# Track 
//Assignment: HW 2
//Student: Dylan Perez 
//Date Submitted: May 17, 2017

using System;
using System.Collections.Generic;

namespace bbank
{
    public class account
    {
        public account(customer cust, decimal startBal, UInt32 accNum) { //Constr. for checking

            this.accountNumber = accNum;
            this.balance = startBal;
            this.type = 1;
            this.owner = cust;
            this.fixedIntered = 0m;

        }

        public account(customer cust, decimal startBal, UInt32 accNum, decimal fir) { //Constr. for savings

            this.accountNumber = accNum;
            this.balance = startBal;
            this.type = 2;
            this.owner = cust;
            this.fixedIntered = fir;

        }
        public customer owner { get; set; }

        public int type { get; set; } //1 for checking, 2 for savings

        public decimal balance { get; set; }

        public decimal fixedIntered { get; set; } //Only associated with savings, should be implemented as 1.5m in main

        public UInt32 accountNumber { get; set; }
    }

    public class customer
    {
        public customer( string newName, UInt32 newCustNum ) {

            this.name = newName;
            this.customerNumber = newCustNum;
            this.associatedAccounts = new List<UInt32>();

        }
        public List<UInt32> associatedAccounts { get; set; }

        public string name { get; set; }

        public UInt32 customerNumber { get; set; } //A bit like a password, to verify customers identity, it's like their secret key
    }
}
