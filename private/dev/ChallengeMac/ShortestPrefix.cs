//Find shortest unique prefix to represent each word in the list.
//Example:
//Input: [zebra, dog, duck, dove]
//Output: { z, dog, du, dov}
//where we can see that
//zebra = z
//dog = dog
//duck = du
//dove = dov

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public static class ShortestPrefix
    {
        public static List<string> FindShortestPrefix(List<string> a)
        {
            List<string> result = new List<string>();
            Trie t = new Trie();
            t.InsertRange(a);

            foreach(var s in a)
            {
                result.Add(t.Prefix(s));
            }

            return result;
        }

        public static void Test_FindShortestPrefix()
        {
            List<string> list = new List<string>(){"bearcat", "bert"};
            List<string> result = FindShortestPrefix(list);

            foreach(string r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}
