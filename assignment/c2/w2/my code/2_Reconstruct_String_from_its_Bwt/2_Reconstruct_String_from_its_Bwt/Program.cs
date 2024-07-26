using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Reconstruct_String_from_its_Bwt
{
    class Program
    {
        static void Main(string[] args)
        {
            string bwt = Console.ReadLine();
            List<char> firstColmn = new List<char>();
            Dictionary<string, int> firstColmnDictionory = new Dictionary<string, int>();
            Dictionary<int, int> lastColmnDictionory = new Dictionary<int, int>();
            Dictionary<char, int> ah1 = new Dictionary<char, int>();
            Dictionary<char, int> ah2 = new Dictionary<char, int>();

            ah1['C'] = 0;
            ah2['C'] = 0;
            ah1['A'] = 0;
            ah2['A'] = 0;
            ah1['T'] = 0;
            ah2['T'] = 0;
            ah1['G'] = 0;
            ah2['G'] = 0;
            ah1['$'] = 0;
            ah2['$'] = 0;

            int n = bwt.Length;
            for (int i = 0; i < n; i++)
            {
                firstColmn.Add(bwt[i]);
            }
            firstColmn.Sort();
            for (int i = 0; i < n; i++)
            {
                ah1[firstColmn[i]] += 1;
                ah2[bwt[i]] += 1;
                firstColmnDictionory[firstColmn[i].ToString() + ah1[firstColmn[i]].ToString()] = i;
                lastColmnDictionory[i] = ah2[bwt[i]];
            }

            int j = 0, cnt = 0;
            string ans = "";
            List<char> c = new List<char>();
            while (cnt != n - 1)
            {
                //ans = bwt[j].ToString() + ans;
                c.Add(bwt[j]);
                j = firstColmnDictionory[bwt[j].ToString() + lastColmnDictionory[j].ToString()];
                cnt++;
            }
            c.Reverse();
            c.Add('$');

            Console.WriteLine(new string(c.ToArray()));
        }
    }
}
