using System.Reflection.Metadata.Ecma335;

public class Breathing: Activity
{

    public Breathing()
    {
        setName("Breathing");
        setDescrip("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        setDuration(0);
    }
    public Breathing(int duration)
    {
        setName("Breathing");
        setDescrip("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        setDuration(duration);    
    }
   

    public void Session()
    {
        beginMsg();
        BreathingActivity();
        endMsg();
    }
    public void BreathingActivity()
    
    {
        DateTime now = DateTime.Now;
        DateTime future = now.AddSeconds(getDuration());
        Console.Clear();
        while (DateTime.Now <= future)
        {
            Console.WriteLine ("Breathe in...");
            DisplayCountdown(5);
            Console.Write ("Now breathe out...");
            DisplayCountdown(5);        
        }

    }}



