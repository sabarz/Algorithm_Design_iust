using System;
using System.Collections.Generic;

namespace _2_Construct_SuffixArray_LongString
{
    class Program
    {
        public static long[] sortChars(string text)
        {
            int n = text.Length;
            long[] order = new long[n];
            Dictionary<char, int> count = new Dictionary<char, int>();
            count['A'] = 0;
            count['C'] = 0;
            count['G'] = 0;
            count['T'] = 0;
            count['$'] = 0;

            for (int i = 0; i < n; i++)
            {
                count[text[i]] += 1;
            }

            count['A'] += count['$'];
            count['C'] += count['A'];
            count['G'] += count['C'];
            count['T'] += count['G'];

            for (int i = n - 1; i >= 0; i--)
            {
                count[text[i]] -= 1;
                order[count[text[i]]] = i;
            }

            return order;
        }

        public static long[] computecharclasses(string text, long[] order)
        {
            int n = text.Length;
            long[] classes = new long[n];

            classes[order[0]] = 0;

            for (int i = 1; i < text.Length; i++)
            {
                if (text[(int)order[i]] != text[(int)order[i - 1]])
                {
                    classes[order[i]] = classes[order[i - 1]] + 1;
                }
                else
                {
                    classes[order[i]] = classes[order[i - 1]];
                }
            }

            return classes;
        }

        public static long[] sortDoubled(string text, int x, long[] order, long[] classes)
        {
            int n = text.Length;
            long[] count = new long[n];
            for (int i = 0; i < n; i++)
            {
                count[i] = 0;
            }
            long[] neworder = new long[n];

            for (int i = 0; i < n; i++)
            {
                count[classes[i]] += 1;
            }
            for (int i = 1; i < n; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int start = ((int)order[i] - x + n) % n;

                count[classes[start]] -= 1;
                neworder[count[classes[start]]] = start;
            }

            return neworder;
        }
        public static long[] updateClass(long[] neworder, long[] classes, int x)
        {
            int n = neworder.Length;
            long[] newclasses = new long[n];
            newclasses[neworder[0]] = 0;

            for (int i = 1; i < n; i++)
            {
                long cur = neworder[i];
                long prev = neworder[i - 1];
                long mid = cur + x;
                long midprev = (prev + x) % n;
                if (classes[cur] != classes[prev] || classes[mid] != classes[midprev])
                {
                    newclasses[cur] += newclasses[prev] + 1;
                }
                else
                {
                    newclasses[cur] += newclasses[prev];
                }
            }

            return newclasses;
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            long[] order = new long[text.Length];
            long[] classes = new long[text.Length];

            order = sortChars(text);
            classes = computecharclasses(text, order);

            int x = 1;

            while (x < text.Length)
            {
                order = sortDoubled(text, x, order, classes);
                classes = updateClass(order, classes, x);

                x *= 2;
            }

            foreach(int i in order)
            {
                Console.Write(i + " ");
            }
        }
    }
}
