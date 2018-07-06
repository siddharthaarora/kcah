// Find out the maximum sub-array of non negative numbers from an array.
// The sub-array should be continuous. That is, a sub-array created by choosing the second and fourth element and skipping the third element is invalid.

// Maximum sub-array is defined in terms of the sum of the elements in the sub-array. Sub-array A is greater than sub-array B if sum(A) > sum(B).

// Example:

// A : [1, 2, 5, -7, 2, 3]
// The two sub-arrays are [1, 2, 5] [2, 3].
// The answer is [1, 2, 5] as its sum is larger than [2, 3]
// NOTE: If there is a tie, then compare with segment's length and return segment which has maximum length
// NOTE 2: If there is still a tie, then return the segment with minimum starting index

//Cases:
// 1. A : [1, 2, 5, -7, 2, 3]
// 2. A : [-7, 1, 2, 5, 2, 3]
// 3. A : [1, 2, 5, 2, 3, -7]
// 4. A : [1, 2, 5, 2, 3]
// 5. A : [-1, -2, -5, -7, -2, -3]
// 6. A : [1, 2, 5, -7, 2, 3, -1, 9, 3, 9]

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public class Maxset
    {
        public static List<int> FindMaxset(List<int> a)
        {
            List<int> maxSet = new List<int>();
            List<int> temp = new List<int>();
            int maxSum = 0, maxIndex = 0, maxSetCount = 0;
            int sum = 0, index = 0, setCount = 0;

            for(int i=0; i<a.Count; i++)
            {
                if (a[i] < 0)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    else if (i != 0)
                    {
                        if ((sum > maxSum) || ((sum == maxSum) && (setCount > maxSetCount && index > maxIndex)))
                        {
                            maxSum = sum;
                            maxIndex = index;
                            maxSetCount = setCount;
                            maxSet.AddRange(temp);
                        }
                        sum = index = setCount = 0;
                        temp.Clear();
                    }               
                }
                else
                {
                    sum += a[i];
                    temp.Add(a[i]);
                    setCount++;
                    index = i;
                }

                if ((i == a.Count - 1) && ((sum > maxSum) || ((sum == maxSum) && (setCount > maxSetCount && index > maxIndex))))
                {
                    maxSet.Clear();
                    maxSet.AddRange(temp);
                }
            }
            return maxSet;
        }

        public static void Test_Maxset(List<int> a)
        {
            List<int> maxSet = new List<int>();
            maxSet = FindMaxset(a);

            Console.Write("Original set: ");
            foreach(var n in a)
            {
                Console.Write(n);
                Console.Write(", ");
            }
            Console.WriteLine();

            Console.Write("Max set: ");
            foreach(var n in maxSet)
            {
                Console.Write(n);
                Console.Write(", ");
            }
            Console.WriteLine();

        }
    }
}