using System;
using System.Collections.Generic;

namespace _1_flight_segments
{
    class Node
    {
        public List<int> neighbers;
        public bool check;
        public Node()
        {
            check = false;
            neighbers = new List<int>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);

            List<Node> Gnodes = new List<Node>();

            for (int i = 0; i < nV; i++)
            {
                Gnodes.Add(new Node());
            }

            for (int i = 0; i < mE; i++)
            {
                a = Console.ReadLine().Split(' ');
                Gnodes[int.Parse(a[0]) - 1].neighbers.Add(int.Parse(a[1]) - 1);
                Gnodes[int.Parse(a[1]) - 1].neighbers.Add(int.Parse(a[0]) - 1);
            }

            a = Console.ReadLine().Split(' ');
            int u = int.Parse(a[0]) - 1;
            int v = int.Parse(a[1]) - 1;
            
            Queue<int> q = new Queue<int>();
            q.Enqueue(u);
            Gnodes[u].check = true;

            int[] level = new int[nV];

            while (q.Count != 0)
            {
                int cnt = q.Dequeue();
                for (int i = 0; i < Gnodes[cnt].neighbers.Count; i++)
                {
                    if (!Gnodes[Gnodes[cnt].neighbers[i]].check)
                    {
                        q.Enqueue(Gnodes[cnt].neighbers[i]);
                        Gnodes[Gnodes[cnt].neighbers[i]].check = true;
                        level[Gnodes[cnt].neighbers[i]] = level[cnt] + 1;
                    }
                }

                if (Gnodes[v].check)
                    break;
            }
       /*     for (int i = 0; i < nV; i++)
            {
                Console.WriteLine(level[i]);
            }*/

            if (!Gnodes[v].check)
                Console.WriteLine(-1);
                        
            else
                Console.WriteLine(level[v]);
        }
    }
}
