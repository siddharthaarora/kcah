// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

// P.......A........H.......N
// ..A..P....L....S....I...I....G
// ....Y.........I........R

// And then read line by line: PAHNAPLSIIGYIR
// Write the code that will take a string and make this conversion given a number of rows:
// string convert(string text, int nRows);
// convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR"

// Algo:
// 1. Start an outer loop for each character in the input string
// 2. for each char
// 3. Start a loop increasing order till row count
// 4. Add the char to the string in list at the specified index
// 5. Start another loop decreasing order till 0
// 6. Add the char to the string in the list at the spefied row index
// 7. Return the appended strings in the list

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class Zigzag
{
    public static string ConvertStringToZigzag(string A, int nRows)
    {
        string[] rows = new string[nRows];
        int i = -1;
        bool forward = true;

        if (nRows == 1)
        {
            return A;
        }

        foreach(var c in A)
        {
            if (forward)
            {
                i++;
                rows[i] = rows[i] + c;
            }
            else
            {
                i--;
                rows[i] = rows[i] + c;
            }

            if (i == nRows-1 && forward)
            {
                forward = false;
            }
            else if (i == 0 && !forward)
            {
                forward = true;
            }
        }

        StringBuilder sb = new StringBuilder();

        foreach(var s in rows)
        {
            sb.Append(s);
        }

        return sb.ToString();
    }

    public static void Test_ConvertStringToZigzag()
    {
        // Console.Write("Enter a string to be converted to zigzag format: ");
        // string s = Console.ReadLine();
        // Console.Write("Enter the number of rows: ");
        // int n = Int32.Parse(Console.ReadLine());

        string z = ConvertStringToZigzag("ABCD", 10);
        Console.WriteLine("Zigzag string: " + z);
    }
}