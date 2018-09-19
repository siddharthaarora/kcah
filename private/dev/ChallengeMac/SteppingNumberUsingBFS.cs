using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public static class SteppingNumberBFS
    {
        public static List<int> FindSteppingNumbers(int start, int end)
        {
            //for every single digit between 0-9
            //find all the stepping numbers starting
            //with that digit

            List<int> res = new List<int>();

            for(int i=0; i<=9; i++)
            {
                FindSteppingNumberUsingBFS(start, end, i, res);
            }

            return res;
        }

        public static void FindSteppingNumberUsingBFS(int start, int end, int num, List<int> res)
        {
            Queue<int> l = new Queue<int>();
            l.Enqueue(num);

            while(l.Count != 0)
            {
                int stepNum = l.Dequeue();
                
                if (stepNum >=start && stepNum <= end)
                {
                    res.Add(stepNum);
                }

                if (stepNum == 0 || stepNum > end)
                {
                    continue;
                }

                int lastDigit = stepNum % 10;

                int stepNumA = lastDigit * 10 + (lastDigit - 1);
                int stepNumB = lastDigit * 10 + (lastDigit + 1);

                if (lastDigit == 0)
                {
                    l.Enqueue(stepNumB);
                }
                else if (lastDigit == 9)
                {
                    l.Enqueue(stepNumA);
                }
                else
                {
                    l.Enqueue(stepNumB);
                }
            }
        }

        public static void Test_FindSteppingNumbers()
        {
            List<int> res = FindSteppingNumbers(10,25);
            Utilities.PrintList(res);
        }
    }
}