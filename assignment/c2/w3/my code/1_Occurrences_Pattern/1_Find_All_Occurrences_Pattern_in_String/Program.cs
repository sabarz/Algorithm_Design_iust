using System;
using System.Collections.Generic;

namespace _1_Find_All_Occurrences_Pattern_in_String
{
    class Program
    {

        public static int[] Findoccurence(int n, string text)
        {
            int[] p = new int[n];
            int border = 0;
            p[0] = 0;

            for (int i = 1; i < n; i++)
            {
                while (border > 0 && text[i] != text[border])
                {
                    border = p[border - 1];
                }
                if (text[i] == text[border])
                {
                    border++;
                }
                else
                {
                    border = 0;
                }
                p[i] = border;
            }

            return p;
        }
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            string hold = pattern + "$" + text;
            int[] p = Findoccurence(hold.Length, hold);

            List<long> ans = new List<long>();

            for (int i = pattern.Length; i <= hold.Length - 1; i++)
            {
                if (p[i] == pattern.Length)
                {
                    ans.Add(i - (2 * pattern.Length));
                }
            }
            
            for(int i = 0; i < ans.Count; i ++)
            {
                Console.Write(ans[i] + " ");
            }
        }
    }
}
