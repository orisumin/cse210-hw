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
    public virtual string ToPartsString()
    {
        return "    1. name\n    2. email\n    3. phone\n    4.LinkedIn\n    5. address\n    6. position\n    7. organization";
    }
    public void EditProfile()
    {
        Console.WriteLine($"Please select the part you want to edit.\n{ToPartsString()}");
        bool notValid = true;
        while (notValid)
        {
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        Console.WriteLine($"What is the new name? (Current name:{_name})");
                        _name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine($"What is the new email? (Current email:{_email})");
                        _email = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine($"What is the new phone number? (Current phone number:{_phone})");
                        _phone = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine($"What is the new LinkedIn link? (Current link:{_linkedin})");
                        _linkedin = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine($"Let's set a new address! (Current address:{addressString(_address)})\n");
                        Console.Write("What is the new street address?");
                        _address["Street"] = Console.ReadLine();
                        Console.Write("Where is the new City?");
                        _address["City"] = Console.ReadLine();
                        Console.Write("Where is the new state?");
                        _address["State"] = Console.ReadLine();
                        Console.Write("What is the new ZIP code?");
                        _address["ZIPcode"] = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine($"What is the new position? (Current position:{_position})");
                        _position = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine($"What is the new campany? (Current company:{_organization})");
                        _organization = Console.ReadLine();
                        break;
                } 
                notValid = false;  
            }catch (Exception)
            {
                Console.WriteLine($"Error. Select a number from the menu.\n{ToPartsString()}");
            }
        }
    }
    public virtual void EditAttributes()
    {
        
    }
    public string ToProfileString()
    {
        return $"{_name}({_position}|{_organization})\n    email:{_email}\n    phone:{_phone}\n    LinkedIn:{_linkedin}\n    email:{_address["Street"]},{_address["City"]},{_address["State"]},{_address["ZIPcode"]}";
    }
    public virtual string ToLongString()
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