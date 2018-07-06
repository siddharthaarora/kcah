//Pretty print a json object using proper indentation.
//Every inner brace should increase one indentation to the following lines.
//Every close brace should decrease one indentation to the same line and the following lines.
//The indents can be increased with an additional ‘\t’
//Example 1:
//Input : {A:"B",C:{D:"E",F:{G:"H",I:"J"}}}
//Output : 
//{ 
//    A:"B",
//    C: 
//    { 
//        D:"E",
//        F: 
//        { 
//            G:"H",
//            I:"J"
//        } 
//    }     
//}
//Example 2:
//Input : ["foo", {"bar":["baz",null,1.0,2]}]
//Output : 
//[
//    "foo",
//    {
//        "bar":
//        [
//            "baz",
//            null,
//            1.0,
//            2
//        ]
//    }
//]
//[] and {} are only acceptable braces in this case.
//Assume for this problem that space characters can be done away with.
//Your solution should return a list of strings, where each entry corresponds to a single line. The strings should not have “\n” character in them.

/////////

//Solution:
//1. for each char in JSON string
//2. if the char is "{" or "," or "[", 
//3. create a new string entry in the list and add a tab
//4. if the char is "}" or "]", remove a tab

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public static class PrettyJSON
    {
        public static List<string> PrettyPrintJSON(string jsonString)
        {
            List<string> res = new List<string>();
            StringBuilder tabs = new StringBuilder();

            foreach(char c in jsonString)
            {
                StringBuilder s = new StringBuilder();

                if (c == ' ')
                {
                    continue;
                }
                else if (c == '{' || c == '[' || c== ',')
                {
                    s.Append(tabs.ToString());
                    s.Append(c);
                    tabs.Append("/t");
                    res.Add(s.ToString());
                    s.Clear();
                }
                else if (c == '}' || c == ']')
                {
                    if (tabs.Length > 0)
                    {
                        tabs.Remove(tabs.Length - 1, 1);
                    }
                    s.Append(tabs.ToString());
                    s.Append(c);
                    res.Add(s.ToString());
                    s.Clear();
                }
                else
                {
                    s.Append(c);
                }

            }
            return res;
        }

        public static void Test_PrettyPrintJSON()
        {
            string json = @"{A:/""B/"",C:{D:/""E/"",F:{G:/""H/"",I:/""J/""}}}"; //["foo", {"bar":["baz",null,1.0,2]}]
            List<string> res = PrettyPrintJSON(json);

            foreach(var s in res)
            {
                Console.WriteLine(s);
            }
        }
    }
}
