using System;
using System.Collections.Generic;

namespace _3_Extend_TrieMatching
{
    class Program
    {
        class Node
        {
            public List<int> neighbors;
            public List<string> neighborsChar;
            public int val;
            public bool isleaf;

            public Node(int v)
            {
                val = v;
                neighbors = new List<int>();
                neighborsChar = new List<string>();
                isleaf = false;
            }
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] patterns = new string[n];
            for (int i = 0; i < n; i++)
            {
                patterns[i] = Console.ReadLine();
            }
            List<Node> nodes = new List<Node>();
            List<long> ans = new List<long>();

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
                        hold.neighbors.Add(nmd);
                        hold.neighborsChar.Add(a[j].ToString());
                        nodes.Add(new Node(nmd));
                        hold = nodes[nmd];
                        if (j == a.Length - 1)
                        {
                            nodes[nmd].isleaf = true;
                        }
                        nmd++;
                    }
                    else
                    {
                        bool check = false;
                        for (int t = 0; t < hold.neighbors.Count; t++)
                        {
                            if (hold.neighborsChar[t] == a[j].ToString() /*&& !hold.isleaf*/)
                            {
                                hold = nodes[hold.neighbors[t]];
                                check = true;
                                if (j == a.Length - 1)
                                {
                                    hold.isleaf = true;
                                }
                                break;
                            }
                        }
                        if (!check)
                        {
                            hold.neighbors.Add(nmd);
                            hold.neighborsChar.Add(a[j].ToString());
                            nodes.Add(new Node(nmd));
                            hold = nodes[nmd];
                            if (j == a.Length - 1)
                            {
                                nodes[nmd].isleaf = true;
                            }
                            nmd++;
                        }
                    }
                }
            }

            for (int j = 0; j < text.Length; j++)
            {
                Node hold = nodes[0];
                int cnt = j;

                while (true)
                {
                    bool check = false;
                    if (hold.isleaf)
                    {
                        if(!ans.Contains(j))
                        ans.Add(j);
                    }
                    else
                    {
                        for (int i = 0; i < hold.neighbors.Count; i++)
                        {
                            if (cnt < text.Length && hold.neighborsChar[i] == text[cnt].ToString())
                            {
                                hold = nodes[hold.neighbors[i]];
                                cnt++;
                                check = true;
                                break;
                            }
                        }
                    }

                    if (!check)
                    {
                        break;
                    }
                }
            }

            foreach (var it in ans)
            {
                Console.Write(it + " ");
            }
        }
    }
}
