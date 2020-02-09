using System;
using System.Collections.Generic;

namespace bigbank
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
                //Console.Clear();
                Console.WriteLine("Welcome to Big Bank, Inc.\n\nWhat would you like to do today?\n\n1 - Make a Deposit.\n2 - Make a Withdraw.\n3 - Account Maintenance." + 
                "\n4 - Customer Maintenance.\n5 - Branch Information.\n6 - Exit.");

                int caseCheck = basicFunctions.getCase(); //get the user input and parse it to int32

                Console.WriteLine(caseCheck);
            }
        }
    }
}
