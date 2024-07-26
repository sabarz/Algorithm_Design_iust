using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;


namespace E1
{
    public class Q1SecondMST : Processor
    {
        public Q1SecondMST(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);


        public long Solve(long nodeCount, long[][] edges)
        {
            throw new NotImplementedException();

        }

    }
}
