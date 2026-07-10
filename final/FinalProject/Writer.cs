public class Writer
{
    private CoverLetter _coverLetter;
    public Writer(){
        _coverLetter = new CoverLetter();
    }
    public Writer(CoverLetter coverLetter)
    {
        _coverLetter = coverLetter;
    }
    public void setCoverLetter(CoverLetter newCoverLetter)
    {
        _coverLetter = newCoverLetter;
    }
    public CoverLetter getCurrentCoverLetter()
    {
        return _coverLetter;
    }
}