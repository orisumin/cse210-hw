using System;
using System.IO;

class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // string fileName = "Jokes.txt";
        // using (StreamWriter outputJokes = new StreamWriter(fileName))
        // {
        //     outputJokes.WriteLine("This will be the first line in the file.");

        //     string color = "blue";
        //     outputJokes.WriteLine($"my favorite color is {color}");
        // }

        string readJoke = "readJokes.txt";
        string[] lines = System.IO.File.ReadAllLines(readJoke);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
            
        }

    }
}