using System.Security.Cryptography;

public abstract class Goal
{
    private string _GBname;
    private string _GBdescription;
    private int _GBpoint;

    public Goal()
    {
        _GBname = "Undefined";
        _GBdescription = "No description";
        _GBpoint = 0;
    }
    public Goal(string name, string description, int point)
    {
        _GBname = name;
        _GBdescription = description;
        _GBpoint = point;
    }
    public virtual void userConstructor()
    {
        bool NotValid = true;
        while(NotValid){
            try
            {
            Console.WriteLine("What is the name of your goal?");
            _GBname = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            _GBdescription = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal?");
            _GBpoint = int.Parse(Console.ReadLine());
            NotValid = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format");
            }catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }
    }
    public void SetName(string name)
    {
        _GBname = name;
    }
    public void SetDescription(string description)
    {
        _GBdescription = description;
    }
    public void SetPoint(int point)
    {
        _GBpoint = point;
    }
    public string GetName()
    {
        return _GBname;
    }
    public string GetDescription()
    {
        return _GBdescription;
    }
    public int GetPoint()
    {
        return _GBpoint;
    }
    public virtual string GetGoalType()
    {
        return "None";
    }
    public virtual int getGoalNum()
    {
        return 0;
    }
    public virtual string toLongString()
    {
        return $"{_GBname} ({_GBdescription})";
    }
    public string toShortString()
    {
        return $"{_GBname}";
    }
    public virtual string toFileString()
    {
        return $"{_GBname},{_GBdescription},{_GBpoint}";
    }
    public abstract string DisplayHistory();
}
