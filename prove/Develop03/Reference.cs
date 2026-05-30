using System;

public class Reference
{
    private string _GBbook;
    private int _GBchapter;
    private int _GBverse;
    private int _GBEndVerse;

    public Reference()
    {
        SetBook("None selected");
        SetChapter(0);
        SetVerse(0);
        SetEndVerse(0);
    }
    public Reference(string book, int chapter, int verse)
    {
        SetBook(book);
        SetChapter(chapter);
        SetVerse(verse); 
        SetEndVerse(verse);   
    }
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        SetBook(book);
        SetChapter(chapter);
        SetVerse(verse); 
        SetEndVerse(endVerse);   
    }
    public void SetBook(string book)
    {
        _GBbook = book;
    }
    public void SetChapter(int chapter)
    {
        _GBchapter = chapter;
    }
    public void SetVerse(int verse)
    {
        _GBverse = verse;
    }
    public void SetEndVerse(int EndVerse)
    {
        _GBEndVerse = EndVerse;
    }
    public string GetBook()
    {
        return _GBbook;
    }
    public int GetChapter()
    {
        return _GBchapter;
    }
    public int GetVerse()
    {
        return _GBverse;
    }
    public int GetEndVerse()
    {
        return _GBEndVerse;
    }
    public string ToDisplayFormat()
    {
        if (_GBEndVerse != _GBverse)
        {
            return $"{_GBbook} {_GBchapter}:{_GBverse}-{_GBEndVerse}";
        }
        return $"{_GBbook} {_GBchapter}:{_GBverse}";

    }
    

}