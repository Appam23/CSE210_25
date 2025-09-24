using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> number = new List<int>();
        int input;
        Console.WriteLine("Enter a number(0 to stop):");

        do
        {
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                number.Add(input);
            }
        } while (input != 0);
        Console.WriteLine("\nYou entered:");
        foreach (int num in number)
        {
            Console.WriteLine(num);
        }
        // compute the sum
        int sum = 0;
        foreach (int n in number)
        {
            sum += n; // add each number to the sum
        }
        Console.WriteLine($"\nThe total sum is: {sum}");

        //compute average
        if (number.Count > 0)
        {
            double average = (double)sum / number.Count;
            Console.WriteLine($"The Average is: {average}");

            // find maximum in the list
            int max = number[0]; // start with the first number
            foreach (int n in number)
            {
                if (n > max)

                    max = n; // update if we find a bigger number
            }

            Console.WriteLine($"The Largest number is: {max}");

        }
        else
        {
            Console.WriteLine("No number entered, so no average or largest number.");
        }
    }
}
