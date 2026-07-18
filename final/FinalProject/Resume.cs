public class Resume : Document
{
    private string _summary;
    private Dictionary<string,List<string>> _education;
    private Dictionary<string,List <string>> _experience;
    private List<string> _skills;

    public Resume()
    {
        _summary = "No summary";
        _education = new Dictionary<string, List<string>>{
           {"School",["No description"]},
           {"Degree",["No description"]},
           {"Period",["No description"]},
           {"Location",["No description"]},
           {"Description",["No description"]}
        };
        _experience = new Dictionary<string, List<string>>
        {
           {"Company",["No description"]},
           {"Position",["No description"]},
           {"Period",["No description"]},
           {"Location",["No description"]},
           {"Description",["No description"]}            
        };
        _skills = ["No skills"];
    }
    public void setSummary(string summary)
    {
        _summary = summary;
    }
    public void setEducation(Dictionary<string, List<string>> education)
    {
        _education = education;
    }
    public void setASchool(string schoolName)
    {
        _education["Shool"].Add(schoolName);
    }
    public void setADgree(string degree)
    {
        _education["Degree"].Add(degree);
    }
    public void setAEdPeriod(string period)
    {
        _education["Period"].Add(period);
    }
    public void setAEdLocation(string location)
    {
        _education["Location"].Add(location);
    }
    public void setAEdDescription(string description)
    {
        _education["Description"].Add(description);
    }
    public void setACompany(string companyName)
    {
        _experience["Company"].Add(companyName);
    }
    public void setAPosition(string position)
    {
        _experience["Position"].Add(position);
    }
    public void setAExPeriod(string period)
    {
        _experience["Period"].Add(period);
    }
    public void setAExLocation(string location)
    {
        _experience["Location"].Add(location);
    }
    public void setAExDescription(string description)
    {
        _experience["Description"].Add(description);
    }
    public void setExperience(Dictionary<string, List<string>> experience)
    {
        _experience = experience;
    }
    public void setSkills(List<string> skills)
    {
        _skills = skills;
    }
    public void setASkill(string skill)
    {
        _skills.Add(skill);
    }
    public string getSummary()
    {
        return _summary;
    }
    public Dictionary<string,List<string>> getEducation()
    {
        return _education;
    }
    public Dictionary<string,List<string>> getExperience()
    {
        return _experience;
    }
    public List<string> getSkills()
    {
        return _skills;
    }
    public string educationFileString()
    {
        string fileFormat="";
        foreach (List<string> list in _education.Values)
        {
            string listComplied = "";
            foreach (string element in list)
            {
                if(element == list[list.Count - 1])
                {
                    listComplied += element;
                }
                else
                {
                    listComplied += element+"|";
                }
            }        
            fileFormat += listComplied +"+";
        }
        return fileFormat;
    }
    public string experienceFileString()
    {
        string fileFormat="";
        foreach (List<string> list in _experience.Values)
        {
            string listComplied = "";
            foreach (string element in list)
            {
                if(element == list[list.Count - 1])
                {
                    listComplied += element;
                }
                else
                {
                    listComplied += element+"|";
                }
            }        
            fileFormat += listComplied +"+";
        }
        return fileFormat;
    }
    public string skillsFileString()
    {
        string fileFormat = "";
        foreach(string skill in _skills)
        {
            if (skill == _skills[_skills.Count - 1])
            {
                fileFormat += skill;
            }
            else
            {
                fileFormat += skill + "|";
            }
        }
        return fileFormat;
    }
    public void userSetEducation()
    {
        bool moretoAdd = true;
        while (moretoAdd)
        {
            Console.Write("\nSchool: ");
            _education["School"].Add(Console.ReadLine());
            Console.Write("\nDegree: ");
            _education["Degree"].Add(Console.ReadLine());
            Console.Write("\nLocation (e.g. Rexburg, ID): ");
            _education["Location"].Add(Console.ReadLine());
            Console.Write("\nPeriod (e.g. April 2018 - July 2020): ");
            _education["Period"].Add(Console.ReadLine());
            Console.Write("\nDescription: ");
            _education["Description"].Add(Console.ReadLine());

            bool notValid = true;
            while (notValid)
            {
                Console.WriteLine("Any more?(y/n)");
                string userinput = Console.ReadLine();
                if (userinput == "y")
                {
                    notValid = false;
                    
                }
                else if (userinput == "n")
                {
                    notValid = false;
                    moretoAdd = false;
                }
                else
                {
                    Console.WriteLine("Error. Please answer with (y/n).");
                }
                
            }



            
        }


    }
    public void userSetExperience()
    {
        
    }
    public void userSetSkill()
    {
        
    }
    public override void EditAttributes()
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
                        Console.WriteLine($"Let's rewrite the summary. (Current summary:\n{_summary})");
                        _summary = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine($"Let's edit the education section! (Current contact address:)");
                        userSetEducation();
                        break;
                    case 3:
                        Console.WriteLine($"Let's edit the experience section! (Current contact address:)");
                        userSetExperience();
                        break;
                    case 4:
                        Console.WriteLine($"Let's edit the skill section! (Current paragraph:\n)");
                        userSetSkill();
                        break;
                } 
                notValid = false;  
            }catch (Exception)
            {
                Console.WriteLine($"Error. Select a number from the menu.\n{ToPartsString()}");
            }
        }
    }
    public override string ToPartsString()
    {
        return "    1. summary\n    2. education\n    3. experience\n    4. skill";
    }
    public override string ToLongString()
    {
        return $"{getName()}\n{getEmail()}-{getPhone()}-{getLinkedin()}\n";
    }
    public override string ToShortString()
    {
        return $"{getName()}'s Resume: {getPosition()}|{getOrganization()} (Last modified:{timeString()})";
    }
    public override string ToFileString()
    {
        return $"R:{getName()}+{getEmail()}+{getPhone()}+{getLinkedin()}+{getAddress()["Street"]}+{getAddress()["City"]}+{getAddress()["State"]}+{getAddress()["ZIPcode"]}+{getPosition()}+{getOrganization()}+{dateString()}+{getStatus()}+{_summary}+{educationFileString()}{experienceFileString()}{skillsFileString()}";
    }
}