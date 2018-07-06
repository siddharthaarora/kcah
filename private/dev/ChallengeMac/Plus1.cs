// Given a non-negative number represented as an array of digits, 
// add 1 to the number ( increment the number represented by the digits ).
// The digits are stored such that the most significant digit is at the head of the list.
// Example:
// If the vector has [1, 2, 3]
// the returned vector should be [1, 2, 4]
// as 123 + 1 = 124.
using System;
using System.Collections.Generic;

namespace Challenge
{    public partial class CodeLab
    {
        public static List<int> Plus1(List<int> A)
        {
            List<int> r = new List<int>();
            bool isOneCarryOver = false;

            if (A == null || A.Count == 0)
            {return r;}

            for (int i = A.Count-1;i >= 0;i--)
            {
                if (i == A.Count - 1)
                {
                    A[i]++;
                }

                if (isOneCarryOver)
                {
                    A[i]++;
                }

                if (A[i] >= 10)
                {
                    A[i] = 0;
                    isOneCarryOver = true;
                }
                else
                {
                    isOneCarryOver = false;
                }

                if (i == 0)
                {
                    if (isOneCarryOver)
                    {
                        A.Insert(i, 1);
                    }
                }
            }

            bool isRemoved = false;
            for (int i = 0; i < A.Count;i++)
            {
                if (isRemoved)
                {i = 0;}
                
                if (A[i] == 0)
                {
                    A.RemoveAt(i);
                    isRemoved = true;
                } 
                else
                {
                    break;
                }
            }
            return A;
        }
    }
}