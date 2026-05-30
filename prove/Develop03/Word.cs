using System;

/// <summary>
/// Class containing a single word that can be set to Hidden or Shown.
/// </summary>
public class Word
{
    private string _bmpWord;
    private bool _bmpHidden;

    public Word(string bmpNewWord)
    {
        _bmpWord = bmpNewWord;
        _bmpHidden = false;
    }

    public void SetHidden(bool ifhidden)
    {
        _bmpHidden = ifhidden;
    }
    // a getter for _bmpHidden
    public bool IsHidden()
    {
        return _bmpHidden;
    }

    /// <summary>
    /// Set the status of the word to Hidden
    /// </summary>
    public void Hide()
    {
        _bmpHidden = true;
    }

    /// <summary>
    /// Set the statuse of the word to Show
    /// </summary>
    public void Show()
    {
        _bmpHidden = false;
    }

    /// <summary>
    /// Return the word string. If the word is Hidden, return a string of underscores
    /// as long as the word string instead.
    /// </summary>
    /// <returns>string</returns>
    public string ToFormattedString()
    {
        string bmpOutput = "";
        if (_bmpHidden)
        {
            foreach(char letter in _bmpWord)
            {
                bmpOutput += "_";
            }
        } else
        {
            bmpOutput = _bmpWord;
        }
        return bmpOutput;
    }

}