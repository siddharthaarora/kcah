using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public static class SteppingNumber
    {
        private static bool IsSteppingNumber(int num)
        {
            int size = 0;
            int temp = num;
            while (temp > 0)
            {
                size++;
                temp = temp / 10;
            }

            if (size == 1)
            {
                return true;
            }

            int prev = -1;
            temp = num;
            while (size > 0)
            {
                int curr = temp % 10;
                if (prev == -1 || Math.Abs(prev - curr) == 1)
                {
                    prev = curr;
                    temp = temp / 10;
                    size--;
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        public static List<int> FindSteppingNumbers(int start, int end)
        {
            List<int> list = new List<int>();

            if (start < 0 || end < 0 || start > end)
            {
                return list;
            }

            for(int num=start;num<=end;num++)
            {
                if (IsSteppingNumber(num))
                {
                    list.Add(num);
                }
            }

            return list;
        }

        public static void Test_FindSteppingNumbers()
        {
            List<int> stepNums = FindSteppingNumbers(0,86);

            foreach(int n in stepNums)
            {
                Console.WriteLine(n);
            }
        }
    }
}