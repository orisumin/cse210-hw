using System;
using System.IO;
public class Journal{
    //All the entries
    public List<Entry> _entries = [];
    
    //A list that menu will pull up a prompt from when a user selects 1. write
    public List<string> _prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"};

    public void SaveJournalAsFile()
    {
        Console.WriteLine("What is the file name?");
        string fileName = Console.ReadLine();    
        using (StreamWriter saveJournal = new StreamWriter(fileName))
        {
            foreach(Entry entry in _entries)
            {
                saveJournal.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Your journal is successfuly saved in {fileName}.");
        
    }
    public void DisplayJournal()
    {
        //displays all journal contents line by line
        foreach(Entry entry in _entries)
        {
            Console.WriteLine(entry.ToDisplayFormat());
        }
    }

    /// <summary>
    /// Prompts the user to create a new Entry with today's date and a random prompt.
    /// Automatically adds the entry to the active Journal.
    /// </summary>
    public void BmpWriteEntry()
    {
        Entry bmpNewEntry = new Entry();
        //set the entry date today
        bmpNewEntry.BmpSetDateToday();
        

        Random bmpRandNum = new Random();
        string bmpNewPrompt = _prompts[bmpRandNum.Next(_prompts.Count())];
        //save the randomly selected prompt to the entry
        bmpNewEntry._bmpPrompt = bmpNewPrompt;
        Console.WriteLine(bmpNewPrompt);

        //This try and do-while loop prevent empty responses in the entry.
        bool bmpNullReferenceFlag;
        do {
            try
            {                
                string bmpWriting = Console.ReadLine();
                if (bmpWriting == "")
                {
                    throw new NullReferenceException();
                }
                //save the user writing 
                bmpNewEntry._bmpWriting = bmpWriting;
                bmpNullReferenceFlag = false;
            } catch (NullReferenceException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid text for the prompt.");
                Console.ResetColor();
                bmpNullReferenceFlag = true;
            }
        } while (bmpNullReferenceFlag);

        //save the entry to the journal
        _entries.Add(bmpNewEntry);
    }

}