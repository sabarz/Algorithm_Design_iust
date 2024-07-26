using System;
using System.Linq;
using System.Collections.Generic;


namespace _2_clustering
{
    class Program
    {
        class Node
        {
            public int x;
            public int y;
            public int parent;
            int value;
            int rank;
            public Node(int x, int y, int i)
            {
                this.x = x;
                this.y = y;
                parent = i;
                value = i;
                rank = 1;
            }
            public static int find(Node node, List<Node> lnodes)
            {
                while (node.parent != node.value)
                {
                    node = lnodes[node.parent];
                }
                return node.value;
            }
            public static void union(List<Node> lnodes, int f, int s)
            {
                if (lnodes[f].rank > lnodes[s].rank)
                {
                    lnodes[s].parent = f;
                    lnodes[s].rank = lnodes[f].rank;
                }
                else if (lnodes[f].rank < lnodes[s].rank)
                {
                    lnodes[f].parent = s;
                    lnodes[f].rank = lnodes[s].rank;
                }
                else
                {
                    lnodes[f].parent = s;
                    lnodes[s].rank += 1;
                }
            }
        }
        class Edge
        {
            public double dist;
            public Node srcNode;
            public Node destNode;
            public Edge(Node src, Node dest)
            {
                srcNode = src;
                destNode = dest;
                dist = Math.Sqrt(Math.Pow((src.x - dest.x), 2) + Math.Pow((src.y - dest.y), 2));
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Edge> edges = new List<Edge>();
            List<Node> nodes = new List<Node>();

            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(' ');
                nodes.Add(new Node(int.Parse(a[0]), int.Parse(a[1]), i));
            }
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    edges.Add(new Edge(nodes[i], nodes[j]));
                }
            }

            edges = edges.OrderBy(x => x.dist).ToList();
            int counter = 0;
            double ans = 0;

            for (int i = 0; i < edges.Count; i++)
            {
                int f = Node.find(edges[i].srcNode, nodes);
                int s = Node.find(edges[i].destNode, nodes);

                if (f != s)
                {
                    counter++;
                    Node.union(nodes, f, s);
                }
                if(n - counter < k)
                {
                    Console.WriteLine(edges[i].dist);
                    break;
                }
            }
        }
    }
}
