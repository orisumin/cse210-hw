using System;

public class Activity
{
    private string _GBname;
    private string _GBdescription;
    private int _GBduration;

    public Activity()
    {
        _GBname = "An activity";
        _GBdescription = "No description";
        _GBduration = 0;
    }
    public Activity(string name, string description)
    {
        _GBname = name;
        _GBdescription = description;
        _GBduration = 0;
    }
    public Activity(string name, string description, int duration)
    {
        _GBname = name;
        _GBdescription = description;
        _GBduration = duration;
    }

    public void setName(string name)
    {
        _GBname = name;
    }
    public void setDescrip(string description)
    {
        _GBdescription = description;
    }
    public void setDuration(int duration)
    {
        _GBduration = duration;
    }
    public string getName()
    {
        return _GBname;
    }
    public string getDescrip()
    {
        return _GBdescription;
    }
    public int getDuration()
    {
        return _GBduration;
    }

//prints out beginning messege and get a user input to set the activity's duration
    public void beginMsg()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_GBname} Activity.\n");
        Console.WriteLine(_GBdescription);
        userSetDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinner(2);
    }
// prints out ending messege
    public void endMsg()
    {
        Console.WriteLine("\nWell done!!");
        DisplaySpinner(5);
        Console.WriteLine($"You have completed another {_GBduration} seconds of {_GBname} Activity.");
        DisplaySpinner(5);
        Console.Clear();
    }
    //get int input and set it as a duration
    public void userSetDuration()
    {
        Console.Write("\nHow long, in seconds, would you like your session?");
        try{
        _GBduration = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid integer.");
        }
    }
// display countdown numbers for the set amount of time in seconds
    public void DisplayCountdown(int duration)
    {
        DateTime now = DateTime.Now;
        DateTime future = now.AddSeconds(duration);
        while (DateTime.Now <= future)
        {
            Console.Write(duration);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            duration --;
        }
        Console.WriteLine("");
    }
    // display the spinner animation for the set amount of time in seconds
    public void DisplaySpinner(int duration)
    {
        string[] spinner = new string[]
        {"|", "/", "-", @"\"};
        
        DateTime now = DateTime.Now;
        DateTime future = now.AddSeconds(duration);
        int i = 0;
        while (DateTime.Now <= future)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i ++;
            if (i >= 4)
            {
                i = 0;
            }
        }    }
}