public class CoverLetterWriter : Writer<CoverLetter, CoverLetterWriter>
{
    public CoverLetterWriter() : base(new CoverLetter())
    {
    } 
    public CoverLetterWriter AddContactName(string name)
    {
        _document.setContactName(name);
        return this;
    }

    public CoverLetterWriter AddOrganization(string organization)
    {
        _document.setOrganization(organization);
        return this;
    }
    public CoverLetterWriter AddContactAddress(Dictionary<string,string> address)
    {
        _document.setContactAddress(address);
        return this;
    }
    
    public CoverLetterWriter AddContactStreet(string street)
    {
        _document.getContactAddress()["Street"] = street;
        return this;
    }
    public CoverLetterWriter AddContactCity(string city)
    {
        _document.getContactAddress()["City"] = city;
        return this;
    }
    public CoverLetterWriter AddContactState(string state)
    {
        _document.getContactAddress()["State"] = state;
        return this;
    }
    public CoverLetterWriter AddContactZIP(string ZIPcode)
    {
        _document.getContactAddress()["ZIPcode"] = ZIPcode;
        return this;
    }
    public override CoverLetter Write()
    {
        return _document;
    }
}