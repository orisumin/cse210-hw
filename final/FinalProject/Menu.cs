using System.Configuration.Assemblies;
using System.Globalization;
using System.Linq;
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
            "3. Edit documents",
            "4. Load document file",
            "5. Save documents",
            "6. Quit",
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
        Console.WriteLine("----------MAIN MENU----------\n"+format+"Choose a number.");
        
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
                        ShowDetails();
                        break;
                    case 3:
                        EditDocuments();
                        break;
                    case 4:
                        FileToList();
                        break;
                    case 5:
                        SavetoFile();
                        break;
                    case 6:
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
        Console.WriteLine("\nWhat kind of document do you want to create?\n    1. Cover Letter\n    2. Resume\n    3. Go back");
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
                Console.WriteLine("Error. Select a number from the menu.\n\nWhat kind of document do you want to create?\n    1. Cover Letter\n    2. Resume\n    3. Go back");
            }
        }
    }

    public CoverLetter CreateNewPFCL()
    {
        Console.WriteLine("Let's create your profile first!\nYour first and last name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Your email:");
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
            Console.WriteLine("Let's set your address.");
            coverLetter.userSetAddress();
        
            return coverLetter;
    }
    public Resume CreateNewPFRS()
    {
        Console.WriteLine("Let's create your profile first!\nYour first and last name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Your email:");
        string email = Console.ReadLine();
        Console.WriteLine("Your phone number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Your LinkedIn link: ");
        string link = Console.ReadLine();
        Console.WriteLine("What position are you applying for? ");
        string position = Console.ReadLine();
        Console.WriteLine("What is the name of the company? ");
        string organization = Console.ReadLine();
        Resume resume = new ResumeWriter()
                                        .AddName(name)
                                        .AddEmail(email)
                                        .AddPhone(phone)
                                        .AddLinkedin(link)
                                        .AddPosition(position)
                                        .AddCompany(organization)
                                        .Write();
        Console.WriteLine("Let's set your address.");
        resume.userSetAddress();
        return resume;
    }
    public Document ReuseProfile(string doctype)
    {
        Console.WriteLine("Select one from existing profiles. If you want to create a new profile, enter '0'.");
        string print = "";
        int i = 1;
        foreach(Document doc in _currentList)
        {
            print += $"{i}. {doc.ToProfileString()}\n";
            i++;
        }
        Console.WriteLine(print);
        bool notValid = true;
        while (notValid)
        {
            try
            {
                int userinput = int.Parse(Console.ReadLine());
                Document selected;
                if (userinput == 0 && doctype == "cover letter"){
                    selected = CreateNewPFCL();
                }
                else if (userinput == 0 && doctype =="resume"){
                    selected = CreateNewPFRS();
                }
                else
                {
                    selected = _currentList[userinput-1]; 
                    Console.WriteLine($"Ok! Let's create a new {doctype} with this profile.\n{selected.ToProfileString()}");
                }
                notValid = false;
                return selected;
            }catch (Exception)
            {
                Console.WriteLine("Error. Select a number from the menu.\n");
                Display();
            }
        }
        Document document = new Document();
        return document;
    }
    public void NewCovLet()
    {
        CoverLetter coverLetter;
        if (_currentList.Count() > 0)
        {
            Document selected = ReuseProfile("cover letter");
            coverLetter = new CoverLetterWriter()
                                        .AddName(selected.getName())
                                        .AddEmail(selected.getEmail())
                                        .AddPhone(selected.getPhone())
                                        .AddAddress(selected.getAddress())
                                        .AddLinkedin(selected.getLinkedin())
                                        .AddPosition(selected.getPosition())
                                        .AddCompany(selected.getOrganization())
                                        .Write();
        }
        else
        {
            coverLetter = CreateNewPFCL();       
        }
        Console.WriteLine("Let's write the opening paragraph of your cover letter!\n    - Introduce yourself and tell why you are writing\n    - Why are you interested in this position and this organization?\n    - if someone has referred you to the organization (a current employee, friend, family member) include his or her name in the first sentence.\n    - Briefly explain your experience in the field\n    - Mention one key, quantifiable achievement\nYou may write it here. When you're done, press Enter.");
        coverLetter.setOpening(Console.ReadLine());

        Console.WriteLine("Let's write the second paragraph of your cover letter!\n    - Connect your experiences and skills to the job description\n    - Cescribe your qualifications for the position using specific examples from academic, work, volunteer, and/or co-curricular experiences.\n    - Include specific numbers, results, and accomplishments\n    - Consider using words or language in the job description");
        coverLetter.setSecond(Console.ReadLine());

        Console.WriteLine("Let's write the last paragraph of your cover letter!\n    - Summarize or give a final statement of interest/qualifications\n    - Thank the employer for his/her time and consideration\n    - Consider tying in the company’s tagline, mission, or values");
        coverLetter.setClosing(Console.ReadLine());

        Console.WriteLine("Who are you writing this to? (the hiring manager, the department head, or a recruiter's name) ");
        coverLetter.setContactName(Console.ReadLine());

        Console.WriteLine("Let's set the contact address.");
        coverLetter.userSetContactAddress();

        Console.Clear();
        Console.WriteLine($"Let's take a look at the cover letter.");
        coverLetter.EditAttributes();
        
        _currentList.Add(coverLetter);
    }

    public void NewRes()
    {
        Resume resume;
        if (_currentList.Count() > 0)
        {
            Document selected = ReuseProfile("resume");
            resume = new ResumeWriter()
                                .AddName(selected.getName())
                                .AddEmail(selected.getEmail())
                                .AddPhone(selected.getPhone())
                                .AddAddress(selected.getAddress())
                                .AddLinkedin(selected.getLinkedin())
                                .AddPosition(selected.getPosition())
                                .AddCompany(selected.getOrganization())
                                .Write();
        }
        else
        {
            resume = CreateNewPFRS();    
        }
        Console.WriteLine("Let's write the summary of your resume!\n    - A concise, 2-to-4 sentence introduction\n    - Outline your core experience, key skills, and biggest measurable achievements\n    - Omit pronouns like 'I' or 'my'\n    - Describe 2-3 core skills or keywords tailored directly to the job description");
        resume.setSummary(Console.ReadLine());

        Console.WriteLine("Let's explain your education!");
        resume.userSetEducation();

        Console.WriteLine("Let's explain your work experiences!");
        resume.userSetExperience();

        resume.userSetSkill();
        
        Console.Clear();
        Console.WriteLine($"Let's take a look at the resume.");
        resume.EditAttributes();

        _currentList.Add(resume);        
    }
    public void ShowAllDOc()
    {
        _currentList = _currentList
                        .OrderBy(doc => doc.getName())
                        .ThenBy(doc => doc.getPosition())
                        .ThenBy(doc => doc.getOrganization())
                        .ToList();
        string print ="";
        int i = 1;
        foreach(Document doc in _currentList)
        {
            print += $"{i}. {doc.ToShortString()}\n";
            i++;
        }
        Console.WriteLine(print);
    }
    public void ShowDetails(){
        Console.WriteLine("Select the document that you want to look at. For the main menu, enter '0'.");

        bool notValid = true;
        while (notValid)
        {
            ShowAllDOc();
            try{
            int userinput = int.Parse(Console.ReadLine());
            if (userinput != 0){
                Console.WriteLine(_currentList[userinput-1].ToLongString());
            }        
            notValid = false;
            }catch(Exception){
                Console.WriteLine("Error. Select a number from the menu.\n");
            }        
        }

    }
    public void EditDocuments(){
        Console.WriteLine("Which one do you want to edit? For the main menu, enter '0'.");
        ShowAllDOc();
        bool notValid = true;
        while (notValid)
        {
            try{
            int userinput = int.Parse(Console.ReadLine());
            if (userinput != 0){
                _currentList[userinput-1].EditAttributes();
            }        
            notValid = false;
            }catch(Exception){
                Console.WriteLine("Error. Select a number from the menu.\n");
                ShowAllDOc();
            }        
        }

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
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        _currentList.Add(RawToDocument(line));
                    }
                }        
                notValid = false;
            }catch(FileNotFoundException){
                Console.WriteLine("No file found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
    public Document RawToDocument(string rawLine)
    {
        string type = rawLine.Split(":")[0];
        string attributes = rawLine.Split(":")[1];
        string [] details = attributes.Split("+");
        
        if(type == "C")
        {
            string name = details[0];
            string email = details[1];
            string phone = details[2];
            string linkedin = details[3];
            Dictionary<string,string> address = new Dictionary<string, string>
            {
                {"Street",details[4]},
                {"City",details[5]},
                {"State",details[6]},
                {"ZIPcode",details[7]}
            };
            string position = details[8];
            string organization = details[9];
            DateTime date = DateTime.ParseExact(details[10], "MMMM dd, yyyy", CultureInfo.InvariantCulture);
            bool status = bool.Parse(details[11]);
            string contactName = details[12];
            Dictionary<string,string> contactAddress = new Dictionary<string, string>
            {
                {"Street",details[13]},
                {"City",details[14]},
                {"State",details[15]},
                {"ZIPcode",details[16]}};
                string opening = details[17];
                string second = details[18];
                string closing = details[19];
            CoverLetter coverletter = new CoverLetterWriter()
                                        .AddName(name)
                                        .AddEmail(email)
                                        .AddPhone(phone)
                                        .AddLinkedin(linkedin)
                                        .AddAddress(address)
                                        .AddPosition(position)
                                        .AddCompany(organization)
                                        .AddStatus(status)
                                        .AddDate(date)
                                        .Write();
            coverletter.setContactName(contactName);
            coverletter.setContactAddress(contactAddress);
            coverletter.setOpening(opening);
            coverletter.setSecond(second);
            coverletter.setClosing(closing);
            return coverletter;
        }
        else if(type == "R")
        {            
            string name = details[0];
            string email = details[1];
            string phone = details[2];
            string linkedin = details[3];
            Dictionary<string,string> address = new Dictionary<string, string>
            {
                {"Street",details[4]},
                {"City",details[5]},
                {"State",details[6]},
                {"ZIPcode",details[7]}
            };
            string position = details[8];
            string organization = details[9];
            DateTime date = DateTime.ParseExact(details[10], "MMMM dd, yyyy", CultureInfo.InvariantCulture);
            bool status = bool.Parse(details[11]);

            string summary = details[12];
            Dictionary<string,List<string>> education = new Dictionary<string, List<string>>{
           {"School",rawToList(details[13])},
           {"Degree",rawToList(details[14])},
           {"Period",rawToList(details[15])},
           {"Location",rawToList(details[16])}
        };
            Dictionary<string,List<string>> experience = new Dictionary<string, List<string>>{
           {"Company",rawToList(details[17])},
           {"Position",rawToList(details[18])},
           {"Period",rawToList(details[19])},
           {"Location",rawToList(details[20])},
           {"Description",rawToList(details[21])}            
        };
            List<string> skills = rawToList(details[22]);

            Resume resume = new ResumeWriter()
                                        .AddName(name)
                                        .AddEmail(email)
                                        .AddPhone(phone)
                                        .AddLinkedin(linkedin)
                                        .AddAddress(address)
                                        .AddPosition(position)
                                        .AddCompany(organization)
                                        .AddStatus(status)
                                        .AddDate(date)
                                        .Write();
            resume.setSummary(summary);
            resume.setEducation(education);
            resume.setExperience(experience);
            resume.setSkills(skills);
            return resume;
        }
        else{
            Document document = new Document();
        return document;        
        }

    }
    public List<string> rawToList(string raw)
    {
        string[] array = raw.Split("|");
        List<string> list = new List<string>(array);
        
        return list;
    }
}