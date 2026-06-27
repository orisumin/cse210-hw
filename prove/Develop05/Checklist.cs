using System.Data;

public class Checklist : Goal
{
    private bool _isDoneGB;
    private int _GBgoalNumber;
    private int _GBcurrentNumber;
    private int _GBbonusPoint;
    public Checklist()
    {
        _GBgoalNumber = 0;
        _GBcurrentNumber = 0;
        _GBbonusPoint = 0;
        _isDoneGB = false;
    }
    public Checklist(string name, string description, int point, bool isdone, int bonus, int currentNum, int goalNum):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _isDoneGB = false;
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
            Console.WriteLine("What is the bonus for accomplishing it that many times?");
            _GBbonusPoint = int.Parse(Console.ReadLine());
            NotValid = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }
    }
    public void SetStatus(bool isdone)
    {
        _isDoneGB = isdone;
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
    public bool isdone()
    {
        return _isDoneGB;
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
    public override string GetGoalType()
    {
        return "Checklist";
    }

    public override int getGoalNum()
    {
        return _GBgoalNumber;
    }
    public string statusPrint()
    {
        if (_isDoneGB)
        {
            return "X";
        }   
        return  " ";
    }

    public override string toLongString()
    {
        return $"[{statusPrint()}] {base.toLongString()} -- Currently completed: {_GBcurrentNumber}/{_GBgoalNumber}";
    }
    public override string toFileString()
    {
        return $"Cheklist:{base.toFileString()},{_isDoneGB},{_GBbonusPoint},{_GBcurrentNumber},{_GBgoalNumber}";
    }
    public int getTotalPoint()
    {
        if (_GBcurrentNumber < _GBgoalNumber && _GBcurrentNumber !=0)
        {
            return GetPoint()*_GBcurrentNumber;
        }
        else if (_GBcurrentNumber == _GBgoalNumber)
        {
            return GetPoint()*_GBcurrentNumber + _GBbonusPoint;
        }
        else
        {
            return 0;
        }
        
    }
    public override string DisplayHistory()
    {
        return $"{GetName()} ({_GBcurrentNumber} times)";
    }

}