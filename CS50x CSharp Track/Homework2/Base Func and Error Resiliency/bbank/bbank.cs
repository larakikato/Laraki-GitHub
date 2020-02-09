//CS50xMiami C# Track 
//Assignment: HW 2
//Student: Dylan Perez 
//Date Submitted: May 17, 2017

using System;
using System.Collections.Generic;

namespace bbank
{
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
                Console.WriteLine("Welcome to Big Bank, Inc.\n\nWhat would you like to do?\n\n1 - Make a Deposit.\n2 - Make a Withdraw.\n3 - Account Maintenance." + 
                "\n4 - Customer Maintenance.\n5 - Branch Information.\n6 - Usage Instructions.\n7 - Exit.");

                int caseCheck = basicFunctions.getCase(); //get the user input and parse it to int32

                switch ( caseCheck )
                {
                    case 1:
                        bankFunctions.deposit( ref allCustomers, ref allAccounts );
                        break;

                    case 2:
                        bankFunctions.withdraw( ref allCustomers, ref allAccounts );
                        break;

                    case 3:
                        bankFunctions.accountMaintenance( ref allCustomers, ref allAccounts);
                        break;

                    case 4:
                        bankFunctions.customerMaintenance(ref allCustomers);
                        break;

                    case 5:
                        bankFunctions.branchInformation(ref allAccounts, ref allCustomers);
                        break;
                    
                    case 6:
                        bankFunctions.usageInstructions();
                        break;
                    
                    case 7:
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
    }
}
