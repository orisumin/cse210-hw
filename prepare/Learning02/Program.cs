using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        job1._title = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._title = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);
        job1.Display();
        job2.Display();

        Resume resume1 = new Resume();
        resume1._name = "Allison Rose";
        resume1._jobs = [job1, job2];
        resume1.Display();
    }
}


public class Resume
{
    public string _name;
    public List<Job> _jobs;
    
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}