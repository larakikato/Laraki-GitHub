#include <stdio.h>
#include <cs50.h>
#include <math.h>

int main (void) 
{
float userInput, currChange; 
int coinTally;
// create variables 

    do 
    {
    printf("Please enter the amount of change owed: \n");
    userInput = get_float();    
    }
    while (userInput < 0.0);
    // grab user input
    
currChange = userInput * 100.0; //work with "cents"
currChange = roundf(currChange); //Implementation sourced from http://en.cppreference.com/w/c/numeric/math/round

    for (coinTally = 0; currChange > 0.0; coinTally++ ) //the idea of this loop is for each iteration, it will find the biggest coin, subtract it, and add 1 to coin count.
    {
        if (currChange >= 25.0)
        {
            currChange = currChange - 25.0;
        }
        else if (currChange >= 10.0)
        {
            currChange = currChange - 10.0;
        }
        else if (currChange >= 5.0)
        {
            currChange = currChange - 5.0;
        }
        else if (currChange >= 1.0)
        {
            currChange = currChange - 1.0;
        }
    }

printf("%i\n", coinTally); // display output
}

/* Working Notes:

It's important to remember that our coin variables are of type int, and change amounts will be entered in floats.

Also the final output needs to be a float simply denoting coin amount necessary for transaction.

Alright, so I think i have a good base here, the problem is that my outputs are not the correct numbers
theres a few reasons i can think of why that might be:

multiplying float x 100 is not sufficient as a method to convert to cents
or
for some reason my loop logic is not iterating as designed

and ultimately the cause was the second of those two reasons, I had neglected to put >= in most of my for loops, having just > which made many cases loop additional times.


*/