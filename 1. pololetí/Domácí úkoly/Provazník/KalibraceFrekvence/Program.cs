using System;
using BenchmarkDotNet.Running;

namespace KalibraceFrekvence
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarked>();
        }
    }
}
