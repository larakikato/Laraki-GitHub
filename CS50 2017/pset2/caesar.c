#include <stdio.h>
#include <cs50.h>
#include <ctype.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>

int main (int argc, string argv[])
{
string message;
int key = 0;
//variables declared

    if (argc == 2)
    {
    key = atoi(argv[1]);
    }
    else 
    {
        printf("Improper arguments passed at command line.");
        return 1;
    } //ensure argc is valid
    
    if ( key < 0)
    {
        printf("Cipher key should be greater than or equal to zero.");
        return 1;
    } //ensure negative key not entered
    
key = (key % 26); //shrinks keys larger than 26
// printf("Please enter a message to cipher: "); //uncomment to prompt for user input
message = get_string(); //save to string

    for (int i = 0, j = strlen(message); i < j; i++ ) //begin cipher loop
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
                if ( (message[i] >= 'A' && message[i] <= 'Z') && 
                ! (((int)message[i] + key) >= 65 && ((int)message[i] + key) <= 90)) //looping logic implementation sourced from http://stackoverflow.com/questions/11837292/how-to-write-a-number-range-in-c-for-a-condition
                {
                    message[i] = (char) ((int)message[i] - (26 - key)); // handles wrap around for A-Z
                }
                else if ( (message[i] >= 'a' && message[i] <= 'z') && 
                ! (((int)message[i] + key) >= 97 && ((int)message[i] + key) <= 122)) 
                {
                    message[i] = (char) ((int)message[i] - (26 - key)); // handles wrap around for a-z
                }
                else
                {
                message[i] = (char) ((int)message[i] + key); //default cipher, no wrap around needed
                }
        }
    } //end cipher loop

printf("%s\n", message); // print ciphered text

return 0;
}
/*Author's Notes:

After initially drafting the code I was having an issue whereby I would get many invalid symbols printed out 
due to improperly handling wrap around, upon contemplation I decided the solution was to:

if the int casted value of the char to be ciphered + the int value of the key is greater
than the highest value in range (z for example if lower case), or lower than the lowest value (a)
then rather than char + key, the char is replaced by char minus 26 minus the key

*/