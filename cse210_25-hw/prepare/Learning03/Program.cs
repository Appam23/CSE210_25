using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the different constructors

        // 1. Default constructor (creates 1/1)
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Default fraction: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");

        // 2. Whole number constructor (creates 5/1)
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"Whole number fraction: {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");

        // 3. Two parameter constructor (creates 3/4)
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"Custom fraction: {fraction3.GetFractionString()} = {fraction3.GetDecimalValue()}");

        // 4. Another fraction example (creates 1/3)
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"Another fraction: {fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");

        // Test the getter and setter methods
        Console.WriteLine("\nTesting getters and setters:");
        
        // Get current values
        Console.WriteLine($"fraction4 top: {fraction4.GetTop()}");
        Console.WriteLine($"fraction4 bottom: {fraction4.GetBottom()}");
        
        // Change the values using setters
        fraction4.SetTop(5);
        fraction4.SetBottom(7);
        Console.WriteLine($"After setting new values: {fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");
    }
}