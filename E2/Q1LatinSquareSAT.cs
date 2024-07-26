using TestCommon;

namespace E2
{
    public class Q1LatinSquareSAT : Processor
    {
        public Q1LatinSquareSAT(string testDataName) : base(testDataName)
        {
            // this.ExcludeTestCases(1, 2, 3);
            // this.ExcludeTestCaseRangeInclusive(1, 3);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<int,int?[,],string>)Solve);

        public override Action<string, string> Verifier =>
            TestTools.SatVerifier;


        public virtual string Solve(int dim, int?[,] square)
        {
            throw new NotImplementedException();
        }
    }
}
