using System.Security.Cryptography;

public class Goal
{
    private string _GBname;
    private string _GBdescription;
    private int _GBpoint;

    public Goal(string name, string description, int point)
    {
        _GBname = name;
        _GBdescription = description;
        _GBpoint = point;
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
}
