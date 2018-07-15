using System;
using System.Collections.Generic;

namespace Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // string json = @"{A:""B"",C:{D:""E"",F:{G:""H"",I:""J""}}}"; //["foo", {"bar":["baz",null,1.0,2]}]
            // JSONParser parser = new JSONParser(json);
            // string res = parser.Parse();

            Sort.Test_SelectionSort();
            Sort.Test_InsertionSort();
        }
    }
}
