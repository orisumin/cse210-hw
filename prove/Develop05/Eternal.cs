public class Eternal : Goal
{
    public Eternal(string name, string description, int point):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
    }
    public override string toLongString()
    {
        return $"[ ] {base.toLongString()}";
    }
    public override string toFileString()
    {
        return $"Eternal:{base.toFileString()}";
    }
    
}