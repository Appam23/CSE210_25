using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int userGuessNumber;

        do
        {
            Console.Write("Guess the magic number?");
            userGuessNumber = int.Parse(Console.ReadLine());

            if (userGuessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (userGuessNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Perfact!");
            }

        } while (magicNumber != userGuessNumber);

    }
}