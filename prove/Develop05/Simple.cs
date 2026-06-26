public class Simple : Goal
{
    private bool _isDone;

    public Simple(string name, string description, int point):base(name, description, point)
    {
        SetName(name);
        SetDescription(description);
        SetPoint(point);
        _isDone = false;
    }
    public void SetStatus(bool isdone)
    {
        _isDone = isdone;
    }
    public bool GetStatus()
    {
        return _isDone;
    }
}