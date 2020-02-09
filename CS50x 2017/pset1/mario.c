#include <stdio.h>
#include <cs50.h>

int main (void)
{
    int height, temporaryHeight, x; //create variables for user input and for program logic
    height = -1; // initialize height to an non-user enterable value
    x = 0; // x is a variable that's going to be used to print out hashes in it's amount, which are any hashes on a row more than 2, first row requires 2 hash, thus init to 0
    
    while (height == -1) //program body loop
    {
    printf("Enter the height of Mario's pyramid, but remember, Mario can't climb more than 23 stairs, or less than 0:\n"); //prompt user for input
    temporaryHeight = get_int(); //grab the potential height value from user
   
        if (temporaryHeight >= 0 && temporaryHeight <= 23) //check potential height value for compliance to rules
        {
        height = temporaryHeight; // assign checked height value to correct variable
            while (height > 0 && height != 100) //loop handles printing indidivual rows, until the value of height reaches 0 indicating completion
            {
                for (int i = height-1; i > 0; i--) //loop handles printing spaces
                {
                    printf(" ");
                }
                printf("##");  //statement handles ensuring the last two columns are the same height
                for (int j = x; j > 0; j--) //statement handles printing hashes for each row in excess of 2
                {
                    printf("#");
                }
            x=x+1; //statement allows x to iterate along with each row
            printf("\n"); //statement allows each row to begin on a new line 
            height = height-1; //statement ensures the while loop iterates the correct number of times
            }
        temporaryHeight = 100; //failsafe against programmer error :D
        height = 100;  //allows break from body loop
        }
        else 
        {
        height = -1; //allows program body to loop if given invalid input
        temporaryHeight = -1; //failsafe against programmer error :D
        } 
    }

}

/* Working Notes:

initially i thought each line needs to print out height+1 hashes... 
it seems each line actually needs to print out height-1 spaces then 2 hashes then x hashes
where x starts at 0 and iterates up one each time

it needs to do this for height number of iterations.
*/