using System;
using System.Collections.Generic;
//using System.Linq;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("CS50xMiami C# Track \nAssignment: HW 1 \nStudent: Dylan Perez \nDate Submitted: May 10, 2017 \n");

            bool keepRunning = true;

            while ( keepRunning )
            {
                
                Console.WriteLine("Please enter a number (1-4) to see the student's implementation of the corresponding HW 1 task, or Enter 5 to Quit:");

                string userInput = Console.ReadLine();
                int caseCheck;

                Int32.TryParse(userInput, out caseCheck);//Implementation Sourced from: http://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input

                switch ( caseCheck )
                {
                    case 1:
                        question1();
                        break;

                    case 2:
                        question2();
                        break;

                    case 3:
                        question3();
                        break;

                    case 4:
                        question4();
                        break;

                    case 5:
                        keepRunning = false;
                        //Probably want an exit message here
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid question number entered (hint: HW 1 has questions numbered 1-4).\n"); 
                        break;
                }
            }
        }
        /* Begin Question Functions */
        static void question1 () {
            string x = "undefined";
            string y = "undefined";
            decimal xdec;
            decimal ydec;

            Console.Clear();
            Console.WriteLine("\n~Question 1~ \nPlease enter the length of a rectangle's sides to calculate its area:");
            while ( x == "undefined" || y == "undefined")
            {
                if( x == "undefined")
                {
                    Console.WriteLine("Enter a Value for x (or enter y to change y): ");
                    decimal tempDec;
                    string userInput = Console.ReadLine();
                    if ( userInput == "y" || userInput == "Y" ) 
                    {
                        y = "undefined";
                    }
                    else if (Decimal.TryParse(userInput, out tempDec)) 
                    {
                        xdec = tempDec;
                        x = tempDec.ToString();
                    }
                    Console.Clear();
                    Console.WriteLine("Current Dimensions: \n+-----+\n|     | y=" + y + " \n+-----+\n x="  + x);
                }

                if ( y == "undefined" )
                {
                    Console.WriteLine("Enter a Value for y (or enter x to change x): ");
                    decimal tempDec;
                    string userInput = Console.ReadLine();
                    if( userInput == "x" || userInput == "X" ) 
                    {
                        x = "undefined";
                    }
                    else if (Decimal.TryParse(userInput, out tempDec)) 
                    {
                        ydec = tempDec;
                        y = tempDec.ToString();
                    }
                    Console.Clear();
                    Console.WriteLine("Current Dimensions: \n+-----+\n|     | y=" + y + " \n+-----+\n x="  + x);
                }

                if ( x != "undefined" && y != "undefined" )
                {
                    ydec = Convert.ToDecimal(y);
                    xdec = Convert.ToDecimal(x);
                    string yes = "yes";
                    string no = "no";
                    Console.Clear();
                    Console.WriteLine("Current Dimensions: \n+-----+\n|     | y=" + y + " \n+-----+\n x="  + x + "\n");
                    Console.WriteLine("Confirm? Yes(proceed), No(Reset Dimensions), X(Reset x), Y(Reset y)\n");
                    string userInput = Console.ReadLine();
                    if (userInput == "x" || userInput == "X")
                    {
                        x = "undefined";
                    }
                    else if (userInput == "y" || userInput == "Y")
                    {
                        y = "undefined";
                    }
                    else if (string.Equals(userInput, yes, StringComparison.OrdinalIgnoreCase)) //Implementation Sourced From: http://stackoverflow.com/questions/3121957/how-can-i-do-a-case-insensitive-string-comparison
                    {
                        decimal z = calculateArea( xdec, ydec);
                        int length = z.ToString().Length;
                    /*  Time Constraints Force the Exclusion of the Following Functionality, reimplement when time grants (it was an attempt to make a dynamically sized ascii rectangle with the area in the center)
                        string topLine = "+";
                        string midLine = "|";
                        string botLine = "+";

                        //for (int i = 0; i < length; i++)
                        //{
                            topLine.PadRight(length, '-'); // "-";
                            midLine.PadRight(length, ' ');// += " ";
                            botLine.PadRight(length, '-');// += "-";

                           // if ( i == length )
                           // {
                                topLine.PadRight(1, '+');// += "+";
                                midLine.PadRight(1, '|'); //+= "|";
                                botLine.PadRight(1, '+'); //+= "+";
                           // }
                        //}
                    */
                        Console.Clear();
                        Console.WriteLine("Your rectangle has an area of: " + z);
                    }
                    else if (string.Equals(userInput, no, StringComparison.OrdinalIgnoreCase))
                    {
                        y = "undefined";
                        x = "undefined";
                    }
                    else
                    {
                        y = "undefined";
                        x = "undefined";
                    }
                }
            }
        }

        static void question2 () {
            string num = "undefined";
            int inum;
            int inputTries = 0;

            Console.Clear();
            Console.WriteLine("\n~Question 2~ \nPlease enter a positive integer to display the corresponding multiplication table:\n(Hint: For best results enter a number between 1 and 40, input must be below 10,000) ");

            while ( num == "undefined" )
            {
                num = Console.ReadLine();

                if ( !Int32.TryParse(num, out inum) )
                {
                    num = "undefined";
                    inputTries = inputTries+1;

                    if (inputTries >= 0 && inputTries <= 3 ) 
                    {
                        Console.WriteLine("Invalid input, Please enter an integer: ");

                    }
                    else if ( inputTries == 4 )
                    {
                        Console.WriteLine("Number may not have fractional, unknown, unsimplified, or variable components\n\n 1/2, .5, 5x, 5+1i, 3+5, "+
                                        "are all examples of invalid inputs.\n\n 3, 5, 7, and 155 are examples of acceptable input.\n\nEnter an integer: ");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Number may not have fractional, unknown, unsimplified, or variable components\n\n 1/2, .5, 5x, 5+1i, 3+5, "+
                                        "are all examples of invalid inputs.\n\n 3, 5, 7, and 155 are examples of acceptable input.\n\nEnter an integer: ");
                    }
                }
                else
                {
                    inum = Convert.ToInt32(num);
                    if (inum <= 10000)
                    {
                        if ( inum >= 0 && inum <= 40)
                        {
                        int rval = newMultiplicationTable(inum);
                        }
                        else if (inum <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You've entered 0 or a negative number, please enter a positive integer:");
                            num = "undefined";
                        }
                        else
                        {
                            Console.WriteLine("You've entered a value outside the ideal range. Are you sure you wish to Proceed?\n (Hint: Output may be misaligned, for best results pipe to 3rd party application)");
                            Console.WriteLine("Yes (Proceed), No (Go Back)");
                            string userConfirmation;
                            string yes = "Yes";
                            userConfirmation = Console.ReadLine();

                            if (string.Equals(userConfirmation, yes, StringComparison.OrdinalIgnoreCase))
                            {
                                int rval = newMultiplicationTable(inum);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n~Question 2~ \nPlease enter a positive integer to display the corresponding multiplication table:\n(Hint: For best results enter a number between 1 and 40, input must be below 10,000) ");
                                num = "undefined";
                            }
                        }
                    }
                    else
                    {
                        num = "undefined";
                    }
                }
            }
        }

        static void question3 () {
            List<int> collection = new List<int>();
            bool isDone = false;
            string yes = "Yes";
            int maximum;
            
            Console.Clear();
            Console.WriteLine("\n~Question 3~");

            while (!isDone)
            {
                Console.WriteLine("Enter any number of integers one at a time to find the largest value: \n(Hint: Enter Yes when done.)");
                string temp = Console.ReadLine();
                int itemp;

                if (string.Equals(temp, yes, StringComparison.OrdinalIgnoreCase))
                {
                    isDone = true;
                    maximum = max(collection);
                    Console.WriteLine("Largest integer in collection is: " + maximum);
                }
                else if (!int.TryParse(temp, out itemp))
                {
                    Console.WriteLine("\n!\nInvalid input, try again: \n!\n");
                }
                else
                {
                    int.TryParse(temp, out itemp);
                    collection.Add(itemp);
                }
            }
        }

        static void question4 () {
            bool isDone = false;
            string yes = "Yes";
            List<decimal> collection = new List<decimal>();
            List<decimal> newCollection;

            Console.Clear();
            Console.WriteLine("\n~Question 4~\n");
            Console.WriteLine("Enter salaries one at a time to increase each Salary in the list by 10%.");

            while (!isDone)
            {
                Console.WriteLine("Hint: Enter a Salary value such as: 43000 or 43000.50, do not include currency symbols ($).\n" + 
                        "When finished enter Yes to calculate new salaries.");

                string temp = Console.ReadLine();
                decimal dtemp;

                if (string.Equals(temp, yes, StringComparison.OrdinalIgnoreCase))
                {
                    isDone = true;
                    newCollection = payRaise(collection, out newCollection);
                    Console.WriteLine("Your increased Salaries are: ");
                    foreach ( decimal alpha in newCollection)
                    {
                        Console.WriteLine(alpha);
                    }
                }
                else if (!decimal.TryParse(temp, out dtemp))
                {
                    Console.WriteLine("\n!\nInvalid input, try again: \n!\n");
                }
                else
                {
                    decimal.TryParse(temp, out dtemp);
                    collection.Add(dtemp);
                }
            }

        }

        /* End Question Functions */
        //
        //
        /* Begin Utility Functions */

        static decimal calculateArea ( decimal x, decimal y) {

            decimal z = x * y;

            return z;

        }

        static int multiplicationTable ( int x ) { //Deprecated Function due to printing out epic upside down reverse mario staircases.
            int y = x;
            int z = 1;
            int whileCheck = 0;
            //char[] anyOf = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            string output = ""; // holds the final output

            int multiple = x * x; //used to calculate highest number of digits in output
            string digitsCheck = multiple.ToString();
            int idigits = digitsCheck.Length; //holds highest number of digits in output

            while( whileCheck <= x * x )
            {
            int curInt = y * z; //hold the multiplication of the current number
            string curStr = curInt.ToString(); //hold the string version
            int curLen = curStr.Length; //hold the length of the string version
            z++; //increment z
            whileCheck = curInt; //update whileCheck

            if (curLen < idigits )
            {
                int difference = idigits - curLen; //hold the difference between idigits and digits in curInt
                curStr = curStr.PadLeft(difference);
            }
                int outLen = output.Length;

                if ( outLen > 0)
                {
                    int startIndex = outLen - 1;
                    output = output.Insert(startIndex, curStr);
                }
                else
                {
                    output = output.Insert(0, curStr);
                }
                
            }

            Console.WriteLine(output);//Write the Output.
            
            if ( x == 0 ) 
            {
                return 0;
            }
            else
            {
                return multiplicationTable( x-1 );
            }
        }

        static int newMultiplicationTable( int x )
        {
            int highest = x * x; //highest number to print
            string highString = highest.ToString(); //string version of highest
            int idigits = highString.Length; //number of maximum digits in a number

            int y = x;
            string output = "";

            for (int i = 1; i <= y; i++) // each iteration should print a row.
            {
                for (int j = 1; j <= y; j++) //each iteration should update output.
                {
                    int curNum = i * j; //current multiple
                    string curStr = curNum.ToString();  //str version of current multiple
                    int curLen = curStr.Length; //length of the current multiple
                    int difference = idigits - curLen; //difference between highest length and current length

                    curStr = curStr.PadLeft(idigits); //not using difference right now, if this fails we need to look at this area again

                    output += curStr;
                    output += " ";
                }

                Console.WriteLine(output);
                output = "";
            }

            return 0;
        }

        static int max(List<int> collection)
        {
            
            //var temp = collection;
            //rval = temp.Max(); well i would just do this, but i think that possibly goes against the idea of the question so.... here we go.

            int temp;
            collection.Sort();
            int highestSoFar = collection[0];
            int index = 0;
            int lastIndex = collection.Count;
            lastIndex = lastIndex - 1;
            
            foreach( int alpha in collection )
            {
                temp = alpha;
                
                if ( index < lastIndex )
                {
                    if ( collection[index+1] > temp )
                    {
                        highestSoFar = collection[index+1];
                    }
                }
                if ( index == lastIndex )
                {
                    if (alpha > highestSoFar)
                    {
                        highestSoFar = alpha;
                    }
                }

                index++;
            }

            return highestSoFar;
        }

        static List<decimal> payRaise (List<decimal> collection , out List<decimal> newSalaries)
        {
            newSalaries = new List<decimal>();

            foreach ( decimal alpha in collection)
            {
                decimal newAlpha;
                decimal increasedBy;
                increasedBy = decimal.Multiply(alpha, .1m);
                newAlpha = alpha + increasedBy;

                newSalaries.Add(newAlpha);
            }

         return newSalaries;   
        }
    }
}
