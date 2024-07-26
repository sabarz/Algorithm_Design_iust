using System;
using System.Collections.Generic;

namespace _1_finding_exit_from_maze
{
    class Program
    {
        class Node
        {
            public bool check;
            public List<int> neighbers;
            public Node()
            {
                check = false;
                neighbers = new List<int>();
            }
        }
        static bool ans = false;
        static void DFS(int u, int v, List<Node> nodes)
        {
            //Console.WriteLine(u + "  " + v);

            if (u == v)
            {
                ans = true;
            }

            for (int i = 0; i < nodes[u].neighbers.Count; i++)
            {
                if (!nodes[nodes[u].neighbers[i]].check)
                {
                    nodes[nodes[u].neighbers[i]].check = true;
                    DFS(nodes[u].neighbers[i], v, nodes);
                }
            }            
        }
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);

            List<Node> nodes = new List<Node>();
            
            for(int i = 0; i < nV; i ++)
            {
                nodes.Add(new Node());
            }

            for(int i = 0; i < mE; i ++)
            {
                a = Console.ReadLine().Split(' ');
                nodes[int.Parse(a[0]) - 1].neighbers.Add(int.Parse(a[1]) - 1);
                nodes[int.Parse(a[1]) - 1].neighbers.Add(int.Parse(a[0]) - 1);
            }

            a = Console.ReadLine().Split(' ');
            int u = int.Parse(a[0]) - 1;
            int v = int.Parse(a[1]) - 1;

           /* for(int i = 0; i < nV; i ++)
            {
                for(int j = 0; j < nodes[i].neighbers.Count; j++)
                {
                    Console.Write(nodes[i].neighbers[j] + "   ");
                }
                Console.WriteLine();
            }*/
            nodes[u].check = true;
        
            DFS(u, v, nodes);
            if (ans == true)
                Console.WriteLine(1);
            else
                Console.WriteLine(0);               
        }
    }
}
