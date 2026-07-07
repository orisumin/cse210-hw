public class Document
{
    private string _name;
    private string _email;
    private string _phone;
    private string _linkedin;
    private string _position;
    private DateTime _date;
    private bool _isHired;

    public Document()
    {
        _name = "No name";
        _email = "No email";
        _phone = "No number";
        _linkedin = "No address";
        _position = "No position";
        _date = DateTime.Now ;
        _isHired = false;
    }
    public void setName(string name)
    {
        _name = name;
    }
    public void setEmail(string email)
    {
        _email = email;
    }
    public void setPhone(string number)
    {
        _phone = number;
    }
    public void setLinkedin(string linkedin)
    {
        _linkedin = linkedin;
    }
    public void setPosition(string positionName)
    {
        _position = positionName;
    }
    public void setDate(DateTime date)
    {
        _date = date;
    }
    public void setStatus(bool status)
    {
        _isHired = status;
    }
    public string getName()
    {
        return _name;
    }
    public string getEmail()
    {
        return _email;
    }
    public string getPhone()
    {
        return _phone;
    }
    public string getLinkedin()
    {
        return _linkedin;
    }
    public string getPosition()
    {
        return _position;
    }
    public DateTime getDate()
    {
        return _date;
    }
    public bool getStatus()
    {
        return _isHired;
    }
}