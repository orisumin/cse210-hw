public class Listing:Activity
{
    private List<string> _GBprompts = new List<string>
    {
        "Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"
    };
    private List<string> _GBuserResponses =new List<string>();

    public Listing()
    {
        setName("Listing");
        setDescrip("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        setDuration(0);
    }
    public Listing(int duration)
    {
        setName("Listing");
        setDescrip("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        setDuration(duration);
    }
    public void setPrompts(List<string>prompts)
    {
        _GBprompts = prompts;
    }
    public void setResponse(List<string>reponses)
    {
        _GBuserResponses = reponses;
    }
    public List<string> getPrompts()
    {
        return _GBprompts;
    }
    public List<string> getResponses()
    {
        return _GBuserResponses;
    }

    public void Session()
    {
        beginMsg();
        Console.WriteLine("List as many responses you can to the following prompt:");
        displayAprompt();
        Console.Write("You many begin in: ");
        DisplayCountdown(5);
        DateTime now = DateTime.Now;
        while (DateTime.Now <= now.AddSeconds(getDuration())){
            userInputs();
        }
        Console.WriteLine($"\nYou listed {countResponses()} items!");
        endMsg();
    }
    public void displayAprompt(){
        Random GBrnd = new Random();
        int rdNum = GBrnd.Next(0,_GBprompts.Count()-1);
        Console.WriteLine($"---{_GBprompts[rdNum]}---");
    }
    public void userInputs()
    {
        DateTime now = DateTime.Now;
        DateTime future = now.AddSeconds(getDuration());
        while (DateTime.Now <= future){
            Console.Write("> ");
            string response = Console.ReadLine();
            _GBuserResponses.Add(response);
        }
    }
    public int countResponses()
    {
        return _GBuserResponses.Count();
    }
}