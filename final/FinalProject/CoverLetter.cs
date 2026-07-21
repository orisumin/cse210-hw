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
            {"Street","No street"},
            {"City","No city"},
            {"State","No state"},
            {"ZIPcode","No Zip code"}
        };
        _opening = "No description";
        _second = "No description";
        _closing = "No description";
    }
    public CoverLetter(string contactName, Dictionary<string,string>contactAddress, string opening, string second, string closing)
    {
        _contactName = contactName;
        _contactAddress = contactAddress;
        _opening = opening;
        _second = second;
        _closing = closing;
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
    public override string ToPartsString()
    {
        return "    1. contact name\n    2. contact address\n    3. opening paragraph\n    4. second paragraph\n    5. closing paragraph";
    }
    public void userSetContactAddress()
    {
        Console.Write("What is the street address?");
        _contactAddress["Street"] = Console.ReadLine();
        Console.Write("What is the City?");
        _contactAddress["City"] = Console.ReadLine();
        Console.Write("Where is the state?");
        _contactAddress["State"] = Console.ReadLine();
        Console.Write("What is the Zip code?");
        _contactAddress["ZIPcode"] = Console.ReadLine();
    }
    public override void EditAttributes()
    {
        bool notValid = true;
        while (notValid)
        {
            Console.WriteLine(ToLongString());
            Console.WriteLine($"Please select the part you want to edit.\n{ToPartsString()}\n    6. Done editing.");
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        Console.WriteLine($"What is the new contact name? (Current contact name:{_contactName})");
                        _contactName = Console.ReadLine();
                        Console.WriteLine(ToLongString());
                        break;
                    case 2:
                        Console.WriteLine($"Let's set a new contact address! (Current contact address:{addressString(_contactAddress)})");
                        userSetContactAddress();
                        Console.WriteLine(ToLongString());
                        break;
                    case 3:
                        Console.WriteLine($"Let's rewrite the first paragraph. (Current paragraph:\n{_opening})");
                        _opening = Console.ReadLine();
                        Console.WriteLine(ToLongString());
                        break;
                    case 4:
                        Console.WriteLine($"Let's rewrite the second paragraph. (Current paragraph:\n{_second})");
                        _second = Console.ReadLine();
                        Console.WriteLine(ToLongString());
                        break;
                    case 5:
                        Console.WriteLine($"Let's rewrite the last paragraph. (Current paragraph:\n{_closing})");
                        _closing = Console.ReadLine();
                        Console.WriteLine(ToLongString());
                        break;
                    case 6:
                        notValid = false;
                        break;
                } 
  
            }catch (Exception)
            {
                Console.WriteLine($"Error. Select a number from the menu.\n{ToPartsString()}\n    6. Done editing.");
            }
        }
        Console.WriteLine("Well done! The change has been saved in the program.\n");
    }
    public override string ToLongString()
    {
        return $"{addressString(getAddress())}\n\n{dateString()}\n\n{addressString(_contactAddress)}\n\nDear {_contactName},\n{_opening}\n{_second}\n{_closing}\n\nSincerely,\n{getName()}\n";
    }
    public override string ToShortString()
    {
        return $"{getName()}'s Cover Letter: {getPosition()}|{getOrganization()} (Last modified:{timeString()})";
    }
    public override string ToFileString()
    {
        return $"C:{getName()}+{getEmail()}+{getPhone()}+{getLinkedin()}+{getAddress()["Street"]}+{getAddress()["City"]}+{getAddress()["State"]}+{getAddress()["ZIPcode"]}+{getPosition()}+{getOrganization()}+{dateString()}+{getStatus()}+{_contactName}+{_contactAddress["Street"]}+{_contactAddress["City"]}+{_contactAddress["State"]}+{_contactAddress["ZIPcode"]}+{_opening}+{_second}+{_closing}";
    }

}