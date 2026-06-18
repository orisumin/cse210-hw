using System;

class Program
{
    static void Main(string[] args)
    {
        var log = new Dictionary<string, int>(){
            {"breathing",0},
            {"reflecting",0},
            {"listing",0}
        };
        
        bool playing = true;
        while (playing)
        {
            DisplayMenu();
            playing = ChooseAnum(log);
        }
    }
    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options\n   1. Start breathging activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. See the log\n   5. Quit\nSelect a choice from the menu:");
    }

    /// <summary>
    /// This function receives user input and calls the activities. It also records the activities done while the program is running 
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    public static bool ChooseAnum(Dictionary<string,int> log)
    {
        Breathing breathing = new Breathing();
        Reflecting reflecting = new Reflecting();
        Listing listing = new Listing();

        int userInput = int.Parse(Console.ReadLine());  
        switch (userInput)
            {
                case 1:
                    breathing.Session();
                    log["breathing"] ++;
                    return true;
                case 2:
                    reflecting.Session();
                    log["reflecting"] ++;
                    return true;
                case 3:
                    listing.Session();
                    log["listing"] ++;
                    return true;
                case 4:
                    Console.WriteLine("");
                    foreach(var entry in log){
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                    }
                    Console.WriteLine("");
                    return true;
                case 5:
                    Console.WriteLine("Thanks for playing!");
                    return false;
                default:
                    Console.WriteLine("Please enter a valid menu number.");
                    return true;
            }
        
    }
}
