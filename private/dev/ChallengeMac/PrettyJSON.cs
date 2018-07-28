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
        public static List<string> PrettyPrintJSON(string A)
        {
            List<string> res = new List<string>();
            StringBuilder str = new StringBuilder();
            int n = A.Length;
            int tabs = 0;
            
            for (int i = 0; i < n; ) 
            {
                i = SkipSpace(A, i);
                
                if (i >= n)
                    break;
                
                str = new StringBuilder();
                char c = A[i];
                
                if (Delimiter(c)) {
                    
                    if (IsOpenBracket(c)) {
                        for (int j = 0; j < tabs; j++)
                            str.Append("\t");	                
                        tabs++;
                    } else if (IsClosedBracket(c)) {
                        tabs--;
                        for (int j = 0; j < tabs; j++)
                            str.Append("\t");
                    }
                    
                    str.Append(c);
                    i++;
                    
                    if (i < n && CanAdd(A[i])) {
                        str.Append(A[i]);
                        i++;
                    }
                    
                    res.Add(str.ToString());
                    
                    continue;
                }
                
                while (i < n && !Delimiter(A[i])) {
                    str.Append(A[i]);
                    i++;
                }
                
                if (i < n && CanAdd(A[i])) {
                    str.Append(A[i]);
                    i++;
                }
                
                StringBuilder strB = new StringBuilder();
                
                for (int j = 0; j < tabs; j++)
                    strB.Append("\t");
                
                strB.Append(str);
                strB.Append("/n");
                res.Add(strB.ToString());
            }
            
            return res;
        }
	
        public static bool CanAdd(char c) 
        {
            if (c == ',' || c == ':')
                return true;
                
            return false;
        }
            
        public static bool Delimiter(char c) 
        {
            if (c == ',' || IsOpenBracket(c) || IsClosedBracket(c))
                return true;
            return false;
        }
        
        public static bool IsOpenBracket(char c) 
        {
            if (c == '[' || c == '{')
                return true;
            return false;
        }
	
        public static bool IsClosedBracket(char c) 
        {
            if (c == ']' || c == '}')
                return true;
            return false;
        }
        
        public static int SkipSpace(String A, int i) 
        {
            int n = A.Length;
            while (i < n && A[i] == ' ')
                i++;
            return i;
        }
	

        public static void Test_PrettyPrintJSON()
        {
            string json = @"{A:""B"",C:{D:""E"",F:{G:""H"",I:""J""}}}"; //["foo", {"bar":["baz",null,1.0,2]}]
            List<string> res = PrettyPrintJSON(json);

            foreach(var s in res)
            {
                Console.WriteLine(s);
            }
        }
    }
}
