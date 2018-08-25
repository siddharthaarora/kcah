using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace Challenge
{
    public static class Tinyurl
    {
        public static string CreateHandle(string url)
        {
            char[] map = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-".ToCharArray();
            Int64 hash;
            StringBuilder handle = new StringBuilder();

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, url);
            }
            
            Console.WriteLine("64-bit number from MD5 hash of url is: " + hash.ToString());

            while(hash != 0)
            {
                handle.Append(map[hash%64]);
                hash /= 64;
            }

            return handle.ToString();
        }

        private static Int64 GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            Console.WriteLine("Hex representation of MD5 hash: " + data.Select(i => i.ToString("X")).Aggregate((x,y) => x + y));

            return new int[] {0,8}
                            .Select(i => BitConverter.ToInt64(data,i))
                            .Aggregate((x,y) => x ^ y);
        }

        public static void Test_CreateHandle()
        {
            string url = "http://www.xyz.com/main/123.html";
            string handle = CreateHandle(url);
            Console.WriteLine("The handle for " + url + " is: " + handle + ".");
        }

    }
}