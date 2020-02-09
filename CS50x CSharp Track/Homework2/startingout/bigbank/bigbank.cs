//CS50xMiami C# Track 
//Assignment: HW 2
//Student: Dylan Perez 
//Date Submitted: May 17, 2017

using System;
using System.Collections.Generic;

namespace bigbank
{
    /* Object Declarations */
    public abstract class account{

        public virtual List<customer> associatedCustomers { get; set; }
        public virtual int accountNumber { get; set; }

        public virtual string accountName { get; set; }

        public virtual decimal accountBalance { get; set; }
    } //end base acc
    
    public class checkingAccount : account {
        public checkingAccount( int accNumber, string accName, decimal startingBalance, customer cust ){

            this.associatedCustomers = new List<customer>();
            this.associatedCustomers.Add(cust);
            this.accountNumber = accNumber;
            this.accountName = accName;
            this.accountBalance = startingBalance;

        }
    } // end check acc

    public class savingsAccount : account {
        public savingsAccount( int accNumber, string accName, decimal startingBalance, customer cust ){

            this.associatedCustomers = new List<customer>();
            this.associatedCustomers.Add(cust);
            this.accountNumber = accNumber;
            this.accountName = accName;
            this.accountBalance = startingBalance;
            this.fixedInterestRate = 1.5m;

        }

        public decimal fixedInterestRate { get; set; }
    } // end sav acc

    public class customer {

        public customer( string cusName, int custNum){

            this.associatedAccounts = new List<int>();
            this.name = cusName;
            this.customerNum = custNum;

        }
        public customer( string cusName, int custNum, int accountNum){

            this.associatedAccounts = new List<int>();
            this.associatedAccounts.Add(accountNum);
            this.name = cusName;
            this.customerNum = custNum;

        }
        public customer( string cusName, int custNum, List<int> accounts ) {
            this.name = cusName;
            this.customerNum = custNum;

            this.associatedAccounts = new List<int>();
            this.associatedAccounts = accounts;
        }
        public string name { get; set; }

        public int customerNum { get; set; }

        public List<int> associatedAccounts { get; set; }
    } // end customer class
    class Program
    {
        // ////////////////
        /* Main Function */
        // ////////////////
        static void Main(string[] args)
        {
            /* Start Bank Data Variables */
            List<customer> allCustomers = new List<customer>();
            List<account> allAccounts = new List<account>();
            /* End Bank Data Variables */

            bool keepRunning = true;

            while ( keepRunning == true )
            {
                Console.Clear();
                Console.WriteLine("Welcome to Big Bank, Inc.\n\nWhat would you like to do today?\n\n1 - Make a Deposit.\n2 - Make a Withdraw.\n3 - Account Maintenance." + 
                "\n4 - Customer Maintenance.\n5 - Branch Information.\n6 - Exit.");

                string userInput = Console.ReadLine(); // get user selection
                int caseCheck;

                Int32.TryParse(userInput, out caseCheck); // parse the selection

                switch ( caseCheck )
                {
                    case 1:
                        deposit();
                        break;

                    case 2:
                        withdraw();
                        break;

                    case 3:
                        accountMaintenance( ref allCustomers, ref allAccounts);
                        break;

                    case 4:
                        customerMaintenance(ref allCustomers);
                        break;

                    case 5:
                        branchInformation();
                        break;
                    
                    case 6:
                        keepRunning = false;
                        Console.Clear();
                        Console.WriteLine("\n\nThank you for helping to make Big Bank, Inc. the best banking experience possible.\n\n");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option selected. (Hint: Enter a number 1 - 6 for your chosen selection).\n"); 
                        break;
                }
            }
        }
        // /////////////////////////////////////
        /*Start of Main Menu Option Functions */
        // /////////////////////////////////////
        static bool deposit(){
            return false;
        }

        static bool withdraw(){
            return false;
        }

