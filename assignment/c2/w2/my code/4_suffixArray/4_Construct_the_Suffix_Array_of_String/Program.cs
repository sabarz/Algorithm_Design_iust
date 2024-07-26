using System;
using System.Linq;
using System.Collections.Generic;

namespace _4_Construct_the_Suffix_Array_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<Tuple<string, long>> hold = new List<Tuple<string, long>>();
            for (int i = 0; i < text.Length; i++)
            {
                hold.Add(new Tuple<string, long>(text.Substring(i), i));
            }

            hold = hold.OrderBy(x => x.Item1).ToList();
            List<long> ans = new List<long>();

            for (int i = 0; i < hold.Count; i++)
            {
                ans.Add(hold[i].Item2);
            }
            foreach(long it in ans)
            {
                Console.Write(it + " ");
            }
        }
    }
}
