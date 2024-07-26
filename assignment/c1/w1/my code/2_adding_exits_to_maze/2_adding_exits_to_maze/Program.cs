using System;
using System.Collections.Generic;

namespace _2_adding_exits_to_maze
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
        static void DFS(List<Node> nodes, Node Pnode)
        {
            Pnode.check = true;
            for (int i = 0; i < Pnode.neighbers.Count; i++)
            {
                if (!nodes[Pnode.neighbers[i]].check)
                {
                    nodes[Pnode.neighbers[i]].check = true;
                    DFS(nodes, nodes[Pnode.neighbers[i]]);
                }
            }
        }
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);

            List<Node> nodes = new List<Node>();

            for (int i = 0; i < nV; i++)
            {
                nodes.Add(new Node());
            }

            for (int i = 0; i < mE; i++)
            {
                a = Console.ReadLine().Split(' ');
                nodes[int.Parse(a[0]) - 1].neighbers.Add(int.Parse(a[1]) - 1);
                nodes[int.Parse(a[1]) - 1].neighbers.Add(int.Parse(a[0]) - 1);
            }
            int ans = 0;

            for (int i = 0; i < nV; i++)
            {
                if (!nodes[i].check)
                {
                    DFS(nodes, nodes[i]);
                    ans++;
                }
            }

            Console.WriteLine(ans);
        }
    }
}
