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

}