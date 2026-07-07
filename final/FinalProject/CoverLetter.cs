public class CoverLetter : Document
{
    private string _contactName;
    private string _contactOrganization;
    private List<string> _contactAddress;
    private string _opening;
    private string _second;
    private string _closing;

    public CoverLetter()
    {
        _contactName = "No contact";
        _contactOrganization = "No organization";
        _contactAddress = ["No address"];
        _opening = "No description";
        _second = "No description";
        _closing = "No description";
    }
    public void setContactName(string name)
    {
        _contactName = name;
    }
    public void setOrganization(string organization)
    {
        _contactOrganization = organization;
    }
    public void setAddress(List<string> address)
    {
        _contactAddress = address;
    }
    public void setOpening(string opening)
    {
        _opening = opening;
    }
    public void setSecond(string second)
    {
        _second = second;
    }
    public void setClosing(string closing)
    {
        _closing = closing;
    }
    public string getContactName()
    {
        return _contactName;
    }
    public string getOrganization()
    {
        return _contactOrganization;
    }
    public List<string> getAddress()
    {
        return _contactAddress;
    }
    public string getOpening()
    {
        return _opening;
    }
    public string getSecond()
    {
        return _second;
    }
    public string getClosing()
    {
        return _closing;
    }
}