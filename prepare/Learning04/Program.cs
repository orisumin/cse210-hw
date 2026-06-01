using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment("Samuel","Multiplication","Section 7.3", "Problems 8-19");

        Console.WriteLine(math.GetSummary());

        WritingAssignment writing = new WritingAssignment("Mary","European History","The Causes of WW2 by Mary Waters");
        Console.WriteLine(writing.GetWritingInformation());

    }
}