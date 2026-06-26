public class Checklist : Goal
{
    private int _GBgoalNumber;
    private int _GBcurrentNumber;
    private int _GBbonusPoint;

    public Checklist(string name, string description, int point, int goalNum, int bonus):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _GBgoalNumber = goalNum;
        _GBcurrentNumber = 0;
        _GBbonusPoint = bonus;
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
    public override string toLongString()
    {
        return $"[ ] {base.toLongString()} -- Currently completed: {_GBcurrentNumber}/{_GBgoalNumber}";
    }
    public override string toFileString()
    {
        return $"Cheklist:{base.toFileString()},{_GBbonusPoint},{_GBcurrentNumber},{_GBgoalNumber}";
    }
}