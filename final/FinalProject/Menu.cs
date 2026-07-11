using System.Globalization;
public class Menu
{
    private List<string> _options;
    private List<Document> _currentList;

    public Menu()
    {
        _options = [
            "1. Create a new document",
            "2. Show all documents",
            "3. Load document file",
            "4. Save documents",
        ];
        _currentList = new List<Document>();
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
    public void Display()
    {
        string format = "";
        foreach (string option in _options)
        {
            format += "    " + option + "\n";
        }
        Console.WriteLine(format+"Choose a number.");
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
        _currentList = [];
        Console.WriteLine("What is the file name?");
        string fileName = Console.ReadLine();

        using (StreamReader reader = new StreamReader(fileName))
        {
            
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
        Document document = new Document(name, email, phone, linkedin, address, position, organization, date, status);
        
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