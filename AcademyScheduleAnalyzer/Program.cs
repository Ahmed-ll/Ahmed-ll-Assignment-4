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

}