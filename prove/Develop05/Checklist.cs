public class Checklist : Goal
{
    private int _GBgoalNumber;
    private int _GBcurrentNumber;
    private int _GBbonusPoint;
    public Checklist()
    {
        _GBgoalNumber = 0;
        _GBcurrentNumber = 0;
        _GBbonusPoint = 0;
    }
    public Checklist(string name, string description, int point, int bonus, int currentNum, int goalNum):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _GBgoalNumber = goalNum;
        _GBcurrentNumber = currentNum;
        _GBbonusPoint = bonus;
    }
    public override void userConstructor()
    {
        base.userConstructor();
        
        bool NotValid = true;
        while (NotValid)
        {
            try
            {
            Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
            _GBgoalNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("What it the bonus for accomplishing it that many times?");
            _GBbonusPoint = int.Parse(Console.ReadLine());
            NotValid = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }
    }
    public void SetGoalNum(int goalNum)
    {
        _GBgoalNumber = goalNum;
    }
    public void SetCurrentNum(int currNum)
    {
        _GBcurrentNumber = currNum;
    }
    public void SetBonus(int bonus)
    {
        _GBbonusPoint = bonus;
    }
    public int GetGoalNum()
    {
        return _GBgoalNumber;
    }
    public int GetCurrentNum()
    {
        return _GBcurrentNumber;
    }
    public int GetBonus()
    {
        return _GBbonusPoint;
    }
    public string GetGoalType()
    {
        return "Checklist";
    }

    public override string toLongString()
    {
        return $"[ ] {base.toLongString()} -- Currently completed: {_GBcurrentNumber}/{_GBgoalNumber}";
    }
    public override string toFileString()
    {
        return $"Cheklist:{base.toFileString()},{_GBbonusPoint},{_GBcurrentNumber},{_GBgoalNumber}";
    }
}