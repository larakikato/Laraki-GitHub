using System;

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
                }
            }
        }

        static void question2 () {

        }

        static void question3 () {

        }

        static void question4 () {

        }

        /* End Question Functions */
        //
        //
        /* Begin Utility Functions */

        static decimal calculateArea ( decimal x, decimal y) {

            decimal z = x * y;

            return z;

        }
    }
}
