using System;
using System.Collections.Generic;

namespace _2_Implement_TrieMatching
{
    class Program
    {
        class Node
        {
            public Node[] neighbors;
            public int[] neighborsChar;
            public int val;
            public bool isleaf;

            public Node()
            {
                neighbors = new Node[4];
                neighborsChar = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    neighborsChar[i] = -1;
                }
                isleaf = false;
            }
        }
        public static int find(char letter)
        {
            int ans = 0;
            switch (letter)
            {
                case 'A':
                    ans = 0;
                    break;

                case 'C':
                    ans = 1;
                    break;

                case 'G':
                    ans = 2;
                    break;

                case 'T':
                    ans = 3;
                    break;
            }
            return ans;
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] patterns = new string[n];
            for (int i = 0; i < n; i ++)
            {
                patterns[i] = Console.ReadLine();
            }
            Node nodes = new Node();
            List<long> ans = new List<long>();

            for (int i = 0; i < n; i++)
            {
                string a = patterns[i];
                Node hold = nodes;

                for (int j = 0; j < a.Length; j++)
                {
                    int index = find(a[j]);
                    /*if (hold.neighbors.Count == 0)
                    {
                        hold.neighborsChar[index] = 0;
                        hold.neighbors[index] = new Node();
                        hold = hold.neighbors[index];
                        if (j == a.Length - 1)
                        {
                            hold.isleaf = true;
                        }
                    }
                    else
                    {*/
                    bool check = false;
                    if (hold.neighborsChar[index] == 0 && !hold.isleaf)
                    {
                        hold = hold.neighbors[index];
                        check = true;
                        //break;
                    }
                    if (!check)
                    {
                        hold.neighborsChar[index] = 0;
                        hold.neighbors[index] = new Node();
                        hold = hold.neighbors[index];
                        if (j == a.Length - 1)
                        {
                            hold.isleaf = true;
                        }

                    }
                    // }
                }
            }

            for (int j = 0; j < text.Length; j++)
            {
                Node hold = nodes;
                int cnt = j;

                while (true)
                {
                    bool check = false;
                    if (hold.isleaf)
                    {
                        ans.Add(j);
                        break;
                    }
                    else if(cnt < text.Length)
                    {
                        int index = find(text[cnt]);
                        if (cnt < text.Length && hold.neighborsChar[index] == 0)
                        {
                            hold = hold.neighbors[index];
                            cnt++;
                            check = true;
                            //break;
                        }
                    }

                    if (!check)
                    {
                        break;
                    }
                }
            }

            if (ans.Count == 0)
                ans.Add(-1);

            foreach (var it in ans)
            {
                Console.Write(it + " ");
            }
        }
    }
}
