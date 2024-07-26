using System;
using System.Collections.Generic;

namespace _2_bipartite
{
    class Node
    {
        public List<int> neighbers;
        public bool check;
        public int group;
        public Node()
        {
            check = false;
            group = 2;
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
            Queue<int> q = new Queue<int>();
            bool ans = true;

            for (int j = 0; j < nV && ans; j++)
            {
                if (Gnodes[j].group == 2)
                {
                    q.Enqueue(j);
                    Gnodes[j].group = 0;
                    ans = true;

                    while (q.Count != 0 && ans)
                    {
                        int cnt = q.Dequeue();
                        for (int i = 0; i < Gnodes[cnt].neighbers.Count; i++)
                        {
                            if (Gnodes[Gnodes[cnt].neighbers[i]].group == 2)
                            {
                                if (Gnodes[cnt].group == 1)
                                    Gnodes[Gnodes[cnt].neighbers[i]].group = 0;
                                else
                                    Gnodes[Gnodes[cnt].neighbers[i]].group = 1;

                                q.Enqueue(Gnodes[cnt].neighbers[i]);
                            }
                            else if (Gnodes[cnt].group == Gnodes[Gnodes[cnt].neighbers[i]].group)
                            {
                                ans = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (!ans)
                Console.WriteLine(0);
            else
                Console.WriteLine(1);
        }
    }
}
