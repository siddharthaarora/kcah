using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public static class ArrayManipulation
    {
        public static int SingleNumber(List<int> A)
        {
            int number = 0;
            foreach (int e in A)
            {
                number = number ^ e;
            }

            return number;
        }

        public static int MajorityElement(List<int> A)
        {
            int i = 1;
            int major = A[0];

            for (int j = 1; j < A.Count; j++)
            {
                if (major == A[j])
                {
                    i++;
                }
                else
                {
                    i--;
                }

                if (i == 1)
                {
                    major = A[j];
                }
            }
            return major;
        }

        public static int RemoveElement(ArrayList a, int b)
        {
            int count = 0;

            if (a == null)
            {
                return 0;
            }

            for (int i = 0; i < a.Count; i++)
            {
                int j = i;

                if ((int)a[j] != b)
                {
                    count++;
                }
                else
                {
                    while ((int)a[j] == b)
                    {
                        j++;
                    }
                    a[i] = a[j];
                    count = j - i;
                }
            }

            return a.Count - count;
        }

        /// <summary>
        /// Given an array A of integers and another non negative integer k, 
        /// find if there exists 2 indices i and j such that A[i] - A[j] = k, i != j.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int DiffK2(List<int> A, int B)
        {
            if (A == null) return 0;
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (set.Contains(B + A[i]) || set.Contains(A[i] - B))
                {
                    return 1;
                }
                else
                {
                    set.Add(A[i]);
                }
            }

            return 0;
        }

        /// <summary>
        /// Given a column title as appears in an Excel sheet, return its corresponding column number.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int ExcelColumnNameToNumber(string A)
        {
            if (A == null || A.Length == 0) { return 0; }

            int columnNumber = 0;
            Dictionary<char, int> columNameToNumberMapping = new Dictionary<char, int>(26);
            columNameToNumberMapping.Add('a', 1);
            columNameToNumberMapping.Add('b', 2);
            columNameToNumberMapping.Add('c', 3);
            columNameToNumberMapping.Add('d', 4);
            columNameToNumberMapping.Add('e', 5);
            columNameToNumberMapping.Add('f', 6);
            columNameToNumberMapping.Add('g', 7);
            columNameToNumberMapping.Add('h', 8);
            columNameToNumberMapping.Add('i', 9);
            columNameToNumberMapping.Add('j', 10);
            columNameToNumberMapping.Add('k', 11);
            columNameToNumberMapping.Add('l', 12);
            columNameToNumberMapping.Add('m', 13);
            columNameToNumberMapping.Add('n', 14);
            columNameToNumberMapping.Add('o', 15);
            columNameToNumberMapping.Add('p', 16);
            columNameToNumberMapping.Add('q', 17);
            columNameToNumberMapping.Add('r', 18);
            columNameToNumberMapping.Add('s', 19);
            columNameToNumberMapping.Add('t', 20);
            columNameToNumberMapping.Add('u', 21);
            columNameToNumberMapping.Add('v', 22);
            columNameToNumberMapping.Add('w', 23);
            columNameToNumberMapping.Add('x', 24);
            columNameToNumberMapping.Add('y', 25);
            columNameToNumberMapping.Add('z', 26);

            for(int i=0; i<A.Length; i++)
            {
                int v = 0;
                columNameToNumberMapping.TryGetValue(Char.ToLower(A[i]), out v);

                if (v == 0) { return 0; };

                if (A.Length > 1 && i < A.Length - 1)
                {
                    columnNumber = columnNumber + Convert.ToInt32((Math.Pow(26, (A.Length - 1 - i)) * v));
                }
                else
                {
                    columnNumber += v;
                }
            }

            return columnNumber;
        }

    }
}
