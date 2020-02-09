using System;
using System.Collections.Generic;

namespace bigbank
{
    public class basicFunctions {
        public static int getCase() { //grab user input and parse to int32

            int caseCheck = 0;

            string userInput = Console.ReadLine(); // get user selection

            Int32.TryParse(userInput, out caseCheck); // parse the selection

            return caseCheck;

        }
    }
}