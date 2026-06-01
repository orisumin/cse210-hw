using System.Runtime.InteropServices;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string name, string topic)
    {
        _studentName = name;    
        _topic = topic;
    }
    public void SetName(string name)
    {
        _studentName = name;
    }
    public void SetTopic(string topic)
    {
        _topic = topic;
    }
    public string GetName()
    {
        return _studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}