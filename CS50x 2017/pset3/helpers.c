/**
 * helpers.c
 *
 * Computer Science 50
 * Problem Set 3
 *
 * Helper functions for Problem Set 3.
 */
       
#include <cs50.h>
#include <math.h>
#include "helpers.h"

/**
 * Returns true if value is in array of n values, else false.
 *so this works but he challenged me to make it a recursive function
 * and its important to remember about log n that the value just gets cut in half each time, mathematically though
 * im not sure how to determine how many iterations that is, something i need to figure out. 
 */
bool search(int value, int values[], int n) //search algorith using binary search, return true if found, else false
{
int low = 0;
int high = n;
int numToCheck = 0;

    for (int i = 0, j = ((int) log2(n) + 2); i < j; i++)
    {
    numToCheck = (low + high) / 2;
        if (values[numToCheck] == value)
        {
            return true;
        }
        else 
        {
            if ( value > values[numToCheck])
            {
                low = numToCheck + 1;
            }
            else if (value < values[numToCheck])
            {
                high = numToCheck - 1;
            }
        }
    }

return false; 
}

/**
 * Sorts array of n values.
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
