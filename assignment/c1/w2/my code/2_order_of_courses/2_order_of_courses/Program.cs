using System;
using System.Collections.Generic;

namespace _2_order_of_courses
{
    class Program
    {
        class Node
        {
            public bool check;
            public int val;
            public List<int> neighbers;
            public Node(int value)
            {
                check = false;
                val = value;
                neighbers = new List<int>();
            }
        }
        static void DFS(List<Node> nodes, Node Pnode)
        {
            for (int i = 0; i < Pnode.neighbers.Count; i++)
            {
                if(!nodes[Pnode.neighbers[i]].check)
                {
                    DFS(nodes, nodes[Pnode.neighbers[i]]);
                }
            }
            Pnode.check = true;
            Console.WriteLine(Pnode.val  + 1);
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
                nodes[int.Parse(a[1]) - 1].neighbers.Add(int.Parse(a[0]) - 1);
            }

            for(int i = 0; i < nV; i ++)
            {
                if(!nodes[i].check)
                {
                    DFS(nodes, nodes[i]);
                }
            }
        }
    }
}
