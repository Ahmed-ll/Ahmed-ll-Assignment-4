using BenchmarkDotNet.Attributes;

namespace AcademyScheduleAnalyzer.Benchmarks;

#region Part 23 — Benchmark Memory Usage
[MemoryDiagnoser]
#endregion 
public class LoopBenchmark
{
    #region Part 22 — Benchmark Different Loop Sizes

    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark]
    public void ForLoop()
    {
        for (int i = 0; i < Iterations; i++) { }
    }

    [Benchmark]
    public void WhileLoop()
    {
        int i = 0;
        while (i < Iterations) i++;
    }

    #endregion
}
