/**
 * copy.c
 *
 * Computer Science 50
 * Problem Set 4
 *
 * Copies a BMP piece by piece, just because.
 */
       
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "bmp.h"

int main(int argc, char* argv[])
{
    // ensure proper usage
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

    // read infile's BITMAPFILEHEADER
    BITMAPFILEHEADER bf;
    fread(&bf, sizeof(BITMAPFILEHEADER), 1, inptr);
    
    //new fileheader struct object to assign converted values. 
    BITMAPFILEHEADER newbf;
    //convert and assign the new values below by accessing members
    newbf.bfSize = (((bf.bfSize - 54 )* n) * (n - 1)) + 54; //need to figure out where that n-1 comes from, i think its really something else. possibly something to do with hiWidth or Height or the padding
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

    // determine padding for scanlines
    int padding =  (4 - (newbi.biWidth * sizeof(RGBTRIPLE)) % 4) % 4; // 3 for small.bmp pads to the closes multiple of 4, width = 3 x 3triple = 9 closes is 12, thus 3
    
    
    
    //below is not fully implemented
    // iterate over infile's scanlines
    for (int i = 0, biHeight = abs(newbi.biHeight); i < biHeight; i++)
    {
        // iterate over pixels in scanline
        for (int j = 0; j < newbi.biWidth; j++)
        {
            // temporary storage
            RGBTRIPLE triple;
            RGBTRIPLE scanLine[(newbi.biWidth)];
            int scanIfSeekOffSet = newbi.biWidth * sizeof(RGBTRIPLE) + padding;
            //int scanLineCount = 0;
            //probably for the first pass through we can just use a for loop based on n
            // read RGB triple from infile
            fread(&triple, sizeof(RGBTRIPLE), 1, inptr);
            // scanLine[scanLineCount] = triple;
            // scanLineCount++;
            
            // write RGB triple to outfile
            for (int z = 0; z < n; i++)
            {
            fwrite(&triple, sizeof(RGBTRIPLE), 1, outptr);
            }
                
            if (j == newbi.biWidth - 1)
            {
                    // add padding
                    for (int k = 0; k < padding; k++)
                    {
                    fputc(0x00, outptr);
                    }
                fseek(outptr, -scanIfSeekOffSet, SEEK_CUR);
                for (int w = 0; w < scanIfSeekOffSet; w++)
                {
                fread(&scanLine[w], sizeof(RGBTRIPLE), 1, outptr );
                }
                for (int y = 0; y < n; y++)
                {
                fwrite(&scanLine, sizeof(scanLine), 1, outptr);
                    for (int k = 0; k < padding; k++)
                    {
                    fputc(0x00, outptr);
                    }
                }
            }
        }

        // skip over padding, if any
        fseek(inptr, padding, SEEK_CUR);

        // then add it back (to demonstrate how)
        for (int k = 0; k < padding; k++)
        {
            fputc(0x00, outptr);
        }
    }

    // close infile
    fclose(inptr);

    // close outfile
    fclose(outptr);

    // that's all folks
    return 0;
}
