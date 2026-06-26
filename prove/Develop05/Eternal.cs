public class Eternal : Goal
{
    public Eternal()
    {

    }
    public Eternal(string name, string description, int point):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
    }
    public string GetGoalType()
    {
        return "Eternal";
    }

    public override string toLongString()
    {
        return $"[ ] {base.toLongString()}";
    }
    public override string toFileString()
    {
        return $"Eternal:{base.toFileString()}";
    }
    public override void userConstructor()
    {
        base.userConstructor();
    }
    
}