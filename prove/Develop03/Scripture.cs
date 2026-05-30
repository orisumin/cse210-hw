using System;
using System.IO;

public class Scripture
{
    private List<Word> _GBwords;
    private Reference _GBreference;

    public Scripture()
    {
    }
    public Scripture(Reference reference, List<Word> words)
    {
        SetReference(reference);
        SetWords(words);
    }
    public void SetReference(Reference reference)
    {
        _GBreference = reference;
    }
    public void SetWords(List<Word> words)
    {
        _GBwords = words;
    }
    public Reference GetReference()
    {
        return _GBreference;
    }
    public List<Word> GetWords()
    {
        return _GBwords;
    }

    public string ToDisplayFormat()
    {
        //create a scripture passage that begins with the reference
        string reference = _GBreference.ToDisplayFormat();
        string formattedScirpture = $"{reference}\n";

        foreach(Word rawWord in _GBwords)
        {
            //turn every word class into a string
            string word = rawWord.ToFormattedString();
            //add the string to the passage
            formattedScirpture += word+ " ";
        }
        return formattedScirpture;
    }
    //it this function returns false, it means that the entire passage is hidden. end the program. 
    public bool checkAnythingUnhidden()
    {
        foreach(Word word in _GBwords)
        {
            if (word.IsHidden() == false)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Increases the number of randomly hidden words within the passage by an integer amount. Returns void.
    /// </summary>
    /// <param name="bmpIncrease"></param>
    public void HideRandomWords(int bmpIncrease)
    {
        List<Word> bmpUnhidden = bmpRemoveHiddenWords(_GBwords);
        
        int i = 0;
        bool bmpListHasItemsFlag = true;
        while (i < bmpIncrease && bmpListHasItemsFlag)
        {
            Random bmpRandNum = new Random();
            int bmpIndex = bmpRandNum.Next(bmpUnhidden.Count-1);
            bmpUnhidden[bmpIndex].Hide();
            bmpUnhidden = bmpRemoveHiddenWords(bmpUnhidden);
            if (bmpUnhidden.Count == 0)
            {
                bmpListHasItemsFlag = false;
            } else
            {
                i++;
            }
        }
    }

    /// <summary>
    /// Remove all of the hidden Word instances from a list of Word instances. Return the updated list.
    /// </summary>
    /// <param name="bmpRawList"></param>
    /// <returns></returns>
    private List<Word> bmpRemoveHiddenWords(List<Word> bmpRawList)
    {
        List<Word> bmpUnhidden = new List<Word>();
        foreach (Word bmpWord in bmpRawList)
        {
            if (!bmpWord.ToFormattedString().Contains("_"))
            {
                bmpUnhidden.Add(bmpWord);
            }
        }
        return bmpUnhidden;
    }

 
}