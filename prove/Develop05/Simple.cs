public class Simple : Goal
{
    private bool _isDoneGB;

    public Simple(string name, string description, int point):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _isDoneGB = false;
    }
    public void SetStatus(bool isdone)
    {
        _isDoneGB = isdone;
    }
    public bool GetStatus()
    {
        return _isDoneGB;
    }
    public override string toLongString()
    {

        return $"[{statusPrint()}] " +base.toLongString();
    }
    public string statusPrint()
    {
        string status = "";
        if (_isDoneGB)
        {
            status = "X";
        }
        else if (!_isDoneGB)
        {
            status = " ";
        }    
        return status;
    }
    public override string toFileString()
    {
        return $"Simple:{base.toFileString()},{statusPrint()}";
    }
}