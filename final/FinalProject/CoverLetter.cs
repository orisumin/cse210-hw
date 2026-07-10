using System.Globalization;

public class CoverLetter : Document
{
    private string _contactName;
    private Dictionary<string, string> _contactAddress;
    private string _opening;
    private string _second;
    private string _closing;

    public CoverLetter()
    {
        _contactName = "No contact";
        _contactAddress = new Dictionary<string, string>
        {
            {"Street","No description"},
            {"City","No description"},
            {"State","No description"},
            {"ZIPcode","No description"}
        };
        _opening = "No description";
        _second = "No description";
        _closing = "No description";
    }
    public void setContactName(string name)
    {
        _contactName = name;
    }
    public void setContactAddress(Dictionary<string, string> address)
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
    public Dictionary<string,string> getContactAddress()
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
    public override string ToLongString(string name, string email, string phone, string linkedin, string position, DateTime date)
    {
        return $"{name}\n{email}-{phone}-{linkedin}\n{addressString(getAddress())}\n{dateString()}\n{addressString(_contactAddress)}\n\n Dear {_contactName},\n{_opening}\n{_second}\n{_closing}\n\nSincerely,\n{getName()}";
    }
    public override string ToShortString()
    {
        return $"{getName()}'s Cover Letter: {getPosition()}|{getOrganization()} (Last modified:{timeString()})";
    }
    public override string ToFileString()
    {
        return $"C:{_contactName},{getOrganization()},{_contactAddress["Street"]},{_contactAddress["City"]},{_contactAddress["State"]},{_contactAddress["ZIPcode"]},{_opening},{_second},{_closing}";
    }

}