using System;
using System.Transactions;

class Program
{
    static void Main()
    {
        Console.Write("What is your name? ");

        string name = Console.ReadLine();

        Console.Write("What is your last name?");

        string lastname = Console.ReadLine();

        Console.WriteLine($"Your name is {name} {lastname}. ");
        
    }
}