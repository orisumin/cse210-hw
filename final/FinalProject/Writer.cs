public class Writer<Doctype,WriterType>
where Doctype:Document
where WriterType : Writer<Doctype,WriterType>
{
    protected Doctype _document;
    public Writer(Doctype document)
    {
        _document = document;
    }
    public Doctype getDoc()
    {
        return _document;
    }
    public Writer<Doctype,WriterType> AddName(string name)
    {
        _document.setName(name);
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddEmail(string email)
    {
        _document.setEmail(email);
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddPhone(string phone)
    {
        _document.setPhone(phone);
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddLinkedin(string link)
    {
        _document.setLinkedin(link);
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddStreet(string street)
    {
        _document.getAddress()["Street"] = street;
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddCity(string city)
    {
        _document.getAddress()["City"] = city;
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddState(string state)
    {
        _document.getAddress()["State"] = state;
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddZIP(string zip)
    {
        _document.getAddress()["ZIPcode"] = zip;
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddPosition(string position)
    {
        _document.setPosition(position);
        return (WriterType)this;
    }
    public Writer<Doctype,WriterType> AddCompany(string organization)
    {
        _document.setOrganization(organization);
        return (WriterType)this;
    }
    public virtual Doctype Write()
    {
        return _document;
    }
}