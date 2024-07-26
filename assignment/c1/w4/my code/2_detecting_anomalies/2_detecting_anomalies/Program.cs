using System;
using System.Collections.Generic;

namespace _2_detecting_anomalies
{
    class Program
    {
        class Node
        {
            public double dist;
            public bool check;
            public Node()
            {
                check = false;
                dist = double.PositiveInfinity;
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
            List<Node> nodes = new List<Node>();

            for (int i = 0; i < nV; i++)
            {
                nodes.Add(new Node());
            }
            bool hi = false;

            for (int s = 0; !hi && s < nV; s++)
            {
                if (!nodes[s].check)
                {
                    nodes[s].dist = 0;
                    nodes[s].check = true;

                    for (int i = 0;!hi && i < nV; i++)
                    {
                        for (int j = 0; j < edges.Count; j++)
                        {
                            if ((nodes[edges[j][0]].check) && nodes[edges[j][1]].dist > nodes[edges[j][0]].dist + edges[j][2])
                            {
                                if (i == nV - 1)
                                {
                                    hi = true;
                                    break;
                                }               
                                nodes[edges[j][1]].dist = nodes[edges[j][0]].dist + edges[j][2];
                                nodes[edges[j][1]].check = true;
                            }
                        }
                    }
                }
            }

/*
            for (int j = 0; !hi && j < edges.Count; j++)
            {
                int first = edges[j][0];
                int last = edges[j][1];
                int w = edges[j][2];
                if ((nodes[first].check) && nodes[last].dist > nodes[first].dist + w)
                {
                    nodes[last].dist = nodes[first].dist + w;
                    nodes[last].check = true;
                    hi = true;
                }
            }*/


            if (!hi)
                Console.WriteLine(0);
            else
                Console.WriteLine(1);
        }
    }
}
