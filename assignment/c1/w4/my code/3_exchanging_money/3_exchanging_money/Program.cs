using System;
using System.Collections.Generic;

namespace _3_exchanging_money
{
    class Program
    {
        class Node
        {
            public int dist;
            public bool check;
            public bool NegativeCycle;
            public List<Tuple<int, int>> neighbors;

            public Node()
            {
                NegativeCycle = false;
                check = false;
                dist = int.MaxValue;
                neighbors = new List<Tuple<int, int>>();
            }
        }

        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);
            List<List<int>> edges = new List<List<int>>();

            for (int i = 0; i < mE; i++)
            {
                a = Console.ReadLine().Split(' ');
                edges.Add(new List<int>() { int.Parse(a[0]) - 1, int.Parse(a[1]) - 1, int.Parse(a[2]) });
            }
            int startNode = int.Parse(Console.ReadLine());

            List<Node> nodes = new List<Node>();

            for (int i = 0; i < nV; i++)
            {
                nodes.Add(new Node());
            }
            for (int i = 0; i < edges.Count; i++)
            {
                nodes[edges[i][0]].neighbors.Add(new Tuple<int, int>(edges[i][1], edges[i][2]));
            }

            nodes[startNode - 1].dist = 0;
            nodes[startNode - 1].check = true;

            List<int> cyclic = new List<int>();

            for (int i = 0; i < nV ; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    if ((nodes[edges[j][0]].check) && nodes[edges[j][1]].dist > nodes[edges[j][0]].dist + edges[j][2])
                    {
                        nodes[edges[j][1]].check = true;
                        nodes[edges[j][0]].check = true;

                        if (i == nV - 1)
                        {
                            cyclic.Add(edges[j][0]);
                            cyclic.Add(edges[j][1]);
                        }
                        nodes[edges[j][1]].dist = nodes[edges[j][0]].dist + edges[j][2];
                    }
                }
            }
            /* for (int i = 0; i < nV; i++)
             {
                 for (int j = 0; j < edges.Length; j++)
                 {
                     int first = (int)edges[j][0] - 1;
                     int last = (int)edges[j][1] - 1;
                     int w = (int)edges[j][2];
                     if ((nodes[first].check) && nodes[last].dist > nodes[first].dist + w)
                     {
                         nodes[last].dist = nodes[first].dist + w;
                         nodes[last].check = true;
                     }
                 }
             }

             List<int> cyclic = new List<int>();
             for (int j = 0; j < edges.Length; j++)
             {
                 int first = (int)edges[j][0] - 1;
                 int last = (int)edges[j][1] - 1;
                 int w = (int)edges[j][2];
                 if ((nodes[first].check) && nodes[last].dist > nodes[first].dist + w)
                 {
                     nodes[last].dist = nodes[first].dist + w;
                     cyclic.Add(first);
                     cyclic.Add(last);
                 }
             }
 */
            for (int j = 0; j < cyclic.Count; j++)
            {
                Stack<Node> s = new Stack<Node>();
                s.Push(nodes[cyclic[j]]);
                Node Pnode = new Node();

                while (s.Count != 0)
                {
                    Pnode = s.Pop();
                    Pnode.NegativeCycle = true;
                    for (int i = 0; i < Pnode.neighbors.Count; i++)
                    {
                        if (!nodes[Pnode.neighbors[i].Item1].NegativeCycle)
                        {
                            s.Push(nodes[Pnode.neighbors[i].Item1]);
                            nodes[Pnode.neighbors[i].Item1].NegativeCycle = true;
                        }
                    }
                }
            }
            List<string> ans = new List<string>();
            for (int i = 0; i < nV; i++)
            {
                if (!nodes[i].check)
                {
                    Console.WriteLine("*");
                }
                else if (nodes[i].NegativeCycle)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine(nodes[i].dist);
                }
            }
        }
    }
}
