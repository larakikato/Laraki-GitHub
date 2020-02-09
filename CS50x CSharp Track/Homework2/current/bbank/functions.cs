//CS50xMiami C# Track 
//Assignment: HW 2
//Student: Dylan Perez 
//Date Submitted: May 17, 2017

using System;
using System.Collections.Generic;

namespace bbank
{
    public class basicFunctions {
        public static int getCase() { //grab user input and parse to int32

            int caseCheck = 0;

            string userInput = Console.ReadLine(); // get user selection

            Int32.TryParse(userInput, out caseCheck); // parse the selection

            return caseCheck;

        }

        public static string yesNoOrInvalid(string input){ //check if the user typed yes, no, or something invalid
            string yes = "Yes";
            string no =  "No";
            string invalid = "Invalid";

            if (string.Equals(input, yes, StringComparison.OrdinalIgnoreCase))
            {
                return yes;
            }
            else if (string.Equals(input, no, StringComparison.OrdinalIgnoreCase))
            {
                return no;
            }
            else 
            {
                return invalid;
            }
        }

        public static void invalidInputEntered (string message) {
            Console.WriteLine("\n\n");
            Console.WriteLine(message);
            Console.WriteLine("\n\n");
        }

        public static void invalidInputEntered () {
            Console.WriteLine("\n\nInvalid Input!\n\n");
        }
    }

    public class bankFunctions {
        // /////////////////////////////////////
        /*Start of Main Menu Option Functions */
        // /////////////////////////////////////
        public static bool deposit(){
            return false;
        }

        public static bool withdraw(){
            return false;
        }

