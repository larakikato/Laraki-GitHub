/**
 * helpers.c
 *
 * Computer Science 50
 * Problem Set 3
 *
 * Helper functions for Problem Set 3.
 */
       
#include <cs50.h>

#include "helpers.h"

/**
 * Returns true if value is in array of n values, else false.
 */
 
 /*
  search takes needle, haystack, and size
  return false if n isn't passed as a positive int
 */
bool search(int value, int values[], int n) //search algorith using linear search, return true if found, else false
{
    if ( ! (n >= 0 ))
    {
        return false;
    }
    
    for (int i = 0; i <= n; i++)
    {
        if (values[i] == value)
        {
            return true;
        }
    }
    return false;
}

/**
 * Sorts array of n values.
 */
 
 /*
 * find.c correctly passes array
 * sort from smallest to largest destructively, on the same array, which is passed by reference (same array as in main)
 *must be O(n^2)
 *can do bubble, select or insertion, or your own solution but it has to be O(n^2)
 *cant alter prototype or this functions parameters however
 *can define your own functions if you like
 */
void sort(int values[], int n)
{
    bool swap = false; 
    int tempInt = 0;
    
    for ( int i = 0; i < n; i++)
    {
    swap = false;
    
        for (int x = 0; x < n; x++)
        {
            if (values[x] > values[x + 1])
            {
                tempInt = values[x + 1];
                values[x+1] = values[x];
                values[x] = tempInt;
                swap = true;
            }
            else if ( x == n-1 && swap == false)
            {
                i = n+1; //break out of loop after confirming values are sorted
            }
        }
    }
    return;
}

/* Sort Working Notes:
it's grabbing the array and the size of the array
it's also saying in the documentation for the pset that arrays automatically get passed by reference so,
we shouldnt have to do anything at all in terms of using pointers or anything like that.

make a for loop to iterate through each value of the array, and check if it's larger or smaller than the value to it's right
if it's larger then swap, otherwise do nothing just go to the next value
if a swap is made after 1 pass through, add 1 to count (or u could make it true/false)

then do another pass through. 

u dont need to do more than n number of pass throughs. 
*/