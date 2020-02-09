#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "bmp.h"

int main(int argc, char* argv[])
{
        /******************************
        **Command Line Arguments Start**
        *******************************/
        if (argc != 4)
        {
            printf("Usage: ./copy multiplier infile outfile\n");
            return 1;
        }
        
        // remember filenames
        char* infile = argv[2];
        char* outfile = argv[3];
        int n = atoi(argv[1]);
        
        // open input file 
        FILE* inptr = fopen(infile, "r");
        if (inptr == NULL)
        {
        printf("Could not open %s.\n", infile);
        return 2;
        }
        
        // open output file
        FILE* outptr = fopen(outfile, "w");
        if (outptr == NULL)
        {
        fclose(inptr);
        fprintf(stderr, "Could not create %s.\n", outfile);
        return 3;
        }
        /***End Command Line Argument Code***/
            
            /**********************************
                *Header Objects Creation* 
            ***********************************/
            // read infile's BITMAPFILEHEADER
            BITMAPFILEHEADER bf;
            fread(&bf, sizeof(BITMAPFILEHEADER), 1, inptr);
            //new fileheader struct object to assign converted values. 
            BITMAPFILEHEADER newbf;
            //convert and assign the new values below by accessing members
            newbf.bfSize = (((bf.bfSize - 54 )* n) * (n - 1)) + 54; //Think n-1 may actually have something to do with width or padding value need to change.
            newbf.bfType = bf.bfType;
            newbf.bfReserved1 = bf.bfReserved1;
            newbf.bfReserved2 = bf.bfReserved2;
            newbf.bfOffBits = bf.bfOffBits;
            
            // read infile's BITMAPINFOHEADER
            BITMAPINFOHEADER bi;
            fread(&bi, sizeof(BITMAPINFOHEADER), 1, inptr);
            // new infoheader object to assign converted values
            BITMAPINFOHEADER newbi;
            //convert and assign the new values below by accessing members
            newbi.biSize = bi.biSize;
            newbi.biWidth = bi.biWidth * n;
            newbi.biHeight = bi.biHeight * n;
            newbi.biPlanes = bi.biPlanes;
            newbi.biBitCount = bi.biBitCount;
            newbi.biCompression = bi.biCompression;
            newbi.biSizeImage = bi.biSizeImage; //so right around here I stopped trying to convert them and just assume they are the same
            newbi.biXPelsPerMeter = bi.biXPelsPerMeter;
            newbi.biYPelsPerMeter = bi.biYPelsPerMeter;
            newbi.biClrUsed = bi.biClrUsed;
            newbi.biClrImportant = bi.biClrImportant;
            
            /*** End Header Objects Section ***/
            
                // ensure infile is (likely) a 24-bit uncompressed BMP 4.0
                if (bf.bfType != 0x4d42 || bf.bfOffBits != 54 || bi.biSize != 40 || 
                    bi.biBitCount != 24 || bi.biCompression != 0)
                {
                fclose(outptr);
                fclose(inptr);
                fprintf(stderr, "Unsupported file format.\n");
                return 4;
                }
                
        // write outfile's BITMAPFILEHEADER
        fwrite(&newbf, sizeof(BITMAPFILEHEADER), 1, outptr);
        // write outfile's BITMAPINFOHEADER
        fwrite(&newbi, sizeof(BITMAPINFOHEADER), 1, outptr);

//Variables for Resizing Logic
RGBTRIPLE scannedLine[(bi.biWidth)];
RGBTRIPLE writtenLine[(newbi.biWidth)];

// determine padding for old scanlines
int oldPadding = (4 - (bi.biWidth * sizeof(RGBTRIPLE)) % 4) % 4;
// determine padding for new scanlines
int padding =  (4 - (newbi.biWidth * sizeof(RGBTRIPLE)) % 4) % 4; // 3 for small.bmp pads to the closes multiple of 4, width = 3 x 3triple = 9 closes is 12, thus 3


    //Loop to Iterate over infile scannedLines and copy one at a time to writtenLine, skipping padding after each iteration.
    for (int a = 0, biHeight = abs(bi.biHeight); a < biHeight; a++)
    {
        int scanToWritCnt = 0;
        //iterate over pixels in scanline
        for (int b = 0; b < bi.biWidth; b++)
        {
        RGBTRIPLE triple;
        
        // read RGB triple from infile
        fread(&triple, sizeof(RGBTRIPLE), 1, inptr);
        
        //assign each triple to scannedLine, building the line
        scannedLine[b] = triple;
        
        }
        // skip over padding, if any
        fseek(inptr, oldPadding, SEEK_CUR);
        
        //begin writing scannedLine to writtenLine
        for (int d = 0; d < bi.biWidth; d++)
        {
            //copy current scannedLine triple to writtenLine n times and increment placeholder
            for (int e = 0; e < n; e++, scanToWritCnt++)
            {
                writtenLine[scanToWritCnt] = scannedLine[d];
            }
        }
        
        //loop to write writtenLine n times
        for (int g = 0; g < n; g++)
        {
            //write writtenLine to outptr
            fwrite(&writtenLine, sizeof(writtenLine), 1, outptr);
            //add padding to outfile
            for (int f = 0; f < padding; f++)
            {
            fputc(0x00, outptr);
            }
        }
    }

    // close infile
    fclose(inptr);

    // close outfile
    fclose(outptr);

    // that's all folks
    return 0;

} //This brace ends main.

/* Working Notes:
*Read triple from in and assign to scanline n times until end of line is reached, skip padding.
*for x < n write scanline to out and add padding
*
*
*
*/