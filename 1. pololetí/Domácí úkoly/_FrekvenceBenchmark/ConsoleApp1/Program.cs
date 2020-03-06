using System;
using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
            
            // var b = new Benchmark();
            // b.Flajzik();
            // b.Radikovska();
            // b.Vaclavek();
            // b.Jarrahova();
            // b.Provaznik();
            // b.Reichl();
        }
    }
}
