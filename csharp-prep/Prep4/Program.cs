using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>{};
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        bool typing = true;
        do{
        Console.WriteLine("Enter number:");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        if (number == 0)
            {
                typing = false;
            }        
        numbers.Add(number);

        } while(typing);
        
        numbers.Sort();
        int sum = 0;
        float average = 0;
        int max = 0;
        int small = numbers[0];

        foreach(int number in numbers)
        {
            sum += number;
        }
        average = sum / numbers.Count;
        max = numbers[numbers.Count-1];
        
        foreach(int number in numbers)
        {
            if ()
        }

        Console.WriteLine($"The sum is:{sum}");
        Console.WriteLine($"The average is:{average}");
        Console.WriteLine($"The largest number is:{max}");
        Console.WriteLine($"The smallest positive number is:{small}");
        Console.WriteLine("The sorted list is:");
        foreach(int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}