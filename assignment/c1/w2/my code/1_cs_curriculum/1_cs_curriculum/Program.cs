using System;
using System.Collections.Generic;

namespace _1_cs_curriculum
{
    class Program
    {
        class Node
        {
            public bool check;
            public bool cyclic;
            public int val;
            public List<int> neighbers;
            public Node(int value)
            {
                check = false;
                cyclic = false;
                val = value;
                neighbers = new List<int>();
            }
        }
        static bool DFS(List<Node> nodes, Node Pnode)
        {
            Pnode.check = true;
            Pnode.cyclic = true;

            for (int i = 0; i < Pnode.neighbers.Count; i++)
            {
                if (!nodes[Pnode.neighbers[i]].check && DFS(nodes, nodes[Pnode.neighbers[i]]))
                {
                    return true;
                }
                else if(nodes[Pnode.neighbers[i]].cyclic)
                {
                    return true;
                }
            }

            Pnode.cyclic = false;
            return false;
        }
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);

            List<Node> nodes = new List<Node>();

            for (int i = 0; i < nV; i++)
            {
                nodes.Add(new Node(i));
            }

            for (int i = 0; i < mE; i++)
            {
                a = Console.ReadLine().Split(' ');
                nodes[int.Parse(a[0]) - 1].neighbers.Add(int.Parse(a[1]) - 1);
            }

            bool dfsAns = false;
            
            for (int i = 0; i < nV; i++)
            {
                dfsAns = DFS(nodes, nodes[i]);
                if (dfsAns == true)
                {
                    Console.WriteLine(1);
                    break;
                }
            }

            if(dfsAns == false)
            Console.WriteLine(0);
        }
    }
}
