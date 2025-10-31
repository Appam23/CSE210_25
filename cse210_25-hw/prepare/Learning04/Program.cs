using System;

class Program
{
    static void Main(string[] args)
    {
        Math math = new Math("Appam", "Fractions", "7.3", "8-19");
        History history = new History("Appam", "World War II", "The Causes of WWII");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(history.GetSummary());
    }
}