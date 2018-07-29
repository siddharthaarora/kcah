// Given a string containing only digits, restore it by returning all possible valid IP address combinations.
// A valid IP address must be in the form of A.B.C.D, where A,B,C and D are numbers from 0-255. The numbers cannot be 0 prefixed unless they are 0.
// Example:
// Given “25525511135”,
// return [“255.255.11.135”, “255.255.111.35”]. (Make sure the returned strings are sorted in order)

// Algo:
// 1. If the length of the input string "a" is 12 < a < 4, return
// 2. Insert three "." in input string; this is the initial state. 
// 3. E.g. if input is “25525511135”, then initial state will be “2.5.5.25511135”
// 4. Split the string and check for each part to be < 255 and not starting with 0.
// 5. Shift the 3 dots to the right and repeat step 4.
// 6. Stop shifing when last element in the string is a "."

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public static class IPAddress
    {
        public static List<string> RestoreIPAddressToDotNotation(string A)
        {
            List<string> res = new List<string>();

            for(int i=1;i<A.Length;i++)
            {
                for(int j=i+1;j<A.Length;j++)
                {
                    for(int k=j+1;k<A.Length;k++)
                    {
                        if (!((A[0] == '0') && (i > 1)))
                        {
                            if (!((A[i] == '0') && (j > i+1)))
                            {
                                if (!((A[j] == '0') && (k > j+1)))
                                {
                                    if (!((A[k] == '0') && (A.Length > k+1)))
                                    {
                                        int firstOctet = Int32.Parse(A.Substring(0, i));
                                        int secondOctet = Int32.Parse(A.Substring(i, j-i));
                                        int thirdOctet = Int32.Parse(A.Substring(j, k-j));
                                        int forthOctet = Int32.Parse(A.Substring(k, A.Length-k));

                                        if (firstOctet <= 255 && secondOctet <= 255 && thirdOctet <= 255 && forthOctet <= 255)
                                        {
                                            StringBuilder sb = new StringBuilder();
                                            sb.Append(firstOctet.ToString());
                                            sb.Append(".");
                                            sb.Append(secondOctet.ToString());
                                            sb.Append(".");
                                            sb.Append(thirdOctet.ToString());
                                            sb.Append(".");
                                            sb.Append(forthOctet.ToString());
                                            res.Add(sb.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (res.Count == 0)
            {
                return null;
            }
            
            return res;
        }

        public static void Test_RestoreIPAddressToDotNotation()
        {
            List<string> ips = RestoreIPAddressToDotNotation("00000"); //25525511135

            Utilities.PrintList(ips);
        }
    }
}