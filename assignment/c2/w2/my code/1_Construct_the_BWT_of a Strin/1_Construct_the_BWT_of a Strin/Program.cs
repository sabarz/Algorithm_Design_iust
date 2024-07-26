using System;
using System.Collections.Generic;

namespace _1_Construct_the_BWT_of_a_Strin
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> s = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                s.Add(text.Substring(i) + text.Substring(0, i));
            }

            s.Sort();

            string ans = "";

            for (int i = 0; i < s.Count; i++)
            {
                ans += s[i][text.Length - 1];
            }

            Console.WriteLine(ans);
        }
    }
}
