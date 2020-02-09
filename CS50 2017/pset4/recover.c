#include <stdio.h>
#include <cs50.h>
#include <stdlib.h>
#include <string.h>
#include <stdint.h>

int main(void)
{
    //Define a type for Byte
    typedef uint8_t BYTE;
    
    //Define a struct type to hold 512 BYTEs
    typedef struct {
    BYTE B[512];
    }__attribute__((__packed__))
    BLOCK;
    
    //Define a struct to count the file names
    typedef struct {
    int a;
    int b;
    int c;
    }jpgCounter;
    
    //Open Memory Card for Reading as Binary
    FILE *card = fopen("card.raw", "rb");
    if (card == NULL)
    {
    printf("Could not open card.");
    return 2;
    }

    //Create FILE pointer for Output
    FILE *fout = NULL; //init to null so I can check against that
    
    //Declare Variable of BLOCK type to hold the current block
    BLOCK *currBlock = malloc(sizeof(BLOCK));

    //Declare string to hold name for current jpg
    string currFileName = malloc(sizeof(char*));
    
    //Declare and Initialize variable of type jpgCounter
    jpgCounter jpgCount;
    jpgCount.c = -1;
    jpgCount.b = 0;
    jpgCount.a = 0;
    
    //Loop to read blocks into our current block
    while ((void*)fread(currBlock->B, sizeof(BYTE), 512, card) != NULL ) //read 1 block into currBlock.B;
        {
        
        if ( ((int) currBlock->B[0] == 255) //Check to see if currBlock holds the start of a jpg
           && ((int) currBlock->B[1] == 216) 
           && ((int) currBlock->B[2] == 255) 
           && ((int) currBlock->B[3] >= 224 
           && currBlock->B[3] <= 239) )
        {
            if ( fout != NULL ) //if fout not null
            {
                fclose(fout);
            }
            
            if (jpgCount.c == 9)//iterate the file name, should work up to or past 999
            {
                jpgCount.b++;
                if (jpgCount.b == 10)
                {
                    jpgCount.a++;
                    jpgCount.b = 0;
                }
                jpgCount.c = 0;
            }
            else 
            jpgCount.c++;
        
        //name and create new file
        sprintf(currFileName, "%d%d%d.jpg", jpgCount.a, jpgCount.b, jpgCount.c);
        fout = fopen(currFileName, "wb");
            if (fout == NULL)//Or print an error if file cannot be created
            {
            printf("Could not create a new .jpg! Is storage device full?");
            return 3;
            }
        }
        
        if (fout != NULL) //write to the .jpg provided one is open
        {
        fwrite(currBlock->B, sizeof(BYTE), 512, fout);
        }

    }
    

/**********************
 ** Cleanup Section **
**********************/

if (feof(card) != 0 ) //Close the Input File provided end of file reached
{
fclose(card);
}

fclose(fout); //Close the last output file

free(currBlock); //free the current block pointer

free(currFileName); //free the currFileName string

return 0;
}

/*Working Notes:

*/
