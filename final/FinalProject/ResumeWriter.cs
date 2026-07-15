public class ResumeWriter : Writer<Resume,ResumeWriter>
{
    public ResumeWriter():base(new Resume())
    {
    }
    public ResumeWriter AddSummary(string summary)
    {
        _document.setSummary(summary);
        return this;
    }
    public ResumeWriter AddSchool(string schoolName)
    {
        _document.getEducation()["School"]=[schoolName];
        return this;
    }
    public ResumeWriter AddDgree(string degree)
    {
        _document.getEducation()["Degree"]=[degree];
        return this;
    }
    public ResumeWriter AddEdPeriod(string period)
    {
        _document.getEducation()["Period"]=[period];
        return this;
    }
    public ResumeWriter AddEdLocation(string location)
    {
        _document.getEducation()["Location"]=[location];
        return this;
    }
    public ResumeWriter AddEdDescription(string description)
    {
        _document.getEducation()["Description"]=[description];
        return this;
    }
    public ResumeWriter AddCompanies(string companyName)
    {
        _document.getEducation()["Company"]=[companyName];
        return this;
    }
    public ResumeWriter AddPositions(string position)
    {
        _document.getEducation()["Position"]=[position];
        return this;
    }
    public ResumeWriter AddExLocation(string location)
    {
        _document.getEducation()["Location"]=[location];
        return this;
    }
    public ResumeWriter AddExPeriod(string period)
    {
        _document.getEducation()["Period"]=[period];
        return this;
    }
    public ResumeWriter AddExDescription(string description)
    {
        _document.getEducation()["Description"]=[description];
        return this;
    }
}