        static void accountMaintenance(ref List<customer> allCustomers, ref List<account> allAccounts){
            string yes = "Yes";
            bool stayInFunction = true;
            bool firstOperation = true;

            while ( stayInFunction ) {

                if ( firstOperation)
                {
                    Console.Clear();
                }

                Console.WriteLine("~ Account Maintenance ~\n\nWhat would you like to do?\n\n1 - Add new Account.\n2 - Close Account.\n3 - View Account Details.\n4 - Return to Main Menu.");

                string userInput = Console.ReadLine(); // get user selection
                int caseCheck;

                Int32.TryParse(userInput, out caseCheck); // parse the selection

                switch ( caseCheck )
                {
                    
                    case 1:
                    {
                        bool stillAdding = true;
                        string name = ""; // a name for the account e.g. "My Checking Account"
                        int type = 0; // 1 for Checking, 2 for Savings
                        int number = 0;
                        decimal startBal = 0m;
                        customer Cust = null;

                        while ( stillAdding )
                        {
                        Console.Clear();

                            if ( name == "" )
                            {
                                bool acceptName = false;
                            Console.WriteLine("Please enter a Name for the Account: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept Name? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptName = true;
                                }

                                if ( acceptName == true )
                                {
                                    name = temp;
                                }
                            }

                            if ( number == 0)
                            {
                                bool acceptNumber = false;
                            Console.WriteLine("Please enter Account Number: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept Account Number? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptNumber = true;
                                }

                                if ( acceptNumber == true )
                                {
                                    Int32.TryParse(temp, out number);
                                }

                            }

                            if ( Cust == null )
                            {
                            Console.WriteLine("Please enter Customer Number: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept Customer Number? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    int tnum;
                                    Int32.TryParse(temp, out tnum );

                                    foreach (customer alpha in allCustomers)
                                    {
                                        if( alpha.customerNum == tnum)
                                        {
                                            Cust = alpha;
                                        }
                                    }
                                }
                            }

                            if ( startBal == 0m )
                            {
                                bool acceptBal = false;
                            Console.WriteLine("Please enter a Starting Balance: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\nCorrect starting balance? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptBal = true;
                                }

                                if ( acceptBal == true )
                                {
                                    decimal.TryParse(temp, out startBal);
                                }

                            }

                            if ( type == 0 )
                            {
                                bool acceptType = false;
                            Console.WriteLine("Please select the type of account (Enter: 1 for checking || 2 for savings): ");
                            string temp = Console.ReadLine();
                            if ( temp == "1")
                            {
                            Console.WriteLine("You selected Checking account, is this correct? (Yes to Accept)");
                            }
                            else if ( temp == "2")
                            {
                            Console.WriteLine("You selected Savings account, is this correct? (Yes to Accept)");
                            }
                            else 
                            {
                            Console.WriteLine("Invalid option selected.");
                            break;
                            }
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptType = true;
                                }

                                if ( acceptType == true )
                                {
                                    Int32.TryParse(temp, out type); //imhere
                                }
                            }

                            if ( name != "" && number != 0 && Cust != null && type != 0 && startBal != 0m ) {
                                addAccount(ref Cust, ref allAccounts, name, number, startBal, type);
                                Console.WriteLine("\n\nNew Account Created!\n\n");
                                stillAdding = false;
                            }
                        }

                        firstOperation = false;

                        break;
                    }
                    case 2:
                    {
                        break;
                    }
                    case 3:
                    {
                        break;
                    }
                    case 4:
                    {
                        stayInFunction = false;
                        break;
                    }
                }

            }

        }

