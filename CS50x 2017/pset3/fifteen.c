/**
 * fifteen.c
 *
 * Computer Science 50
 * Problem Set 3
 *
 * Implements Game of Fifteen (generalized to d x d).
 *
 * Usage: fifteen d
 *
 * whereby the board's dimensions are to be d x d,
 * where d must be in [DIM_MIN,DIM_MAX]
 *
 * Note that usleep is obsolete, but it offers more granularity than
 * sleep and is simpler to use than nanosleep; `man usleep` for more.
 */
 
#define _XOPEN_SOURCE 500

#include <cs50.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

// constants
#define DIM_MIN 3
#define DIM_MAX 9
#define EMPTY_SPACE 2500176

// board
int board[DIM_MAX][DIM_MAX];

// dimensions
int d;

//variables to keep track of user selection and location of empty space
int userSelectionRow = 999999;
int userSelectionColumn = 999999;
int emptySpaceRow;
int emptySpaceColumn;

// prototypes
void clear(void);
void greet(void);
void init(void);
void draw(void);
bool move(int tile);
bool won(void);

int main(int argc, string argv[])
{
    // ensure proper usage
    if (argc != 2)
    {
        printf("Usage: fifteen d\n");
        return 1;
    }

    // ensure valid dimensions
    d = atoi(argv[1]);
    if (d < DIM_MIN || d > DIM_MAX)
    {
        printf("Board must be between %i x %i and %i x %i, inclusive.\n",
            DIM_MIN, DIM_MIN, DIM_MAX, DIM_MAX);
        return 2;
    }

    // open log
    FILE* file = fopen("log.txt", "w");
    if (file == NULL)
    {
        return 3;
    }

    // greet user with instructions
    greet();

    // initialize the board
    init();

    // accept moves until game is won
    while (true)
    {
        // clear the screen
        clear();

        // draw the current state of the board
        draw();

        // log the current state of the board (for testing)
        for (int i = 0; i < d; i++)
        {
            for (int j = 0; j < d; j++)
            {
                fprintf(file, "%i", board[i][j]);
                if (j < d - 1)
                {
                    fprintf(file, "|");
                }
            }
            fprintf(file, "\n");
        }
        fflush(file);

        // check for win
        if (won())
        {
            printf("ftw!\n");
            break;
        }

        // prompt for move
        printf("Tile to move: ");
        int tile = GetInt();
        
        // quit if user inputs 0 (for testing)
        if (tile == 0)
        {
            break;
        }

        // log move (for testing)
        fprintf(file, "%i\n", tile);
        fflush(file);

        // move if possible, else report illegality
        if (!move(tile))
        {
            printf("\nIllegal move.\n");
            usleep(500000);
        }

        // sleep thread for animation's sake
        usleep(150000);
    }
    
    // close log
    fclose(file);

    // success
    return 0;
}

/**
 * Clears screen using ANSI escape sequences.
 */
void clear(void)
{
    printf("\033[2J");
    printf("\033[%d;%dH", 0, 0);
}

/**
 * Greets player.
 */
void greet(void)
{
    clear();
    printf("WELCOME TO GAME OF FIFTEEN\n");
    usleep(2000000);
}

/**
 * Initializes the game's board with tiles numbered 1 through d*d - 1
 * (i.e., fills 2D array with values but does not actually print them).  
 */
void init(void)
{
int currentPiece = d * d - 1;
int caseCheck = d % 2;
emptySpaceRow = d - 1;
emptySpaceColumn = d - 1;
    // for the value NUMOFPIECES, fill board from 1-NUMOFPIECES from top left to bottom right,
    // ensure the bottom right space uses EMPTYSPACE
    // ensure the position of 1 and 2 are swapped if the value of d is odd. 
    switch (caseCheck)
    {
        case 0: //odd number of spaces
        
            for ( int r = 0, j = d - 1; r <= j; r++ ) //runs once for each row
            {
                for ( int c = 0, k = d - 1; c <= k; c++) //runs once for each space in each row (column)
                {
                    board[r][c] = currentPiece;
                    currentPiece--;
                }
            }
            
            board[ d - 1 ][ d - 1 ] = EMPTY_SPACE;
            board[ d - 1 ][ d - 2 ] = 2;
            board[ d - 1 ][ d - 3 ] = 1;
            break;
            
        case 1: //even number of spaces
        
            for ( int r = 0, j = d - 1; r <= j; r++ ) //runs once for each row
            {
                for ( int c = 0, k = d - 1; c <= k; c++) //runs once for each space in each row (column)
                {
                    board[r][c] = currentPiece;
                    currentPiece--;
                }
            }
            board[ d - 1 ][ d - 1 ] = EMPTY_SPACE;
            break;
    }

}

/**
 * Prints the board in its current state.
 */
