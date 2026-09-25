using System.Text;
using System.Threading.Channels;

namespace AcademyScheduleAnalyzer;
class Program
{
    static void Main(string[] args)
    {
        #region Part 1 — Starter Data

        string[] sessionNames =
        {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
        };

        DateTime[] sessionDates =
        {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
        };

        int[] sessionDurations =
        {
            180,
            240,
            180,
            240,
            180
        };

        #endregion
    }

    #region Part 2 — Display All Sessions

    static void DisplayAllSessions(string[] names, DateTime[] dates, int[] durations)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]}"
                            + $"\nDate: {dates[i]:MMMM dd yyyy}"
                            + $"\nStart Time: {TimeOnly.FromDateTime(dates[i])}"
                            + $"\nDuration: {durations[i]} minutes"
                            + $"\n");
        }
    }

    #endregion

    #region Part 3 — Search Function

    static void SearchSessionByName(string[] names, DateTime[] dates, int[] durations)
    {
        Console.WriteLine("Enter the name of the session to search for:");
        string sessionName = Console.ReadLine();

        // using Array.IndexOf to find the index of the session name in the names array
        int index = Array.IndexOf(names, sessionName);

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        Console.WriteLine($"{index + 1}. {names[index]}"
                        + $"\nDate: {dates[index]:MMMM dd yyyy}"
                        + $"\nStart Time: {TimeOnly.FromDateTime(dates[index])}"
                        + $"\nDuration: {durations[index]} minutes"
                        + $"\n");
    }

    #endregion

    #region Part 4 - Array Methods Practice

    // 4.1 Sort Session Names
    static void SortSessionsByName(string[] names)
    {
        var CopiedArrays = new string[names.Length];
        Array.Copy(names, CopiedArrays, names.Length);
        Array.Sort(CopiedArrays);


        foreach (var name in names)
            Console.WriteLine(name);  // Display original array (Not Sorted)

        Console.WriteLine();

        foreach (var name in CopiedArrays)
            Console.WriteLine(name);  // Display copied array (Sorted)
    }

    // 4.2 Reverse Session Names
    static void ReverseSessionNames(string[] names)
    {
        var CopiedArrays = new string[names.Length];
        Array.Copy(names, CopiedArrays, names.Length);
        Array.Reverse(CopiedArrays);


        foreach (var name in names)
            Console.WriteLine(name);  // Display original array (Not Reversed)

        Console.WriteLine();

        foreach (var name in CopiedArrays)
            Console.WriteLine(name);  // Display copied array (Reversed)
    }

    // 4.3 Find Session Index
    static void FindSessionIndex(string[] names)
    {
        Console.Write("Enter session name: ");
        string sessionName = Console.ReadLine();

        int index = Array.IndexOf(names, sessionName);

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        Console.WriteLine($"Index: {index}");
    }

    // 4.4 Check if a Session Exists
    static void CheckSessionExists(string[] names)
    {
        Console.Write("Enter session name: ");
        string sessionName = Console.ReadLine();

        bool exists = Array.Exists(names, x => x == sessionName);

        if (!exists)
        {
            Console.WriteLine("Session does not exist.");
            return;
        }

        Console.WriteLine("Session exists.");
    }

    // 4.5 Find a Session
    static void FindSession(string[] names)
    {
        Console.Write("Enter session name: ");
        string sessionName = Console.ReadLine();

        var session = Array.Find(names, x => x.Contains(sessionName, StringComparison.OrdinalIgnoreCase));

        if (session is null)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        Console.WriteLine(session);
    }

    // 4.6 Find a Session Index Using a Condition
    static void FindSessionIndexUsingCondition(string[] names)
    {   
        Console.Write("Enter session name: ");
        string sessionName = Console.ReadLine();
            
        int index = Array.FindIndex(names, x => x.Contains(sessionName, StringComparison.OrdinalIgnoreCase));

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        Console.WriteLine($"Index: {index}");
    }

    // 4.7 Copy an Array
    static void CopyArray(string[] names)
    {
        var CopiedArrays = new string[names.Length];
        Array.Copy(names, CopiedArrays, names.Length);

        CopiedArrays[0] = "EF Core";  // Modify the copied array

        foreach (var name in names)
            Console.WriteLine(name);  // Display original array (Not Changed)

        Console.WriteLine();

        foreach (var name in CopiedArrays)
            Console.WriteLine(name);  // Display copied array (Changed)
    }

    #endregion

    #region Part 5 - Duration Analysis
            
    static int GetTotalDuration(int[] durations)
      => durations.Sum();
    static double GetAverageDuration(int[] durations)
      => durations.Average();
    static int GetLongestDuration(int[] durations)
      => durations.Max();
    static int GetShortestDuration(int[] durations)
      => durations.Min();

    static void CopyDurations(int[] durations)
    {
        var CopiedArrays = new int[durations.Length];
        Array.Copy(durations, CopiedArrays, durations.Length);
        Array.Sort(CopiedArrays);   

        foreach (var duration in durations)
            Console.WriteLine(duration);  // Display original array (Not Sorted)

        Console.WriteLine();

        foreach (var duration in CopiedArrays)
            Console.WriteLine(duration);  // Display copied array (Sorted)
    }

    #endregion

    #region Part 6 — Functions

    // DisplaySessions, DisplaySessionDetails (Received Arrays +  Return no value using void) (implemented in Part 2)
    // SearchSession (Received Arrays +  Return no value using void)  (implemented in Part 3)
    // GetTotalDuration (Return int) (implemented in Part 3)
    // GetAverageDuration (Return double) (implemented in Part 3)
    // GetShortestDuration (Return int) (implemented in Part 3)
    // GetLongestDuration (Return int) (implemented in Part 3)

    // GetSessionEndTime (Return DateTime)
    static DateTime? GetSessionEndTime(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        Console.Write("Enter session name: ");
        string sessionName = Console.ReadLine();

        int index = Array.FindIndex(sessionNames, name => name == sessionName);
        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return null;
        }

        DateTime endTime = sessionDates[index].AddMinutes(sessionDurations[index]);
        return endTime;
    }


    // ReadSessionDate (Receive parameter)
    static void ReadSessionDate(string[] sessionNames, DateTime[] sessionDates, int index)
    {
        if (index >= 0 && index < sessionDates.Length)
        {
            Console.WriteLine($"Session: {sessionNames[index]}");
            Console.WriteLine($"Date: {sessionDates[index]:dddd, dd MMMM yyyy - hh:mm tt}");
        }
        else
            Console.WriteLine("Invalid index.");
    }

    // BuildReportUsingString (return String)
    static string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        string allSessions = "";
        for (int i = 0; i < sessionNames.Length; i++)
        {
            allSessions +=
                $"Session Name: {sessionNames[i]}" +
                $" - Session Date: {sessionDates[i]}" +
                $" - Session Duration: {sessionDurations[i].ToString()} minutes \n";
        }

        return allSessions;
    }

    // BuildReportUsingStringBuilder (return String)
    static string BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        var allSessions = new StringBuilder();
        for (int i = 0; i < sessionNames.Length; i++)
        {
            allSessions.Append($"Session Name: {sessionNames[i]}" +
                               $" - Session Date: {sessionDates[i]}" +
                               $" - Session Duration: {sessionDurations[i].ToString()} minutes \n");
        }

        return allSessions.ToString();
    }

    #endregion

    #region Part 7 - Ref and Out

    // 7.1 ref
    static void PassingByRef(ref int number) => number += 10;

    // 7.2 out
    static bool GetSessionIndexAndDuration(string sessionName, string[] sessionNames, int[] sessionDurations, out int index, out int duration)
    {
        int ind = Array.IndexOf(sessionNames, sessionName);
        if (ind == -1)
        {
            index = -1;
            duration = -1;
            return false;
        }

        index = ind;
        duration = sessionDurations[ind];
        return true;
    }

    // 7.3 Reference Type Without ref
    static void ChangeArray(int[] array) => array[0] = 100;

    #endregion

    #region Part 8 — params Keyword

    static int CalculateTotalDuration(params int[] durations)
        => durations.Sum();

    #endregion

}