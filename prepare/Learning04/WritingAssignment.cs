public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string name, string topic, string title):base(name, topic)
    {
        SetName(name);
        SetTopic(topic);
        _title = title;
    }
    public string GetWritingInformation()
    {
        return $"{GetName()} - {GetTopic()}\n{_title}";
    }
}