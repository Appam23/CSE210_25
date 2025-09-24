using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int birthYear;
        PromptUserBirthYear(out birthYear);
        int numberToSquare = PromptNumberToSquare();
        int squaredNumber = SquareNumber(numberToSquare);
        DisplayResult(userName, squaredNumber, birthYear);
        //Console.WriteLine($"\nHello {userName}. Nice to meet you! Your favorite number is {favoriteNumber}.");
       Console.WriteLine($"Dear Appam the square of the {numberToSquare} is {squaredNumber}."); 
    }

    static void DisplayWelcome()
    {


        Console.WriteLine("Welcome to the Programe!!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name:");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number:");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter the year you were born:");
        year = int.Parse(Console.ReadLine());
    }
    static int PromptNumberToSquare()
    {
        Console.Write("Enter the number to square:");
        int num = int.Parse(Console.ReadLine());
        return num;
    }
    static int SquareNumber(int num)
    {
        return num * num;
    }
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        
        Console.WriteLine($"You were born in {birthYear}.");
        
        int currentYear = DateTime.Now.Year;
        int agethisYear = currentYear - birthYear;

        Console.WriteLine($"My friend you will turn {agethisYear} year old this year.");

    }

}