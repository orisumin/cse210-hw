using System;

class Program
{
    static void Main(string[] args)
    {
        int totalPoint = 0;
        List<Goal> goalList = new List<Goal>();
    }
    public void SaveAsFile(List<Goal> goalList)
    {
        Console.WriteLine("What is the filename for the goal file?");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter (fileName))
        {
            foreach(Goal Agoal in goalList){
                outputFile.WriteLine(Agoal.toFileString());
            }
            
        }
    }
    public void FileToList(List<Goal> currentGoalList)
    {
        bool NotValid = true;
        while(NotValid){
            Console.WriteLine("What is the filename for the goal file?");
            try{
            string filename = Console.ReadLine();
            string[] rawFile = System.IO.File.ReadAllLines(filename);
            currentGoalList.Clear();
            foreach (string line in rawFile)
                {
                    currentGoalList.Add(StringToGoal(line));
                }        
            NotValid = false;
            }catch(FileNotFoundException){
                Console.WriteLine("No file found");
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }

    }
    public Goal StringToGoal(string line)
    {
        string goalType = line.Split(":")[0];
        string detail = line.Split(":")[1];

        if (goalType == "Simple")
        {
            Simple simpleGoal = new Simple(detail.Split(",")[0],detail.Split(",")[1],int.Parse(detail.Split(",")[2]));
            if (detail.Split(",")[3] == "X")
            {
                simpleGoal.SetStatus(true);
            }
            else if (detail.Split(",")[3] == " ")
            {
                simpleGoal.SetStatus(false);
            }
            return simpleGoal;
        }
        else if (goalType == "Checklist")
        {
            Checklist checkGoal = new Checklist(detail.Split(",")[0],detail.Split(",")[1],int.Parse(detail.Split(",")[2]),int.Parse(detail.Split(",")[3]),int.Parse(detail.Split(",")[4]),int.Parse(detail.Split(",")[5]));
            return checkGoal;
        }
        else if (goalType == "Eternal")
        {
            Eternal eternalGoal = new Eternal(detail.Split(",")[0],detail.Split(",")[1],int.Parse(detail.Split(",")[2]));
            return eternalGoal;
        }else{
            Goal undefined = new Goal("Undefined","No description",0);
            return undefined;
        }
    }
    public void DisplayMenu(List<Goal> goalList){
        Console.WriteLine("Menu Option:\n    1. Create New Goal\n    2. List Goals\n    3. Save Goals\n    4. Load Goals\n    5. Record Event\n    6. Quit\nSelect a choice from the menu");
        int userinput = int.Parse(Console.ReadLine());
        switch (userinput)
        {
            case 1:
                Menu1(goalList);
                break;
            case 2:
                Menu2(goalList);
                break;
            case 3:
                Menu3(goalList);
                break;
            case 4:
                Menu4(goalList);
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }
    public void Menu1(List<Goal> goalList){
        Console.WriteLine("The types of goals are:\n    1. Simple Goal\n    2. Eternal Goal\n    3. Checklist Goal\nWhich type of goal would you like to create?");
        int userinput = int.Parse(Console.ReadLine());

        switch (userinput){
            case 1:
                Simple simple = new Simple();
                simple.userConstructor();
                goalList.Add(simple);
                break;
            case 2:
                Eternal eternal = new Eternal();
                eternal.userConstructor();
                goalList.Add(eternal);
                break;            
            case 3:
                Checklist checklist = new Checklist();
                checklist.userConstructor();
                goalList.Add(checklist);
                break;        
        }

    }
    public void Menu2(List<Goal> goalList)
    {
        Console.WriteLine("The goals are:");
        DisplayLongGoals(goalList);
        Console.WriteLine("You have 0 points.");
    }
    public void Menu3(List<Goal> goalList)
    {
        string filname = Console.ReadLine();
        SaveAsFile(goalList);
    }
    public void Menu4(List<Goal> currentGoalList)
    {
        FileToList(currentGoalList);
        Console.WriteLine("You have 0 points.");
    }
    public void Menu5(List<Goal> goalList)
    {
        Console.WriteLine("The goals are");
        DisplayShortGoals(goalList);
        Console.WriteLine("Which goal did you accomplish?");
        int userinput = int.Parse(Console.ReadLine());
        Goal accomplishedGoal = goalList[userinput];
        int point = 0;
        if (accomplishedGoal.GetGoalType() == "Simple")
        {
            accomplishedGoal.GetPoint();
        }

    }
    public void DisplayLongGoals(List<Goal> goalList)
    {
        int i = 1;
        foreach(Goal aGoal in goalList)
        {
            Console.WriteLine($"{i}. {aGoal.toLongString()}");
            i ++;            
        }
    }
    public void DisplayShortGoals(List<Goal> goalList)
    {
        int i = 1;
        foreach(Goal aGoal in goalList)
        {
            Console.WriteLine($"{i}. {aGoal.toShortString()}");
            i ++;
        }
    }

  
}