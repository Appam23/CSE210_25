using System;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number (0-100): ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        string grade;   
        if (number >= 90 && number <= 100)
        {
            grade = "A";
        }
        else if (number >= 80 && number < 90)
        {
            grade = "B";
        }
        else if (number >= 70 && number < 80)
        {
            grade = "C";
        }
        else if (number >= 60 && number < 70)
        {
            grade = "D";
        }
        else if (number >= 0 && number < 60)
        {
            grade = "F";
        }
        else
        {
            grade = "Invalid input. Please enter a number between 0 and 100.";
        }

        Console.WriteLine($"Your grade is: {grade}");
    }
}