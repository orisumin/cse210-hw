using System;

class Program
{
    static void Main(string[] args)
    {
    }
    public void savefile()
    {
        string fileName = "goaltracker.txt";

        using (StreamWriter outputFile = new StreamWriter ("goaltracker.txt"))
        {
            outputFile.WriteLine("Example.");
            
        }
    }
    public void ReadFile()
    {
        string fileName = "goaltracker.txt";
        string[] lines = System.IO.File.ReadAllLines("goaltracker.txt");

        foreach (string line in lines)
        Console.Write(line);
    }

  
}