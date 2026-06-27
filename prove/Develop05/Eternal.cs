public class Eternal : Goal
{
    private int _GBaccumulatedNumber;
    public Eternal()
    {

    }
    public Eternal(string name, string description, int point, int number):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _GBaccumulatedNumber = number;
    }
    public void SetNumber(int number)
    {
        _GBaccumulatedNumber = number;
    }
    public int GetNumber()
    {
        return _GBaccumulatedNumber;
    }
    public int getTotalPoint()
    {
        return _GBaccumulatedNumber * GetPoint();
    }
    public override string GetGoalType()
    {
        return "Eternal";
    }

    public override string toLongString()
    {
        return $"[ ] {base.toLongString()}";
    }
    public override string toFileString()
    {
        return $"Eternal:{base.toFileString()},{_GBaccumulatedNumber}";
    }
    public override void userConstructor()
    {
        base.userConstructor();
    }
    public override string DisplayHistory()
    {
        return $"{GetName()} ({_GBaccumulatedNumber} times)";
    }

}