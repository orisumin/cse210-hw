using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int totalPoint = 0;
        List<Goal> goalList = new List<Goal>();
        bool playing = true;

        while (playing){
            DisplayMenu();
            (totalPoint, playing) = MenuWork(goalList, totalPoint, playing);
        }
    }
    static void SaveAsFile(List<Goal> goalList, int totalPoint)
    {
        Console.WriteLine("What is the filename for the goal file?");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter (fileName))
        {
            outputFile.WriteLine(totalPoint);

            foreach(Goal Agoal in goalList){
                outputFile.WriteLine(Agoal.toFileString());
            }
            
        }
    }
    static void FileToList(List<Goal> currentGoalList, ref int totalPoint)
    {
        bool NotValid = true;
        while(NotValid){
            Console.WriteLine("What is the filename for the goal file?");
            currentGoalList.Clear();
            try{
            string filename = Console.ReadLine();
            using (StreamReader reader = new StreamReader(filename))
                {
                    totalPoint = int.Parse(reader.ReadLine());

                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                    currentGoalList.Add(StringToGoal(currentLine));
                    }
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
    static Goal StringToGoal(string line)
    {
        string goalType = line.Split(":")[0];
        string detail = line.Split(":")[1];

        if (goalType == "Simple")
        {
            Simple simpleGoal = new Simple(detail.Split(",")[0],detail.Split(",")[1],int.Parse(detail.Split(",")[2]), bool.Parse(detail.Split(",")[3]));
            return simpleGoal;
        }
        else if (goalType == "Checklist")
        {
            Checklist checkGoal = new Checklist(detail.Split(",")[0],detail.Split(",")[1],int.Parse(detail.Split(",")[2]),bool.Parse(detail.Split(",")[3]),int.Parse(detail.Split(",")[4]),int.Parse(detail.Split(",")[5]),int.Parse(detail.Split(",")[6]));
            return checkGoal;
        }
        else if (goalType == "Eternal")
        {
            Eternal eternalGoal = new Eternal(detail.Split(",")[0],detail.Split(",")[1],int.Parse(detail.Split(",")[2]),int.Parse(detail.Split(",")[3]));
            return eternalGoal;
        }else{
            Goal undefined = new Eternal("Undefined","No description",0,0);
            return undefined;
        }
    }
    static void DisplayMenu(){
        Console.WriteLine("\nMenu Option:\n    1. Create New Goal\n    2. List Goals\n    3. Save Goals\n    4. Load Goals\n    5. Record Event\n    6. Goal History\n    7. Quit\nSelect a choice from the menu");
    }
    static (int totalPoint, bool playing) MenuWork(List<Goal> goalList, int totalPoint, bool playing){
        bool NotValid = true;
        while (NotValid){
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        Menu1(goalList);
                        break;
                    case 2:
                        Menu2(goalList, totalPoint);
                        break;
                    case 3:
                        Menu3(goalList, totalPoint);
                        break;
                    case 4:
                        totalPoint = Menu4(goalList, totalPoint);
                        break;
                    case 5:
                        totalPoint = Menu5(goalList, totalPoint);
                        break;
                    case 6:
                        Menu6(goalList);
                        break;
                    case 7:
                        playing = false;
                        break;
                }
                NotValid = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }
        return (totalPoint, playing);
    }
    static void Menu1(List<Goal> goalList){
        int userinput = 0;
        bool NotValid = true;
        while (NotValid)
        {
            try
            {
                Console.WriteLine("The types of goals are:\n    1. Simple Goal\n    2. Eternal Goal\n    3. Checklist Goal\nWhich type of goal would you like to create?");
                userinput = int.Parse(Console.ReadLine());
                if (userinput>=1 && userinput <=3)
                {
                    NotValid = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }
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
    static void Menu2(List<Goal> goalList, int totalPoint)
    {
        Console.WriteLine("The goals are:");
        DisplayLongGoals(goalList);
        Console.WriteLine($"You have {totalPoint} points.");
    }
    static void Menu3(List<Goal> goalList, int totalPoint)
    {
        SaveAsFile(goalList, totalPoint);
    }
    static int Menu4(List<Goal> currentGoalList, int totalPoint)
    {
        FileToList(currentGoalList, ref totalPoint);
        Console.WriteLine($"You have {totalPoint} points.");
        return totalPoint;
    }
    static int Menu5(List<Goal> goalList, int totalPoint)
    {
        Console.WriteLine("The goals are");
        DisplayShortGoals(goalList);
        Console.WriteLine("Which goal did you accomplish?");
        int userinput = int.Parse(Console.ReadLine());
        Goal accomplishedGoal = goalList[userinput-1];
        switch (accomplishedGoal.GetGoalType())
        {
            case "Simple":
                Simple simple = (Simple)accomplishedGoal;
                if (!simple.isDone())
                {
                totalPoint += simple.GetPoint();
                Console.WriteLine($"Congratulations! You have earned {simple.GetPoint()} points."); 
                simple.SetStatus(true);
                break;       
                }
                Console.WriteLine("This goal is already accomplished");
                break;
            case "Eternal":
                Eternal eternal = (Eternal)accomplishedGoal;
                totalPoint += eternal.GetPoint();
                eternal.SetNumber(eternal.GetNumber()+1);
                Console.WriteLine($"Congratulations! You have earned {accomplishedGoal.GetPoint()} points.");
                break;
            case "Checklist":
                Checklist checklistGoal = (Checklist)accomplishedGoal;
                if (checklistGoal.GetCurrentNum() < checklistGoal.getGoalNum())
                {                
                    checklistGoal.SetCurrentNum(checklistGoal.GetCurrentNum() + 1);
                    totalPoint += checklistGoal.GetPoint();
                    Console.WriteLine($"Congratulations! You have earned {accomplishedGoal.GetPoint()} points.");
                    if (checklistGoal.GetCurrentNum() == checklistGoal.getGoalNum())
                    {
                        totalPoint += checklistGoal.GetBonus();
                        checklistGoal.SetStatus(true);
                        Console.WriteLine($"You earned {checklistGoal.GetBonus()} bonus points.");
                    }
                }else{
                    Console.WriteLine("This goal is already accomplished");
                }
                break;
        }
        Console.WriteLine($"You have {totalPoint} points.");
        return totalPoint;

    }
    static void Menu6(List<Goal> goalList){
        //
        int i = 1;
        foreach(Goal Agoal in goalList)
        {
            Console.WriteLine($"{i}. {Agoal.DisplayHistory()}");
            i++;
        }
    }
    static void DisplayLongGoals(List<Goal> goalList)
    {
        int i = 1;
        foreach(Goal aGoal in goalList)
        {
            Console.WriteLine($"{i}. {aGoal.toLongString()}");
            i ++;            
        }
    }
    static void DisplayShortGoals(List<Goal> goalList)
    {
        int i = 1;
        foreach(Goal aGoal in goalList)
        {
            Console.WriteLine($"{i}. {aGoal.toShortString()}");
            i ++;
        }
    }

  
}