void draw(void)
{
        for (int i = 0; i < d; i++)  //implementation of this loop taken directly from main's logging functionality.
        {
            for (int j = 0; j < d; j++)
            {
                /*
                printf("\033[2J");
                printf("\033[%d;%dH", 0, 0);
                */
                if (board[i][j] == EMPTY_SPACE)
                {
                printf("\033[40;34;04m  \033[0m");
                }
                else if (board[i][j] < 10)
                {
                // printf(" %i", board[i][j]);
                printf("\033[40;34;04m %i\033[0m", board[i][j]);
                }
                else 
                printf("\033[40;34;04m%i\033[0m", board[i][j]);
                if (j < d - 1)
                {
                    printf("\033[40;34;04m|\033[0m");
                }
            }
            printf("\n");
        }
}

/**
 * If tile borders empty space, moves tile and returns true, else
 * returns false. 
 */
bool move(int tile)
{
userSelectionRow = 999999;
userSelectionColumn = 999999;
int checkEm1Row;
int checkEm1Column;
int checkEm2Row;
int checkEm2Column;
int checkEm3Row;
int checkEm3Column;
int checkEm4Row;
int checkEm4Column;

    if (tile != 0)
    {
        for (int i = 0; i < d; i++ )
        {
            for (int j = 0; j < d; j++) 
            {
                if (board[i][j] == tile)
                {
                    userSelectionRow = i;
                    userSelectionColumn = j;
                    break;
                }
            }
        }
    }
    if ( userSelectionRow == 999999 || userSelectionColumn == 999999 )
    {
    printf("\nInvalid tile.\n");
    usleep(500000);
    return false;
    }
                
    if (userSelectionColumn + 1 == d)
    {
            checkEm1Column = 999;
            checkEm1Row = 999;
    }    
    else 
    {
            checkEm1Column = userSelectionColumn+1;
            checkEm1Row = userSelectionRow;
    }
    
    switch (userSelectionColumn - 1)
    {
        case -1:
            checkEm2Column = 999;
            checkEm2Row = 999;
            break;
        
        default:
            checkEm2Column = userSelectionColumn - 1;
            checkEm2Row = userSelectionRow;
            break;
    }
    
    if (userSelectionRow + 1 == d)
    {
            checkEm3Row = 999;
            checkEm3Column = 999;
    }
    else
    {
            checkEm3Row = userSelectionRow + 1;
            checkEm3Column = userSelectionColumn;
    }
    
    switch (userSelectionRow - 1)
    {
        case -1:
            checkEm4Row = 999;
            checkEm4Column = 999;
            break;
        default:
            checkEm4Row = userSelectionRow - 1;
            checkEm4Column = userSelectionColumn;
            break;
    }
    
    if (checkEm1Row == 999 || checkEm1Column == 999)
    {
        
    }
    
    else 
    {
        if (board[checkEm1Row][checkEm1Column] == EMPTY_SPACE)
        {
            board[checkEm1Row][checkEm1Column] = tile;
            board[userSelectionRow][userSelectionColumn] = EMPTY_SPACE;
            return true;
        }
    }
    
    if (checkEm2Row == 999 || checkEm2Column == 999)
    {
        
    }
    
    else
    {
        if (board[checkEm2Row][checkEm2Column] == EMPTY_SPACE)
        {
            board[checkEm2Row][checkEm2Column] = tile;
            board[userSelectionRow][userSelectionColumn] = EMPTY_SPACE;
            return true;
        }
    }
    
    if (checkEm3Row == 999 || checkEm3Column == 999)
    {
    
    }
    
    else 
    {
        if (board[checkEm3Row][checkEm3Column] == EMPTY_SPACE)
        {
            board[checkEm3Row][checkEm3Column] = tile;
            board[userSelectionRow][userSelectionColumn] = EMPTY_SPACE;
            return true;
        }
    }
    
    if (checkEm4Row == 999 || checkEm4Column == 999)
    {
        
    }
    
    else 
    {
        if (board[checkEm4Row][checkEm4Column] == EMPTY_SPACE)
        {
            board[checkEm4Row][checkEm4Column] = tile;
            board[userSelectionRow][userSelectionColumn] = EMPTY_SPACE;
            return true;
        }
    }
    
    return false;
}

/**
 * Returns true if game is won (i.e., board is in winning configuration), 
 * else false.
 */
bool won(void)
{
int checkEachPiece = 1;

    for (int i = 0; i < d; ++i)
    {
        for (int j = 0; j < d; ++j)
        {
            if (board[i][j] == checkEachPiece)
            {
                checkEachPiece++;
            }
            else if (checkEachPiece == d * d - 1)
            {
                break;
            }
            else
            {
                break;
            }
        }
    }
    if ((checkEachPiece >= d * d - 1) && (board[d - 1][d - 1] == EMPTY_SPACE))
    {
        return true;
    }
    return false;
}