        public static void accountMaintenance(ref List<customer> allCustomers, ref List<account> allAccounts){
            bool stayInFunction = true;
            bool firstOperation = true;

            while ( stayInFunction ) {

                if ( firstOperation )
                {
                    Console.Clear();
                }

                Console.WriteLine("~ Account Maintenance ~\n\nWhat would you like to do?\n\n1 - Add new Account.\n2 - Close Account.\n3 - View Account Details.\n4 - Return to Main Menu.");

                string userInput = Console.ReadLine(); //imhere
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
                                    Int32.TryParse(temp, out type);
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
                        account toBeClosed = null;
                        bool stillClosing = true;
                        int number = 0; //account number not customer number
                        List<customer> cust = null;

                        while ( stillClosing )
                        {
                            bool acceptNumber = false;
                            
                            if (number == 0)
                            {
                            Console.WriteLine("Enter the Account Number for the account you wish to close.");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + " accept account number? (Yes to Accept)");
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
                        }

                        foreach (account alpha in allAccounts)
                        {
                            if ( alpha.accountNumber == number)
                            {
                                Console.WriteLine ("We got here."); //imhere
                                toBeClosed = alpha;
                                cust = alpha.associatedCustomers;
                            }
                        }

                        Console.WriteLine("Account Number" + toBeClosed.accountNumber + " belongs to " + toBeClosed.associatedCustomers[0].name + " , Customer Number: " + 
                            toBeClosed.associatedCustomers[0].customerNum + "Proceed to Close? (Yes to Close Account)" );
                        string answer2 = Console.ReadLine();
                        if (string.Equals(answer2, yes, StringComparison.OrdinalIgnoreCase))
                        {
                            closeAccount(ref cust, ref allAccounts, ref toBeClosed, ref allCustomers); //closes the account
                            Console.WriteLine("\n\nAccount Closed Successfully.\n\n");
                            firstOperation = false;
                        }

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

        public static void customerMaintenance(ref List<customer> allCustomers){
            bool stayInFunction = true;
            bool firstOperation = true;

            while ( stayInFunction ) {

                if (firstOperation)
                {
                    Console.Clear();
                }
                
                Console.WriteLine("~ Customer Maintenance ~\n\nWhat would you like to do?\n\n1 - Add new customer.\n2 - Delete a customer.\n3 - Edit customer details.\n4 - Return to Main Menu.");

                int caseCheck = basicFunctions.getCase();

                switch ( caseCheck ) 
                {
                    case 1: //Complete
                    {
                        bool stillAdding = true;
                        string name = "";
                        UInt32 number = 0;

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
                                answer = basicFunctions.yesNoOrInvalid(answer);

                                    if (answer == "Yes" ) 
                                    {
                                        acceptName = true;
                                    }
                                    else if (answer == "No")
                                    {
                                        acceptName = false;
                                    }
                                    else if (answer == "Invalid")
                                    {
                                        basicFunctions.invalidInputEntered();
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
                                answer = basicFunctions.yesNoOrInvalid(answer);
                                if (answer == "Yes")
                                {
                                    acceptNumber = true;
                                }
                                else if (answer == "No")
                                {
                                    acceptNumber = false;
                                }
                                else
                                {
                                    basicFunctions.invalidInputEntered();
                                }

                                if ( acceptNumber == true )
                                {
                                    UInt32.TryParse(temp, out number);
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

                    case 2: //Complete
                    {
                        bool stillDeleting = true;
                        string name = "";
                        UInt32 number = 0;

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
                                answer = basicFunctions.yesNoOrInvalid(answer);

                                if (answer == "Yes")
                                {
                                    acceptName = true;
                                }
                                else if (answer == "No")
                                {
                                    acceptName = false;
                                }
                                else 
                                {
                                    basicFunctions.invalidInputEntered();
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
                                answer = basicFunctions.yesNoOrInvalid(answer);

                                if ( answer == "Yes")
                                {
                                    acceptNumber = true;
                                }
                                else if ( answer == "No" )
                                {
                                    acceptNumber = false;
                                }
                                else
                                {
                                    basicFunctions.invalidInputEntered();
                                }

                                if ( acceptNumber == true )
                                {
                                    UInt32.TryParse(temp, out number);
                                }
                            }

                            if ( name != "" && number != 0) { 
                                bool result = deleteCustomer( ref allCustomers, name, number );

                                if (result == true)
                                {
                                    Console.WriteLine("\n\n" + name + " Deleted from Customers.\n\n");
                                    stillDeleting = false;
                                }
                                else if (result == false)
                                {
                                    Console.WriteLine("\n\nCustomer was not able to be deleted!!\n\n");
                                    stillDeleting = false;
                                }
                            }
                        }

                        firstOperation = false;

                        break;
                    }

                    case 3: 
                    {
                        bool stillSelectingCustomer = true;
                        bool stillEditingCustomer = true;
                        customer toBeEdited = null;
                        UInt32 custNum = 0;


                        while (stillSelectingCustomer)
                        {
                            if (custNum == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter the Customer Number for the Customer you wish to edit.");
                                string temp = Console.ReadLine();
                                Console.WriteLine("You entered" + temp + " accept number? (Yes to Accept, No to Decline)");
                                string answer = Console.ReadLine();
                                answer = basicFunctions.yesNoOrInvalid(answer);

                                if (answer == "Yes")
                                {
                                    UInt32.TryParse(temp, out custNum);
                                    foreach (customer alpha in allCustomers)
                                    {
                                        if (alpha.customerNumber == custNum)
                                        {
                                            toBeEdited = alpha;
                                            custNum = 0;
                                        }
                                    }

                                    stillSelectingCustomer = false;

                                    firstOperation = false;
                                }
                                else if (answer == "No")
                                {
                                    stillSelectingCustomer = true;
                                }
                                else 
                                {
                                    basicFunctions.invalidInputEntered();
                                }
                            }
                        }

                        while (stillEditingCustomer)
                        {
                            Console.WriteLine("What would you like to do?\n\n1 - Change Name.\n2 - Change Customer Number.\n3" +
                                                 "- View Customer Details.\n4 - Exit edit customer details.");
                            int getCase = basicFunctions.getCase();

                            switch (getCase)
                            {
                                case 1:
                                {
                                    Console.WriteLine("Enter a new Customer Name");
                                    string temp = Console.ReadLine();
                                    Console.WriteLine("You entered" + temp + ". Accept new Name? (Yes to Accept, else No)");
                                    string answer = Console.ReadLine();
                                    answer = basicFunctions.yesNoOrInvalid(answer);
                                    if (answer == "Yes")
                                    {
                                        toBeEdited.name = temp;
                                        Console.WriteLine("Customer name changed to: " + toBeEdited.name);
                                        stillEditingCustomer = false;

                                    }
                                    else if (answer == "No")
                                    {
                                        stillEditingCustomer = true;
                                    }
                                    else 
                                    {
                                        basicFunctions.invalidInputEntered();
                                    }
                                    break;
                                }
                                case 2: 
                                {
                                    Console.WriteLine("Enter a new Customer Number");
                                    string temp = Console.ReadLine();
                                    Console.WriteLine("You entered" + temp + ". Accept new Number? (Yes to Accept, else No)");
                                    string answer = Console.ReadLine();
                                    answer = basicFunctions.yesNoOrInvalid(answer);
                                    if (answer == "Yes")
                                    {
                                        UInt32 newCustNum = 0;
                                        UInt32.TryParse(temp, out newCustNum);
                                        toBeEdited.customerNumber = newCustNum;
                                        Console.WriteLine("Customer number changed to: " + toBeEdited.customerNumber);
                                        stillEditingCustomer = false;

                                    }
                                    else if (answer == "No")
                                    {
                                        stillEditingCustomer = true;
                                    }
                                    else 
                                    {
                                        basicFunctions.invalidInputEntered();
                                    }
                                    break;
                                }

                                case 3: 
                                {
                                    Console.WriteLine("Showing Details for Customer: " + toBeEdited.name);
                                    Console.WriteLine("\nCustomer Number: " + toBeEdited.customerNumber);
                                    Console.WriteLine("\nAccounts Associated with Customer: ");
                                    foreach (UInt32 alpha in toBeEdited.associatedAccounts)
                                    {
                                        Console.WriteLine("\n" + alpha);
                                    }

                                    break;
                                }
                                case 4:

                                    break;

                                default:
                                    basicFunctions.invalidInputEntered();
                                    break;
                            }
                        }

                        break;
                    }
                    case 4:

                        stayInFunction = false;

                        break;

                    default:
                        basicFunctions.invalidInputEntered("You selected an invalid number");
                        break;
                }
            }

        }

        public static void branchInformation(){

        }
        // ///////////////////////////////////
        /*End of Main Menu Option Functions */
        // ///////////////////////////////////
        //
        //
        // ////////////////////
        /* Utility Functions */
        // ////////////////////
        static bool addCustomer(ref List<customer> allCustomers, string name, UInt32 number){
            customer newCustomer = new customer(name, number);
            allCustomers.Add(newCustomer);
            return true;
        }

        static bool deleteCustomer(ref List<customer> allCustomers, string name, UInt32 number){
            customer toBeDelete = null;
            foreach (customer alpha in allCustomers)
            {
                if ( alpha.name == name)
                {
                    if (alpha.customerNumber == number)
                    {
                        toBeDelete = alpha;
                        allCustomers.Remove(toBeDelete);
                        return true;
                    }
                }
            }
            
            return false;
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

        static bool closeAccount (ref List<customer> associatedCust, ref List<account> allAccounts, ref account toBeClosed, ref List<customer> allCustomers){

            foreach (customer alpha in associatedCust)
            {
                foreach (customer beta in allCustomers)
                {
                    if (alpha == beta)
                    {
                        beta.associatedAccounts.Remove(toBeClosed.accountNumber);
                    }
                }
            }

            allAccounts.Remove(toBeClosed);
            
            return true;
        }
    }
}