namespace Prep2
{
    using System;

class Program
{
    static void Main()
    {
        // Ask the user for their numeric grade
        Console.Write("Enter your numeric grade (0-100): ");
        string input = Console.ReadLine();

        // Convert the input to an integer
        int grade = int.Parse(input);

        // Determine the letter grade using if-else statements
        string letterGrade;

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Display the result
        Console.WriteLine($"Your letter grade is: {letterGrade}");
    }
}

}