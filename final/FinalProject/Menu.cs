using System.Globalization;
public class Menu
{
    private List<string> _options;
    private List<Document> _currentList;
    private bool _ifPlaying;
    public Menu()
    {
        _options = [
            "1. Create a new document",
            "2. Show all documents",
            "3. Load document file",
            "4. Save documents",
            "5. Quit",
        ];
        _currentList = new List<Document>();
        _ifPlaying = true;
    }
    public void setOptions(List<string>options)
    {
        _options = options;
    }
    public void setCurrentList(List<Document> newList)
    {
        _currentList = newList;
    }
    public List<string> getOptions()
    {
        return _options;
    }
    public List<Document> getCurrentList()
    {
        return _currentList;
    }
    public bool getStatus()
    {
        return _ifPlaying;
    }
    public void Display()
    {
        string format = "";
        foreach (string option in _options)
        {
            format += "    " + option + "\n";
        }
        Console.WriteLine(format+"Choose a number.");
        
    }
    public void SelectOption()
    {
        Display();
        bool notValid = true;
        while (notValid)
        {
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        CreateNewDoc();
                        break;
                    case 2:
                        ShowAllDOc();
                        break;
                    case 3:
                        FileToList();
                        break;
                    case 4:
                        SavetoFile();
                        break;
                    case 5:
                        _ifPlaying = false;
                        break;
                
                } 
                notValid = false;  
            }catch (Exception)
            {
                Console.WriteLine("Error. Select a number from the menu.\n");
                Display();
            }
        }

    }
    public void CreateNewDoc()
    {
        Console.WriteLine("\nWhat kind of document do you want to create?\n    1. Cover Letter\n    2. Resume\n 3. Go back");
        bool notValid = true;
        while (notValid)
        {
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        NewCovLet(); 
                        break;
                    case 2:
                        NewRes();
                        break;
                    case 3:
                        SelectOption();
                        break;
                } 
                notValid = false;  
            }catch (Exception)
            {
                Console.WriteLine("Error. Select a number from the menu.\n");
                Display();
            }
        }
    }
    public void NewCovLet()
    {
        Console.WriteLine("Your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Your email");
        string email = Console.ReadLine();
        Console.WriteLine("Your phone number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Your LinkedIn link: ");
        string link = Console.ReadLine();
        Console.WriteLine("What position are you applying for? ");
        string position = Console.ReadLine();
        Console.WriteLine("What is the name of the company? ");
        string organization = Console.ReadLine();
        CoverLetter coverLetter = new CoverLetterWriter()
                                    .AddName(name)
                                    .AddEmail(email)
                                    .AddPhone(phone)
                                    .AddLinkedin(link)
                                    .AddPosition(position)
                                    .AddCompany(organization)
                                    .Write();
    }
    public void NewRes()
    {
        
    }
    public void ShowAllDOc()
    {
        
    }
    public void Menu4()
    {
        
    }
    public void SavetoFile()
    {
        Console.WriteLine("What is the file name?");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Document document in _currentList)
            {
                writer.WriteLine(document.ToFileString());
            }
        }
    }
    public void FileToList()
    {
        _currentList.Clear();
        bool notValid  = true;
        while (notValid)
        {
            Console.WriteLine("What is the file name?");
            try{
                string fileName = Console.ReadLine();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    _currentList.Add(RawToDocument(reader.ReadLine()));
                }        
                notValid = false;
            }catch(FileNotFoundException){
                Console.WriteLine("No file found");
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Try again");
            }
        }


    }
    public Document RawToDocument(string rawLine)
    {
        string type = rawLine.Split(":")[0];
        string attributes = rawLine.Split(":")[1];

            string name = attributes.Split("+")[0];
            string email = attributes.Split("+")[1];
            string phone = attributes.Split("+")[2];
            string linkedin = attributes.Split("+")[3];
            Dictionary<string,string> address = new Dictionary<string, string>
            {
                {"Street",attributes.Split("+")[4]},
                {"City",attributes.Split("+")[5]},
                {"State",attributes.Split("+")[6]},
                {"ZIPcode",attributes.Split("+")[7]}
            };
            string position = attributes.Split("+")[8];
            string organization = attributes.Split("+")[9];
            DateTime date = DateTime.ParseExact(attributes.Split("+")[10], "MMMM dd, yyyy", CultureInfo.InvariantCulture);
            bool status = bool.Parse(attributes.Split("+")[11]);
        Document document = new Document(name, email, phone, linkedin, address, position, organization, status);
        
        if(type == "C")
        {
            string contactName = attributes.Split("+")[12];
            Dictionary<string,string> contactAddress = new Dictionary<string, string>
            {
                {"Street",attributes.Split("+")[13]},
                {"City",attributes.Split("+")[14]},
                {"State",attributes.Split("+")[15]},
                {"ZIPcode",attributes.Split("+")[16]}};
                string opening = attributes.Split("+")[17];
                string second = attributes.Split("+")[18];
                string closing = attributes.Split("+")[19];
            CoverLetter coverletter = (CoverLetter)document;
            coverletter.setContactName(contactName);
            coverletter.setAddress(contactAddress);
            coverletter.setOpening(opening);
            coverletter.setSecond(second);
            coverletter.setClosing(closing);

        }
        else if(type == "R")
        {
            string summary = attributes.Split("+")[12];
            Dictionary<string,List<string>> education = new Dictionary<string, List<string>>{
           {"School",rawToList(attributes.Split("+")[13])},
           {"Degree",rawToList(attributes.Split("+")[14])},
           {"Period",rawToList(attributes.Split("+")[15])},
           {"Location",rawToList(attributes.Split("+")[16])},
           {"Description",rawToList(attributes.Split("+")[17])}
        };
            Dictionary<string,List<string>> experience = new Dictionary<string, List<string>>{
           {"Company",rawToList(attributes.Split("+")[18])},
           {"Position",rawToList(attributes.Split("+")[19])},
           {"Period",rawToList(attributes.Split("+")[20])},
           {"Location",rawToList(attributes.Split("+")[21])},
           {"Description",rawToList(attributes.Split("+")[22])}            
        };
            List<string> skills = rawToList(attributes.Split("+")[23]);

            Resume resume = (Resume)document;
            resume.setSummary(summary);
            resume.setEducation(education);
            resume.setExperience(experience);
            resume.setSkills(skills);

        }
        return document;
    }
    public List<string> rawToList(string raw)
    {
        string[] array = raw.Split("|");
        List<string> list = new List<string>(array);
        
        return list;
    }
}