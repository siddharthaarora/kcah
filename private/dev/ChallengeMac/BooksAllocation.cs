// N number of books are given. 
// The ith book has Pi number of pages. 
// You have to allocate books to M number of students so that maximum number of pages alloted to a student is minimum. 
// A book will be allocated to exactly one student. Each student has to be allocated at least one book. Allotment should 
// be in contiguous order, for example: A student cannot be allocated book 1 and book 3, skipping book 2.
// NOTE: Return -1 if a valid assignment is not possible

// Input:
// List of Books M number of students

// Your function should return an integer corresponding to the minimum number.

// Example:

// P : [12, 34, 67, 90]
// M : 2
// Output : 113
// There are 2 number of students. Books can be distributed in following fashion : 
//   1) [12] and [34, 67, 90]
//       Max number of pages is allocated to student 2 with 34 + 67 + 90 = 191 pages
//   2) [12, 34] and [67, 90]
//       Max number of pages is allocated to student 2 with 67 + 90 = 157 pages 
//   3) [12, 34, 67] and [90]
//       Max number of pages is allocated to student 1 with 12 + 34 + 67 = 113 pages

// Of the 3 cases, Option 3 has the minimum pages = 113. 

using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public static class BookAllocation
    {
        public static int AllocateBooks(List<int> A, int B)
        {
            int students = B;
            int high = Int32.MaxValue;
            int low = 0;
            int mid, res = 0;
            int sum = 0;

            if (students > A.Count)
            {
                return -1;
            }

            foreach (var pages in A)
            {
                sum+=pages;
            }

            while (low <= high)
            {
                mid = low + ((high-low) >> 1);
                if (IsPossible(A, B, mid, sum))
                {
                    res = mid;
                    high = mid-1;
                }
                else
                {
                    low = mid+1;
                }
            }
            return res;
        }

        private static bool IsPossible(List<int> A, int B, int maxPage, int totalPages)
        {
            if (maxPage < totalPages / B)
            {
                return false;
            }

            int index = 0;
            int n = A.Count;


            for (int i=0; i < B && index < n; i++)
            {
                int page = maxPage;
                int total = 0;

                while (total < maxPage && index < n)
                {
                    total += A[index];
                    if (total > maxPage)
                    {
                        break;
                    }
                    index++;
                }
            }

            if (index < n)
            {
                return false;
            }

            return true;
        }
        public static void Test_AllocateBooks()
        {
            List<int> bookPages = new List<int>() {12, 34, 67, 90};
            int numStudents = 2;

            int minBookPages = AllocateBooks(bookPages, numStudents);

            Console.WriteLine("Min book pages: " + minBookPages.ToString());
        }
    }
}