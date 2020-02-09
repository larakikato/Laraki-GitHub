#include <stdio.h>
#include <cs50.h>
#include <ctype.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>

int main (int argc, string argv[])
{
string message;
string key;
int ki = 0; //variable to iterate through the key string
int tempKey = 0; //a variable to hold a shrunken value for each key character if necessary
//variables declared

    if (argc == 2)
    {
    key = argv[1];
    }
    else 
    {
        printf("Improper arguments passed at command line.");
        return 1;
    } //ensure argc is valid
    
    for ( int i = 0, j = strlen(key); i < j; i++)
    {
        if ( ! isalpha(key[i]) )
        {
        printf("Cipher key should only contain letters.");
        return 1;
        } //ensure key conforms to rules
    }

//printf("Please enter a message to be enciphered: "); //uncomment to prompt user for a message
message = get_string(); //grab input

    for (int i = 0, j = strlen(message); i < j; i++)
    {
        switch ((int)message[i])
        {
            case 0 ... 64: // implementation sourced from http://stackoverflow.com/questions/36748934/how-can-i-use-ranges-in-a-switch-case-statement-in-c
                break;
            case 91 ... 96:
                break;
            case 123 ... 127:
                break;
            case 128 ... 255:
                break;
            //cases to this point take no action for non a-z, A-Z characters
            
            default:
            
            tempKey = (int)key[(ki % strlen(key))]; //assigns int casted char value to temp key, correcting for wraparound on key string
            if (tempKey >= 65 && tempKey <= 90) //statement chain to handle correction of int casted char value to alphabetical order of precedence value A and a both = 0, b and B both = 1, etc.
            {
            tempKey = tempKey - 65;
            }
            else if (tempKey >= 97 && tempKey <= 122)
            {
            tempKey = tempKey - 97;
            }
            else
            {
            printf("Fatal Exception: \n Temporary Key Value is %i \n", tempKey); //error message for debugging
            return 1;
            } // end of value corrections
            
            tempKey = tempKey % 26; // shrinks the value of temp key
            
                if ( (message[i] >= 'A' && message[i] <= 'Z') && 
                ! (((int)message[i] + tempKey) >= 65 && ((int)message[i] + tempKey) <= 90)) //looping logic implementation sourced from http://stackoverflow.com/questions/11837292/how-to-write-a-number-range-in-c-for-a-condition
                {
                message[i] = (char) ((int)message[i] - (26 - tempKey)); // handles wrap around for A-Z
                ki++;
                }
                else if ( (message[i] >= 'a' && message[i] <= 'z') && 
                ! (((int)message[i] + tempKey) >= 97 && ((int)message[i] + tempKey) <= 122)) 
                {
                message[i] = (char) ((int)message[i] - (26 - tempKey)); // handles wrap around for a-z
                ki++;
                }
                else
                {
                message[i] = (char) ((int)message[i] + tempKey); //default cipher, no wrap around needed
                ki++;
                }
        }
    } //end cipher loop

printf("%s\n", message); // print ciphered text

return 0;
}

/*Working Notes:
Alright so, the goal here is basically just like caesar, except, instead of one key, we're going to grab a string from the user at execution
each character in that string is going to be a key

we're going to use those character keys, one at a time, on each character in the message,
incrementing to the next key character only when a letter gets ciphered,
for spaces and the like, we will take no action in terms of incrementing the key, but we will 
still increment to the next character of the message and make comparisons again.
*/