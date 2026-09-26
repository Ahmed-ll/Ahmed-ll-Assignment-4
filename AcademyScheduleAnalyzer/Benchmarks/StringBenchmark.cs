using System.Text;
using BenchmarkDotNet.Attributes;

namespace AcademyScheduleAnalyzer.Benchmarks;

[MemoryDiagnoser]
public class StringBenchmark
{
    private string[] sessionNames =
    {
        "C# Basics",
        "Arrays",
        "Functions",
        "Date and Time",
        "Exception Handling"
    };

    private DateTime[] sessionDates =
    {
        new DateTime(2026, 9, 10, 18, 0, 0),
        new DateTime(2026, 9, 13, 18, 0, 0),
        new DateTime(2026, 9, 17, 18, 0, 0),
        new DateTime(2026, 9, 20, 18, 0, 0),
        new DateTime(2026, 9, 24, 18, 0, 0)
    };

    private int[] sessionDurations =
    {
        180,
        240,
        180,
        240,
        180
    };

    #region Part 21 — BenchmarkDotNet

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";

        for (int i = 0; i < sessionNames.Length; i++)
            result += $"{sessionNames[i]}, {sessionDates[i]}, {sessionDurations[i]} minutes.\n";

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < sessionNames.Length; i++)
            result.AppendLine($"{sessionNames[i]}, {sessionDates[i]}, {sessionDurations[i]} minutes." );

        return result.ToString();
    }

    #endregion

    #region Part 24 — Benchmark Rules

    [Params(100, 1000, 10000, 100000)]
    public int Iterations;
    private const string Text = "Marks";

    [Benchmark]
    public string StringConcatenationRules()
    {
        string result = "";

        for (int i = 0; i < Iterations; i++)
            result += Text;

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenationRules()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
            result.Append(Text);

        return result.ToString();
    }

    #endregion
}