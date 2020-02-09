#include <stdio.h>
#include <cs50.h>
#include <math.h>
#include <string.h>
#include <ctype.h>

char * initialized (string name); //prototype of function, implementation sourced from https://www.tutorialspoint.com/cprogramming/c_return_arrays_from_function.htm

int main (void)
{
char initials[1000];
string userName;
int spaceCounter = 0;
// Variables Declared

/* printf("Please enter your name: "); */  //this can be uncommented to prompt the user for input
userName = get_string();
// User input grabbed and assigned.

    for ( int i = 0, j = strlen(userName); i < j; i++)
    {
        if (userName[i] == ' ')
        {
            spaceCounter++;
        }
    } //number of spaces counted and stored
    
strncpy( initials, initialized(userName), (spaceCounter + 2)); //function implementation sourced from http://stackoverflow.com/questions/16645583/how-to-copy-char-array-to-another-char-array-in-c

printf("%s\n" , initials); //print out the initials
    
return 0;
}

char * initialized (string name) //function to select only first letters of each word (defined by spaces), save them to array, capitalize them and return the array
{
static char initials[1000]; //implementation sourced from https://www.tutorialspoint.com/cprogramming/c_return_arrays_from_function.htm
int initialCounter = 0;

    for ( int i = 0 , j = strlen(name); i < j; i++) //iterates through name to grab first letters of word and save to array
    {
        if ( i == 0 )
        {
            initials [i] = name[i];
            initialCounter++;
        }
        else if (name[i] == ' ')
        {
            initials[initialCounter] = name[i+1];
            initialCounter++;
        }
        else if (name[i] == '\0')
        {
            initials[initialCounter] = '\0';
        }
    } //initials saved into initials array
    
    for ( int i = 0; i < initialCounter; i++) //iterates through array to capitalize
    {
        if (initials[i] >= 'a' && initials[i] <= 'z')
        {
            initials[i] = (char) ((int)initials[i] - 32);
        }
    } //initials in array capitalized
    
return initials;
}


/* Working Notes:

-prototype Initialized function
-declare variables:1 string for user input, 1(2)char array for output, 1 int for space counter, 1 int for initialCounter
-grab user input and assign to string
-iterate through string to count spaces, adding to space counter the number of spaces.

-iterate through the string again, adding the first char to array, then the char after the first space,
and so on for every space, until end of string then add a \0 to the array. add 1 to initialcounter each time u add a char

-iterate through character in array and for each one
    if the character is capital, do nothing
    else if the character is lowercase, make it capital
    
    use printf to print char array as a string
*/