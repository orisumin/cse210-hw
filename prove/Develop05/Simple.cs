public class Simple : Goal
{
    private bool _isDoneGB;

    public Simple()
    {
        _isDoneGB = false;
    }
    public Simple(string name, string description, int point, bool isdone):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _isDoneGB = isdone;
    }
        public Simple(string name, string description, int point):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _isDoneGB = false;
    }
    public override void userConstructor()
    {
        base.userConstructor();
    }
    public void SetStatus(bool isdone)
    {
        _isDoneGB = isdone;
    }
    public bool isDone()
    {
        return _isDoneGB;
    }
    public override string GetGoalType()
    {
        return "Simple";
    }
    public override string toLongString()
    {

        return $"[{statusPrint()}] " +base.toLongString();
    }
    public string statusPrint()
    {
        if (_isDoneGB)
        {
            return "X";
        }   
        return  " ";
    }
    public override string toFileString()
    {
        return $"Simple:{base.toFileString()},{_isDoneGB}";
    }
    public int getTotalPoint()
    {
        if (_isDoneGB == true)
        {
            return GetPoint();
        }
        return 0;
    }
    public override string DisplayHistory()
    {
        int status = _isDoneGB ? 1:0;
        return $"{GetName()} ({status} times)";
    }
}