using System;
using System.Diagnostics.Contracts;

/// <summary>
/// Contains a date, prompt, and writing string.
/// </summary>
public class Entry
{
    public string _bmpDate = "<No Date>";
    public string _bmpPrompt = "<No Prompt>";
    public string _bmpWriting = "<No Writing>";

/// <summary>
/// Return the a formatted string of the date, prompt, and writing of the entry.
/// </summary>
/// <returns>string</returns>
    public string ToDisplayFormat()
    {
        string bmpNewString = $"{_bmpDate}\n{_bmpPrompt}\n{_bmpWriting}\n";
        return bmpNewString;
    }

/// <summary>
/// Run this to automatically set the Entry's date to today.
/// Formatted yyyy-MM-dd.
/// Returns nothing.
/// </summary>
    public void BmpSetDateToday()
    {
        DateTime bmpToday = DateTime.Now;
        _bmpDate = bmpToday.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Returns the entry as a formatted string with the parts seperated by "|" characters.
    /// </summary>
    /// <returns>string</returns>
    public string ToFileString()
    {
        return $"{_bmpDate}|{_bmpPrompt}|{_bmpWriting}";
    }
}