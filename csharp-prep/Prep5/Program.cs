using System;

class Program
{
    static void Main(string[] args)
    {
        try{
            DisplayWelcome();
            string name;
            PromptUserName(out name);
            int number;
            PromptUserNumber(out number);
            int year;
            PromtUserBirthYear(out year);
            int squared;
            SquareNumber(ref number, out squared);
            DisplayResult(name, squared, year);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Exception Occurred");
        }
        finally
        {
            Console.WriteLine("This block always executes, regardless of exceptions.");
        }
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static void PromptUserName(out string name)
    {
        Console.Write("Please enter your name:");
        name = Console.ReadLine();
    }
    static void PromptUserNumber (out int number)
    {
        Console.Write("Please enter your favorite number:");
        string input = Console.ReadLine();
        number = int.Parse(input);
    }
    static void PromtUserBirthYear(out int year)
    {
        Console.Write("Please enter the year you were born:");
        string input = Console.ReadLine();
        year = int.Parse(input);
    }
    static void SquareNumber (ref int number, out int squared)
    {
        squared = number*number;
    }
    static void DisplayResult (string name, int squared, int year)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
        Console.WriteLine($"{name}, you will turn {2026-year} this year.");
    }
}