        static void customerMaintenance(ref List<customer> allCustomers){
            string yes = "Yes";
            bool stayInFunction = true;
            bool firstOperation = true;

            while ( stayInFunction ) {

                if (firstOperation)
                {
                    Console.Clear();
                }
                
                Console.WriteLine("~ Customer Maintenance ~\n\nWhat would you like to do?\n\n1 - Add new customer.\n2 - Delete a customer.\n3 - Edit customer details.\n4 - Return to Main Menu.");

                string userInput = Console.ReadLine(); // get user selection
                int caseCheck;

                Int32.TryParse(userInput, out caseCheck); // parse the selection

                switch ( caseCheck ) 
                {
                    case 1:
                    {
                        bool stillAdding = true;
                        string name = "";
                        int number = 0;

                        while ( stillAdding )
                        {
                        Console.Clear();

                            if ( name == "" )
                            {
                                bool acceptName = false;
                            Console.WriteLine("Please enter Customer Name: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept Name? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptName = true;
                                }

                                if ( acceptName == true )
                                {
                                    name = temp;
                                }
                            }

                            if ( number == 0)
                            {
                                bool acceptNumber = false;
                            Console.WriteLine("Please enter Customer Number: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept Number? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptNumber = true;
                                }

                                if ( acceptNumber == true )
                                {
                                    Int32.TryParse(temp, out number);
                                }
                            }

                            if ( name != "" && number != 0) {
                                addCustomer( ref allCustomers, name, number );
                                Console.WriteLine("\n\nNew Customer Created!\n\n");
                                stillAdding = false;
                            }
                        }

                        firstOperation = false;

                        break;
                    }

                    case 2:
                    {
                        bool stillDeleting = true;
                        string name = "";
                        int number = 0;

                        while ( stillDeleting )
                        {
                        Console.Clear();

                            if ( name == "" )
                            {
                                bool acceptName = false;
                            Console.WriteLine("Please enter name of Customer to be Deleted: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptName = true;
                                }

                                if ( acceptName == true )
                                {
                                    name = temp;
                                }
                            }

                            if ( number == 0)
                            {
                                bool acceptNumber = false;
                            Console.WriteLine("Please enter: " + name + "'s Customer Number: ");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + "\n Accept Number? (Yes to Accept)");
                            string answer = Console.ReadLine();
                                if (string.Equals(answer, yes, StringComparison.OrdinalIgnoreCase))
                                {
                                    acceptNumber = true;
                                }

                                if ( acceptNumber == true )
                                {
                                    Int32.TryParse(temp, out number);
                                }
                            }

                            if ( name != "" && number != 0) {
                                deleteCustomer( ref allCustomers, name, number );
                                Console.WriteLine("\n\n" + name + " Deleted from Customers.\n\n");
                                stillDeleting = false;
                            }
                        }

                        firstOperation = false;

                        break;
                    }

                    case 3:

                        break;
                    
                    case 4:

                        stayInFunction = false;

                        break;

                    default:

                        break;
                }
            }

        }

        static void branchInformation(){

        }
        // ///////////////////////////////////
        /*End of Main Menu Option Functions */
        // ///////////////////////////////////
        //
        //
        // ////////////////////
        /* Utility Functions */
        // ////////////////////
        static bool addCustomer(ref List<customer> allCustomers, string name, int number){
            customer newCustomer = new customer(name, number);
            allCustomers.Add(newCustomer);
            return true;
        }

        static bool deleteCustomer(ref List<customer> allCustomers, string name, int number){
            customer toBeDelete = new customer (name, number);
            allCustomers.Remove(toBeDelete);
            return true;
        }

        static bool addAccount (ref customer cust, ref List<account> allAccounts, string name, int number, decimal startBalance, int type ) {
            if (type == 1){

                account newAccount = new checkingAccount( number, name, startBalance, cust );
                allAccounts.Add(newAccount);

            }
            else if (type == 2){
                
                account newAccount = new savingsAccount( number, name, startBalance, cust );
                allAccounts.Add(newAccount);

            }
            return true;
        }

        static bool closeAccount (ref customer cust, ref List<account> allAccounts, ref account toBeClosed){
            
            return true;
        }
    }
}

/*

Deposit - 

Withdraw - 

Account Maintenance: Create - checking or saving, Delete any - each account must have a customer. 

Customer Maintenance - (customers can have multiple accounts)

Branch Information -

Savings accounts should have an associated fixed interest rate at 1.5%.


 */