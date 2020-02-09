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
        public static bool deposit( ref List<customer> allCustomers, ref List<account> allAccounts ){

            bool stillDepositing = true;
            bool accountSelected = false;
            bool depositCompleted = false;
            account toDeposit = null;
            
            while (stillDepositing)
            {
                    if ( !accountSelected ) //select account
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the account number for which you'd like to make a deposit: ");
                        string temp = Console.ReadLine();
                        Console.WriteLine("You entered " + temp + " \nCorrect account number? (Yes or No)");
                        string answer = Console.ReadLine();
                        answer = basicFunctions.yesNoOrInvalid(answer);

                    if ( answer == "Yes")
                    {   
                        UInt32 temp2 = 0;
                        UInt32.TryParse(temp, out temp2);
                        foreach (account alpha in allAccounts)
                        {
                            if (temp2 == alpha.accountNumber)
                            {
                                toDeposit = alpha;
                            }
                        }

                        accountSelected = true;
                    }
                    else if (answer == "No")
                    {      
                        accountSelected = false;
                    }
                    else
                    {
                        basicFunctions.invalidInputEntered();
                    }
                }

                if ( accountSelected ) // account chosen, enter amount and complete deposit
                {
                    Console.WriteLine("Enter the amount of the deposit, do not include extraneous symbols.");
                    string temp = Console.ReadLine();
                    Console.WriteLine("You entered " + temp + " \ncorrect amount? (Yes or No)");
                    string answer = Console.ReadLine();
                    answer = basicFunctions.yesNoOrInvalid(answer);
                    
                    if (answer == "Yes")
                    {
                        decimal temp2 = 0;
                        decimal.TryParse(temp, out temp2);
                        foreach (account alpha in allAccounts)
                        {
                            if (alpha.accountNumber == toDeposit.accountNumber)
                            {
                                alpha.balance += temp2;
                                depositCompleted = true;
                                stillDepositing = false;
                            }
                        }
                    }
                    else if (answer == "No")
                    {
                        stillDepositing = true;
                    }
                    else
                    {
                        basicFunctions.invalidInputEntered();
                    }

                    if (depositCompleted == true)
                    {
                        bool stillDisplaying = true;

                        account toDisplay = null;

                        foreach (account alpha in allAccounts)
                        {
                            if (alpha.accountNumber == toDeposit.accountNumber)
                            {
                                toDisplay = alpha;
                            }
                        }

                        while (stillDisplaying)
                        {
                            Console.WriteLine("Deposit Completed\n\n New Balance: " + toDisplay.balance);
                            Console.WriteLine("Enter 1 to Return to Main Menu");
                            int getCase = basicFunctions.getCase();

                            switch (getCase)
                            {
                                case 1:
                                    stillDisplaying = false;
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }
            }

            return true;
        }

        public static bool withdraw( ref List<customer> allCustomers, ref List<account> allAccounts ){
            bool stillWithdrawing = true;
            bool accountSelected = false;
            bool withdrawCompleted = false;
            account toWithdraw = null;
            
            while (stillWithdrawing)
            {
                    if ( !accountSelected ) //select account
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the account number for which you'd like to make a withdraw: ");
                        string temp = Console.ReadLine();
                        Console.WriteLine("You entered " + temp + " \nCorrect account number? (Yes or No)");
                        string answer = Console.ReadLine();
                        answer = basicFunctions.yesNoOrInvalid(answer);

                    if ( answer == "Yes")
                    {   
                        UInt32 temp2 = 0;
                        UInt32.TryParse(temp, out temp2);
                        foreach (account alpha in allAccounts)
                        {
                            if (temp2 == alpha.accountNumber)
                            {
                                toWithdraw = alpha;
                            }
                        }

                        accountSelected = true;
                    }
                    else if (answer == "No")
                    {      
                        accountSelected = false;
                    }
                    else
                    {
                        basicFunctions.invalidInputEntered();
                    }
                }

                if ( accountSelected ) // account chosen, enter amount and complete withdraw
                {
                    Console.WriteLine("Current Balance: " + toWithdraw.balance);
                    Console.WriteLine("Enter the amount of the withdraw, do not include extraneous symbols.");
                    string temp = Console.ReadLine();
                    Console.WriteLine("You entered " + temp + " \ncorrect amount? (Yes or No)");
                    string answer = Console.ReadLine();
                    answer = basicFunctions.yesNoOrInvalid(answer);
                    
                    if (answer == "Yes")
                    {
                        decimal temp2 = 0;
                        decimal.TryParse(temp, out temp2);
                        foreach (account alpha in allAccounts)
                        {
                            if (alpha.accountNumber == toWithdraw.accountNumber)
                            {
                                if ( alpha.balance >= temp2)
                                {
                                    alpha.balance -= temp2;
                                    withdrawCompleted = true;
                                    stillWithdrawing = false;
                                }
                            }
                        }
                    }
                    else if (answer == "No")
                    {
                        stillWithdrawing = true;
                    }
                    else
                    {
                        basicFunctions.invalidInputEntered();
                    }

                    if (withdrawCompleted == true)
                    {
                        bool stillDisplaying = true;

                        account toDisplay = null;

                        foreach (account alpha in allAccounts)
                        {
                            if (alpha.accountNumber == toWithdraw.accountNumber)
                            {
                                toDisplay = alpha;
                            }
                        }

                        while (stillDisplaying)
                        {
                            Console.WriteLine("Withdraw Completed\n\n New Balance: " + toDisplay.balance);
                            Console.WriteLine("Enter 1 to Return to Main Menu");
                            int getCase = basicFunctions.getCase();

                            switch (getCase)
                            {
                                case 1:
                                    stillDisplaying = false;
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }
            }

            return true;
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

                int caseCheck = basicFunctions.getCase();

                switch ( caseCheck )
                {
                    
                    case 1:
                    {
                        bool stillAdding = true;
                        int type = 0; // 1 for Checking, 2 for Savings
                        UInt32 number = 0;
                        decimal startBal = 0m;
                        decimal startFIR = 0m;
                        customer Cust = null;

                        while ( stillAdding )
                        {
                        Console.Clear();

                            if ( number == 0)
                            {
                                bool acceptNumber = false;
                                Console.WriteLine("Please enter Account Number: ");
                                string temp = Console.ReadLine();
                                Console.WriteLine("You entered: " + temp + "\n Accept Account Number? (Yes or No)");
                                string answer = Console.ReadLine();
                                answer = basicFunctions.yesNoOrInvalid(answer);
                                    if ( answer == "Yes")
                                    {
                                        acceptNumber = true;
                                    }
                                    else if ( answer == "No")
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

                            if ( Cust == null )
                            {
                                Console.WriteLine("Please enter Customer Number: ");
                                string temp = Console.ReadLine();
                                Console.WriteLine("You entered: " + temp + "\n Accept Customer Number? (Yes or No)");
                                string answer = Console.ReadLine();
                                answer = basicFunctions.yesNoOrInvalid(answer);

                                    if ( answer == "Yes" )
                                    {
                                        UInt32 tnum;
                                        UInt32.TryParse(temp, out tnum );

                                        foreach (customer alpha in allCustomers)
                                        {
                                            if( alpha.customerNumber == tnum)
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
                                Console.WriteLine("You entered: " + temp + "\nCorrect starting balance? (Yes or No)");
                                string answer = Console.ReadLine();
                                answer = basicFunctions.yesNoOrInvalid(answer);

                                    if ( answer == "Yes" )
                                    {
                                        acceptBal = true;
                                    }
                                    else if ( answer == "No" )
                                    {
                                        acceptBal = false;
                                    }
                                    else
                                    {
                                        basicFunctions.invalidInputEntered();
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
                            answer = basicFunctions.yesNoOrInvalid(answer);

                                if ( answer == "Yes" )
                                {
                                    acceptType = true;
                                }
                                else if ( answer == "No" )
                                {
                                    acceptType = false;
                                }
                                else
                                {
                                    basicFunctions.invalidInputEntered();
                                }

                                if ( acceptType == true )
                                {
                                    Int32.TryParse(temp, out type);
                                }
                            }

                            if ( type == 2 )
                            {
                                    if ( startFIR == 0m )
                                {
                                    bool acceptFIR = false;
                                    Console.WriteLine("Would you like to use the default Fixed Interest Rate of 1.5%? (Yes to accept, No to set custom).");
                                    string answer = Console.ReadLine();
                                    answer = basicFunctions.yesNoOrInvalid(answer);
                                    if ( answer == "Yes")
                                    {
                                        acceptFIR = true;
                                        startFIR = 1.5m;
                                    }
                                    else if ( answer == "No")
                                    {
                                    Console.WriteLine("Enter a custom Fixed Interest Rate (Should be a number such as 1 or 1.5, do not include extraneous letters or symbols)");
                                    string temp = Console.ReadLine();
                                    Console.WriteLine("\nYou entered " + temp +"% Fixed Interest Rate, Accept? (Yes or No)");
                                    string answer2 = Console.ReadLine();
                                    answer2 = basicFunctions.yesNoOrInvalid(answer2);

                                        if ( answer2 == "Yes" )
                                        {
                                            acceptFIR = true;
                                        }
                                        else if ( answer == "No" )
                                        {
                                            acceptFIR = false;
                                        }
                                        else
                                        {
                                            basicFunctions.invalidInputEntered();
                                        }

                                        if ( acceptFIR == true )
                                        {
                                            decimal.TryParse(temp, out startFIR);
                                        }

                                    }
                                }
                            }

                            if ( number != 0 && Cust != null && type == 1 && startBal != 0m ) {
                                addAccount(ref Cust, ref allAccounts, number, startBal, ref allCustomers) ;
                                Console.WriteLine("\n\nNew Account Created!\n\n");
                                stillAdding = false;
                            }
                            else if ( number != 0 && Cust != null && type == 2 && startBal != 0m && startFIR != 0m )
                            {
                                addAccount(ref Cust, ref allAccounts, number, startBal, startFIR, ref allCustomers) ;
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
                        UInt32 number = 0; //account number not customer number
                        customer Cust = null;

                        while ( stillClosing )
                        {
                            bool acceptNumber = false;
                            
                            if (number == 0)
                            {
                            Console.WriteLine("Enter the Account Number for the account you wish to close.");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered: " + temp + " accept account number? (Yes or No)");
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

                            foreach (account alpha in allAccounts)
                            {
                                if ( alpha.accountNumber == number)
                                { 
                                    toBeClosed = alpha;
                                    Cust = alpha.owner;
                                }
                            }

                            Console.WriteLine("Account Number " + toBeClosed.accountNumber + " belongs to " + toBeClosed.owner.name + " , Customer Number: " + 
                            toBeClosed.owner.customerNumber + " Proceed to Close? (Yes or No)" );
                            string answer2 = Console.ReadLine();
                            answer2 = basicFunctions.yesNoOrInvalid(answer2);

                            if ( answer2 == "Yes")//imhere
                            {
                                closeAccount(ref allCustomers, Cust, toBeClosed, ref allAccounts) ; //closes the account
                                Console.WriteLine("\n\nAccount Closed Successfully.\n\n");
                                firstOperation = false;
                                stillClosing = false;
                            }
                            else if ( answer2 == "No" )
                            {
                                stillClosing = true;
                            }
                            else
                            {
                                basicFunctions.invalidInputEntered();
                            }
                        }

                        break;
                    }
                    case 3:
                    {
                        bool stillViewing = true;
                        account toBeViewed = null;
                        bool proceedToPrint = false;

                        while (stillViewing)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter an account number to print account information.");
                            string temp = Console.ReadLine();
                            Console.WriteLine("You entered " + temp + "\n Correct account number? (Yes or No)");
                            string answer = Console.ReadLine();
                            answer = basicFunctions.yesNoOrInvalid(answer);

                            if (answer == "Yes")
                            {
                                UInt32 temp2 = 0;
                                UInt32.TryParse(temp, out temp2);

                                foreach (account alpha in allAccounts)
                                {
                                    if (alpha.accountNumber == temp2)
                                    {
                                        toBeViewed = alpha;
                                        proceedToPrint = true;
                                    }
                                }
                            }
                            else if ( answer == "No")
                            {
                                proceedToPrint = false;
                            }
                            else
                            {
                                basicFunctions.invalidInputEntered();
                            }

                            if (proceedToPrint)
                            {
                                Console.WriteLine("Account Owner Name: " + toBeViewed.owner.name);
                                Console.WriteLine("Account Balance: " + toBeViewed.balance);
                                Console.WriteLine("Account Number: " + toBeViewed.accountNumber);

                                if (toBeViewed.type == 1)
                                {
                                    Console.WriteLine("Account Type: Checking");
                                }
                                else
                                {
                                    Console.WriteLine("Account Type: Savings");
                                    Console.WriteLine("Fixed Interest Rate: " + toBeViewed.fixedIntered);
                                }

                                Console.WriteLine("Enter 1 to Return to Main Menu.");
                                int getCase = basicFunctions.getCase();
                                switch (getCase)
                                {
                                    case 1:
                                        stillViewing = false;
                                        break;
                                    
                                    default:
                                        break;
                                }
                            }
                        }
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
                
                Console.WriteLine("~ Customer Maintenance ~\n\nWhat would you like to do?\n\n1 - Add new customer.\n2 - Delete a customer.\n3 - View or Edit customer details.\n4 - Return to Main Menu.");

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
                                Console.WriteLine("You entered: " + temp + "\n Accept Name? (Yes or No)");
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
                                Console.WriteLine("You entered: " + temp + "\n Accept Number? (Yes or No)");
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
                                Console.WriteLine("You entered: " + temp + "\n Accept? (Yes or No)");
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
                                Console.WriteLine("You entered: " + temp + "\n Accept Number? (Yes or No)");
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
                                foreach (customer alpha in allCustomers)
                                {
                                    if ( alpha.customerNumber == number )
                                    {
                                        if ( alpha.associatedAccounts.Count > 0)
                                        {
                                            Console.WriteLine("Sorry! This customer still has open account(s)! First close out the customer's accounts, then you can delete the customer.");
                                            stillDeleting = false;
                                        }
                                    }
                                }

                                if (stillDeleting == true)
                                {
                                    
                                        bool result = deleteCustomer(ref allCustomers, name, number);

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
                        }

                        firstOperation = false;

                        break;
                    }

                    case 3: //Complete
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
                                Console.WriteLine("You entered " + temp + " accept number? (Yes or No)");
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
                                                 " - View Customer Details.\n4 - Exit edit customer details.");
                            int getCase = basicFunctions.getCase();

                            switch (getCase)
                            {
                                case 1:
                                {
                                    Console.WriteLine("Enter a new Customer Name");
                                    string temp = Console.ReadLine();
                                    Console.WriteLine("You entered " + temp + ". Accept new Name? (Yes to Accept, else No)");
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
                                    Console.WriteLine("You entered " + temp + ". Accept new Number? (Yes to Accept, else No)");
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

                                    
                                    stillEditingCustomer = false;

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

        public static void branchInformation(ref List<account> allAccounts, ref List<customer> allCustomers){
            bool stillViewing = true;

            while (stillViewing)
            {
                     decimal totalFunds = 0m;
            int numOfCust = 0;

            Console.Clear();
            Console.WriteLine("Big Bank, Inc.\n\n");
            
            foreach (account alpha in allAccounts)
            {
                totalFunds += alpha.balance;
            }

            Console.WriteLine("Total Funds in Branch: " + totalFunds +"\n");

            foreach (customer alpha in allCustomers)
            {
                numOfCust += 1;
            }

            Console.WriteLine("Spread across " + numOfCust + " customers in " + allAccounts.Count + " accounts.");

            Console.WriteLine ("\n\nEnter 1 to Return to Main Menu.");

            int getCase = basicFunctions.getCase();

                switch (getCase)
                {
                    case 1:
                        stillViewing = false;
                        break;
                    default:
                        break;
                }
            }

        }

        public static void usageInstructions(){
            bool stillViewing = true;

            while(stillViewing)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Big Bank, Inc's productivity solution, developed to assist the branch agent in completing daily tasks.\n\n" +
                                  "To begin, start by creating customer(s) via the Customer Maintenance menu:\n");
                Console.WriteLine("To create a customer, you must assign them a Name and an Customer Number.\n" + 
                                  "Suggested values for names are either Full Legal Name, or First and Last names.\n\n" +
                                  "Suggested values for customer number are either:\nThe first available customer number following your branch's Customer Numbering conventions\nOr" +
                                  "\nFor your grading convenience *wink* chose an easy to remember number that corresponds to "+
                                  "\nthe name such as the first 6 digits of the persons phone number. e.g. 954555\n");
                Console.WriteLine("Once you have created customer(s) you can proceed to creating account(s) from the Account Maintenance menu.\n" + 
                                  "To create an account you will need to provide an Account Number:\n"
                                + "\nSuggested values for Account Numbers are the first available open account number per your branch's" +
                                  " account numbering conventions. \nOr\nAn easy to remember number for your grading convenience *wink* such as: 999001 " +
                                  "\n(the next account could be 999002, and so on).");
                Console.WriteLine("You will also need to provide the Customer Number for the owner of the new account," + 
                                  "\nas well as a starting balance, account type, and optionally a non standard Fixed Interest Rate for Savings Accounts.");

                Console.WriteLine("\nEnter 1 to return to Main Menu.\nAnd remember! Application data will not persist after exit.");
                int getCase = basicFunctions.getCase();

                switch (getCase)
                {
                    case 1:
                        stillViewing = false;
                        break;
                    default:
                        break;
                }
            }
        }
        // ///////////////////////////////////
        /*End of Main Menu Option Functions */
        // ///////////////////////////////////
        //
        //
        // ////////////////////
        /* Utility Functions */
        // ////////////////////
        static bool addCustomer(ref List<customer> allCustomers, string name, UInt32 number){//complete
            customer newCustomer = new customer(name, number);
            allCustomers.Add(newCustomer);
            return true;
        }

        static bool deleteCustomer(ref List<customer> allCustomers, string name, UInt32 number){//complete
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

        static bool addAccount ( ref customer cust, ref List<account> allAccounts, UInt32 number, decimal startBalance, ref List<customer> allCustomers ) {//complete add checking func

                account newAccount = new account( cust, startBalance, number );
                allAccounts.Add(newAccount);

                foreach (customer alpha in allCustomers)
                {
                    if (alpha == cust)
                    {
                        alpha.associatedAccounts.Add(number);
                    }
                }
            
            return true;
        }

        static bool addAccount ( ref customer cust, ref List<account> allAccounts, UInt32 number, decimal startBalance, decimal FIR, ref List<customer> allCustomers ) {//complete add saving func

                account newAccount = new account( cust, startBalance, number, FIR );
                allAccounts.Add(newAccount);

                foreach (customer alpha in allCustomers)
                {
                    if (alpha == cust)
                    {
                        alpha.associatedAccounts.Add(number);
                    }
                }
            
            return true;
        }

        static bool closeAccount (ref List<customer> allCustomers, customer owner, account toBeClosed, ref List<account> allAccounts ){//complete

            account temp = null;
            //customer ctemp = null;

            foreach (account alpha in allAccounts)
            {
               if (alpha.accountNumber == toBeClosed.accountNumber)
               {
                   temp = alpha;
                   //allAccounts.Remove(alpha); for some reason this doesnt work, but the one below does, i guess the one below is like 1 level removed from the error... though almost doing the same thing.
               }
            }

            foreach (customer alpha in allCustomers)
            {
                if (alpha.customerNumber == owner.customerNumber)
                {
                    //ctemp = alpha;
                    alpha.associatedAccounts.Remove(toBeClosed.accountNumber);
                }
            }

            allAccounts.Remove(temp);
            
            return true;
        }
    }
}