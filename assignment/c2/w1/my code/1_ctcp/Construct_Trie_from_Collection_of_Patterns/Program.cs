using System;
using System.Collections.Generic;

namespace Construct_Trie_from_Collection_of_Patterns
{
    class Program
    {
        class Node
        {
            public List<int> neighbors;
            public List<string> neighborsChar;
            public int val;

            public Node(int v)
            {
                val = v;
                neighbors = new List<int>();
                neighborsChar = new List<string>();
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] patterns = new string[n];
            for (int i = 0; i < n; i ++)
            {
                patterns[i] = Console.ReadLine();
            }
            List<Node> nodes = new List<Node>();
            List<string> ans = new List<string>();

            nodes.Add(new Node(0));
            int nmd = 1;

            for (int i = 0; i < n; i++)
            {
                string a = patterns[i];
                Node hold = nodes[0];

                for (int j = 0; j < a.Length; j++)
                {
                    if (hold.neighbors.Count == 0)
                    {
                        ans.Add(hold.val.ToString() + "->" + (nmd).ToString() + ":" + a[j]);
                        hold.neighbors.Add(nmd);
                        hold.neighborsChar.Add(a[j].ToString());
                        nodes.Add(new Node(nmd));
                        hold = nodes[nmd];
                        nmd++;
                    }
                    else
                    {
                        bool check = false;
                        for (int t = 0; t < hold.neighbors.Count; t++)
                        {
                            if (hold.neighborsChar[t] == a[j].ToString())
                            {
                                hold = nodes[hold.neighbors[t]];
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            ans.Add(hold.val.ToString() + "->" + (nmd).ToString() + ":" + a[j]);
                            hold.neighbors.Add(nmd);
                            hold.neighborsChar.Add(a[j].ToString());
                            nodes.Add(new Node(nmd));
                            hold = nodes[nmd];
                            nmd++;
                        }
                    }
                }
            }

            foreach (var it in ans)
                Console.WriteLine(it);
        }
    }
}
