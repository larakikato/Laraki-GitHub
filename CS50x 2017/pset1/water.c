#include <stdio.h>
#include <cs50.h>

int main (void) 
{
    int minutes, bottles; //create variables for user input and for program output.
    printf("Please enter the length of your shower in minutes: \n"); //prompt user for input
    minutes = get_int(); //grab input
    bottles = (minutes * 192) / 16; //convert minutes to bottles
    printf("Your water usage this shower was equivalent to %i 16oz bottles.\n", bottles); //display output
}