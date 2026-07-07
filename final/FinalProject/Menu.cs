public class Menu
{
    private List<string> _options;
    private List<Document> _currentList;

    public Menu()
    {
        _options = [
            "1. ",
            "2. ",
            "3. ",
            "4. ",
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
}