public class Document
{
    private string _name;
    private string _email;
    private string _phone;
    private string _linkedin;
    private Dictionary<string,string> _address;
    private string _position;
    private string _organization;
    private DateTime _date;
    private bool _isHired;

    public Document()
    {
        _name = "No name";
        _email = "No email";
        _phone = "No number";
        _linkedin = "No address";
        _address = new Dictionary<string, string>
        {
            {"Street","No description"},
            {"City","No description"},
            {"State","No description"},
            {"ZIPcode","No description"}
        };
        _position = "No position";
        _organization = "No organization";
        _date = DateTime.Now;
        _isHired = false;
    }
     public Document(string name, string email, string phone, string linkedin, Dictionary<string, string>address, string position, string organization, bool status)
    {
        _name = "No name";
        _email = "No email";
        _phone = "No number";
        _linkedin = "No address";
        _address = new Dictionary<string, string>
        {
            {"Street","No description"},
            {"City","No description"},
            {"State","No description"},
            {"ZIPcode","No description"}
        };
        _position = "No position";
        _organization = "No organization";
        _date = DateTime.Now;
        _isHired = false;
    }
    public void setName(string name)
    {
        _name = name;
        _date = DateTime.Now;
    }
    public void setEmail(string email)
    {
        _email = email;
        _date = DateTime.Now;
    }
    public void setPhone(string number)
    {
        _phone = number;
        _date = DateTime.Now;
    }
    public void setLinkedin(string linkedin)
    {
        _linkedin = linkedin;
        _date = DateTime.Now;
    }
    public void setAddress(Dictionary<string, string> address)
    {
        _address = address;
        _date = DateTime.Now;
    }
    public void setPosition(string positionName)
    {
        _position = positionName;
        _date = DateTime.Now;
    }
    public void setOrganization(string name)
    {
        _organization = name;
        _date = DateTime.Now;
    }
    public void setDate(DateTime date)
    {
        _date = date;
        _date = DateTime.Now;
    }
    public void setStatus(bool status)
    {
        _isHired = status;
        _date = DateTime.Now;
    }
    public string getName()
    {
        return _name;
    }
    public string getEmail()
    {
        return _email;
    }
    public string getPhone()
    {
        return _phone;
    }
    public string getLinkedin()
    {
        return _linkedin;
    }
    public Dictionary<string, string> getAddress()
    {
        return _address;
    }
    public string getPosition()
    {
        return _position;
    }
    public string getOrganization()
    {
        return _organization;
    }
    public DateTime getDate()
    {
        return _date;
    }
    public bool getStatus()
    {
        return _isHired;
    }
    public string dateString()
    {
        return _date.ToString("MMMM dd, yyyy");
    }
    public string timeString()
    {
        return _date.ToString("MM-dd-yyyy HH");
    }

    public string addressString(Dictionary<string,string>address)
    {
        return $"{address["Street"]}\n{address["City"]},{address["State"]},{address["ZIPcode"]}";
    }
    public virtual string ToLongString(string name, string email, string phone, string linkedin, string position, DateTime date)
    {
        return "";
    }
    public virtual string ToShortString()
    {
        return $"{_name}'s Document: {_position}|{_organization} (Last modified:{timeString()})";
    }
    public virtual string ToFileString()
    {
        return $"D:{_name}+{_email}+{_phone}+{_linkedin}+{_address["Street"]}+{_address["City"]}+{_address["State"]}+{_address["ZIPcode"]}+{_position}+{_organization}+{dateString()}+{_isHired}";
    }
}