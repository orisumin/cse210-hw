public class Reviewer{
    private Document _document;

    public Reviewer(Document document)
    {
        _document = document;
    }
    public void setDoc(Document document)
    {
        _document = document;
    }
    public Document GetDocument()
    {
        return _document;
    }

    public void checkRepeat()
    {
        if (_document is Resume)
        {
        }
        else if (_document is CoverLetter)
        {
            
        }
    }

}