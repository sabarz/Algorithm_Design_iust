using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_intersection_reachability
{
    class Program
    {
        class Node
        {
            public bool check;
            public List<int> neighbers;
            public int value;
            public int postNum;
            public Node(int val)
            {
                value = val;
                check = false;
                neighbers = new List<int>();
            }
        }
        static void DFS(List<Node> nodes, Node Pnode , ref int cnt)
        {
            Pnode.check = true;

            for (int i = 0; i < Pnode.neighbers.Count; i++)
            {
                if (!nodes[Pnode.neighbers[i]].check)
                {
                    nodes[Pnode.neighbers[i]].check = true;
                    cnt++;
                    DFS(nodes, nodes[Pnode.neighbers[i]] , ref cnt);
                }
            }

            Pnode.postNum = ++cnt;
        }
        static void SecondDFS(List<Node> nodes, Node Pnode)
        {
            Pnode.check = true;

            for (int i = 0; i < Pnode.neighbers.Count; i++)
            {
                if (!nodes[Pnode.neighbers[i]].check)
                {
                    nodes[Pnode.neighbers[i]].check = true;
                    SecondDFS(nodes, nodes[Pnode.neighbers[i]] );
                }
            }
        }
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);

            List<Node> Gnodes = new List<Node>();
            List<Node> GRnodes = new List<Node>();

            for (int i = 0; i < nV; i++)
            {
                Gnodes.Add(new Node(i));
                GRnodes.Add(new Node(i));
            }

            for (int i = 0; i < mE; i++)
            {
                a = Console.ReadLine().Split(' ');
                Gnodes[int.Parse(a[0]) - 1].neighbers.Add(int.Parse(a[1]) - 1);
                GRnodes[int.Parse(a[1]) - 1].neighbers.Add(int.Parse(a[0]) - 1);
            }

            int nmd = 1; 

            for (int i = 0; i < nV; i++)
            {
                if (!GRnodes[i].check)
                {
                    DFS(GRnodes, GRnodes[i] , ref nmd);
                }
            }

            int cnt = 0, ans = 0;

            GRnodes = GRnodes.OrderByDescending(x => x.postNum).ToList();

            for(int i = 0; i < nV; i++)
            {
                cnt = GRnodes[i].value;
                if(!Gnodes[cnt].check)
                {
                    ans++;
                    SecondDFS(Gnodes, Gnodes[cnt]);
                }
            }

            Console.WriteLine(ans);
        }
    }
}
