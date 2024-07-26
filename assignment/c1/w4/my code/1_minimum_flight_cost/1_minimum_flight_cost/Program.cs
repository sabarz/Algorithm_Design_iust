using System;
using System.Collections.Generic;

namespace _1_minimum_flight_cost
{
    class nmd
    {

    }
    class priorityQ
    {
        nmd[] queue;
        int cnt;

        public priorityQ(int capacity)
        {
            queue = new nmd[capacity];
            cnt = 0;
        }
        public void Add(nmd item, double priority)
        {
            int position = cnt++;
            queue[position] = item;
            item.QueuePosition = position;
            priorities[position] = priority;
            // Move it upward into position, if necessary
            MoveUp(position);
        }

        }
        class Node
    {
        public List<Tuple<int , int>> neighbors;
        public int dist;
        public bool check;
        public int value;
        public Node(int val)
        {
            value = val;
            check = false;
            dist = int.MaxValue;
            neighbors = new List<Tuple<int, int>>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int nV = int.Parse(a[0]);
            int mE = int.Parse(a[1]);

            List<Node> nodes = new List<Node>();

            for(int i = 0; i < nV; i++)
            {
                nodes.Add(new Node(i));
            }

            for(int i = 0; i < mE; i++)
            {
                a = Console.ReadLine().Split(' ');
                nodes[int.Parse(a[0]) - 1].neighbors.Add(new Tuple<int, int>(int.Parse(a[1]) , int.Parse(a[2]);
            }

            int cnt = nV , ans = 0;

            while(cnt != 0)
            {
                for (int i = 0; i < hold.neighbors.Count; i ++)
                {
                    if(nodes[hold.neighbors[i]].dist > hold.dist + hold.edgesWeight[i])
                    {
                        nodes[hold.neighbors[i]].dist = hold.dist + hold.edgesWeight[i];
                    }
                }
                cnt--;
            }
        }
    }
}
