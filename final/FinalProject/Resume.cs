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
    public void setExperience(Dictionary<string, List<string>> experience)
    {
        _experience = experience;
    }
    public void setSkills(List<string> skills)
    {
        _skills = skills;
    }
}