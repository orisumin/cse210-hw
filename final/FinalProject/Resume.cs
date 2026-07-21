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
           {"School",[]},
           {"Degree",[]},
           {"Period",[]},
           {"Location",[]}
        };
        _experience = new Dictionary<string, List<string>>
        {
           {"Company",[]},
           {"Position",[]},
           {"Period",[]},
           {"Location",[]},
           {"Description",[]}            
        };
        _skills = [];
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
        _education["School"].Add(schoolName);
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
        string fileFormat = "";

        foreach (List<string> list in _education.Values)
        {
            for (int i = 0; i < list.Count; i++)
            {
                fileFormat += list[i];

                if (i < list.Count - 1)
                    fileFormat += "|";
            }

            fileFormat += "+";
        }

        return fileFormat;
    }
    public string experienceFileString()
    {
        string fileFormat = "";

        foreach (List<string> list in _experience.Values)
        {
            for (int i = 0; i < list.Count; i++)
            {
                fileFormat += list[i];

                if (i < list.Count - 1)
                    fileFormat += "|";
            }

            fileFormat += "+";
        }

        return fileFormat;
}    public string skillsFileString()
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
            Console.WriteLine("School: ");
            _education["School"].Add(Console.ReadLine());
            Console.WriteLine("Degree (e.g. Bachelor of Science in UX Design): ");
            _education["Degree"].Add(Console.ReadLine());
            Console.WriteLine("Location (e.g. Rexburg, ID): ");
            _education["Location"].Add(Console.ReadLine());
            Console.WriteLine("Period (e.g. April 2018 - July 2020): ");
            _education["Period"].Add(Console.ReadLine());

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
        bool moretoAdd = true;
        while (moretoAdd)
        {
            Console.WriteLine("Company: ");
            _experience["Company"].Add(Console.ReadLine());
            Console.WriteLine("Position (e.g. Senior UX Designer): ");
            _experience["Position"].Add(Console.ReadLine());
            Console.WriteLine("Location (e.g. Rexburg, ID): ");
            _experience["Location"].Add(Console.ReadLine());
            Console.WriteLine("Period (e.g. April 2018 - July 2020): ");
            _experience["Period"].Add(Console.ReadLine());
            Console.WriteLine("Description: ");
            _experience["Description"].Add(Console.ReadLine());

            bool notValid = true;
            while (notValid)
            {
                Console.WriteLine("Any more?(y/n)");
                string userResponse = Console.ReadLine();
                if (userResponse == "y")
                {
                    notValid = false;
                    
                }
                else if (userResponse == "n")
                {
                    notValid = false;
                    moretoAdd = false;
                }
                else
                {
                    Console.WriteLine("Error. Please answer with (y/n).");
                }
            }            
        }    }
    public string DisplaySkills()
    {
        string skillPrint = "";
        int i = 1;
        foreach(string skill in _skills)
        {
            skillPrint += $"    {i}. {skill}\n";
            i++;
        }
        return skillPrint + $"    {i+1}. (Add a skill)"; 

    }
    public void userSetSkill()
    {
        bool addMore = true;
        while (addMore)
        {   Console.WriteLine("What skills do you have?");
            _skills.Add(Console.ReadLine());
            Console.WriteLine("Any more to add?(y/n)");
            bool notValid = true;
            while (notValid)
            {
                string userResponse = Console.ReadLine();
                if (userResponse == "y")
                {
                    notValid = false;
            
                }
                else if (userResponse == "n")
                {
                    notValid = false;
                    addMore = false;
                }
                else
                {
                Console.WriteLine("Error. Please answer with (y/n).");
                }            
            }


        }
    }
    public void userEditSkill()
    {
        DisplaySkills();
        Console.WriteLine("Please select the number of the skill you want to edit.");
        bool notValid = true;
        while (notValid)
        {
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                Console.WriteLine($"{userinput}. {_skills[userinput-1]}\nEnter a new skill that you want to replace this with. If you want to delete this skill, please type 'd'.");
                string userResponse = Console.ReadLine();
                if (userResponse.Replace(" ", string.Empty).ToLower() == "d")
                {
                    _skills.RemoveAt(userinput-1);
                }
                else
                {
                    _skills[userinput-1] = userResponse;

                }
                notValid = false;  
            }catch (Exception)
            {
                Console.WriteLine($"Error. Select a number from the menu.\n {DisplaySkills()}");
            }
        }
    }
    public override void EditAttributes()
    {
        bool notValid = true;
        while (notValid)
        {
            Console.WriteLine(ToLongString());
            Console.WriteLine($"Please select the part you want to edit.\n{ToPartsString()}\n    5. Done editing. Finish");            
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        Console.WriteLine($"Let's rewrite the summary. (Current summary:\n{_summary})");
                        _summary = Console.ReadLine();
                        Console.WriteLine(ToLongString());
                        break;
                    case 2:
                        Console.WriteLine($"Let's rewrite the education section!");
                        userSetEducation();
                        Console.WriteLine(ToLongString());
                        break;
                    case 3:
                        Console.WriteLine($"Let's rewrite the experience section!");
                        userSetExperience();
                        Console.WriteLine(ToLongString());
                        break;
                    case 4:
                        Console.WriteLine($"Let's edit the skill section!1");
                        userEditSkill();
                        Console.WriteLine(ToLongString());
                        break;
                    case 5:
                        notValid = false;  
                        break;
                } 
            }catch (Exception)
            {
                Console.WriteLine($"Error. Select a number from the menu.\n{ToPartsString()}\n    5. Done editing.");
            }
        }
        Console.WriteLine("Well done! The change has been saved in the program.\n");
    }
    public string EducationString()
    {
        string foramt = "";

        int i = 0;
        while (i < _education["School"].Count())
        {
            foramt += $"{_education["Degree"][i]}, {_education["Period"][i]}\n{_education["School"][i]}, {_education["Location"][i]}\n\n ";
            i ++;
        }
        return foramt;
    }
    public string ExperienceString()
    {
        string foramt = "";

        int i = 0;
        while (i < _experience["Company"].Count())
        {
            foramt += $"{_experience["Position"][i]}, {_experience["Period"][i]}\n{_experience["Company"][i]}, {_experience["Location"][i]}\n{_experience["Description"][i]}\n\n ";
            i ++;
        }
        return foramt;    
    }
    public string SkillString()
    {
        string format = "";
        foreach(string skill in _skills)
        {
            format += $"   {skill}";
        }
        return format;
    }
    public override string ToPartsString()
    {
        return "    1. summary\n    2. education\n    3. experience\n    4. skills";
    }
    public override string ToLongString()
    {
        return $"{getName()}\n------------------------------------------------------------\n{getEmail()}   {getPhone()}   {getLinkedin()}\n------------------------------------------------------------\n{ExperienceString()}\n------------------------------------------------------------\n{EducationString()}\n------------------------------------------------------------\n{SkillString()}";
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