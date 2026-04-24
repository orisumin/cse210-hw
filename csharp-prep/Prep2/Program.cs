using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the percentage of your grade?");
        string input = Console.ReadLine();
        float number = float.Parse(input);

        string grade = "";
        string extra = "";

        if (number >= 90)
        {
            grade = "A";
        }
        else if (number >= 80)
        {
            grade = "B";
        }
        else if (number >= 70)
        {
            grade = "C";
        }
        else if (number >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        if (number % 10 >= 7)
        {
            extra = "+";
            if (grade == "A" || grade=="F")
            {
                extra = "";
            }
        }
        else if (number % 10 < 3)
        {
            extra = "-";
            if (grade == "F")
            {
                extra = "";
            }
        }
        Console.WriteLine($"Your grade is {grade}{extra}.");
        if (number >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}