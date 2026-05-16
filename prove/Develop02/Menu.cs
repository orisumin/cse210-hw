using System;
using System.IO;

/// <summary>
/// Create a custom menu that can allows the user to pick an option from a set.
/// The default options are Write, Display, Save, Load, and Quit.
/// </summary>
public class Menu
{
    // Create a list of tuples containing a name and a function.
    // Each of these items in the list is an "option" to choose from on the menu.
    // (As a side note, I learned about an "Action" which is a function that has 
    // no parameters and returns nothing)
    public List<(string Name, Action func)> _BmpOptions = new();
    
    //This boolean is used as a flag for the loop that keeps the menu running.
    public bool _bmpInUse = true;

    public Journal _bmpActiveJournal = new Journal();

    /// <summary>
    /// This is an initializer. I didn't really know this was a thing before but basically
    /// it creates default values for the variables of any new Menu instance and doesn't 
    /// even need to be called. Wow!
    /// </summary>
    public Menu()
    {
        // Default methods are set to empty lambdas until I have the real functions
        _BmpOptions.Add(("Write", _bmpActiveJournal.BmpWriteEntry));
        _BmpOptions.Add(("Display", _bmpActiveJournal.DisplayJournal));
        _BmpOptions.Add(("Save", _bmpActiveJournal.SaveJournalAsFile));
        _BmpOptions.Add(("Load", LoadJournal));
        _BmpOptions.Add(("Quit", ()=>{_bmpInUse=false;}));
    }

    /// <summary>
    /// Display the menu of options on a loop asking for integer inputs. Run's the corresponding 
    /// input's function. Returns nothing.
    /// </summary>
    public void bmpRun()
    {

        _bmpInUse = true;
        do
        {
            Console.WriteLine("\nSelect an option below by entering its number.\n");

            for (int i = 0; i < _BmpOptions.Count(); i++)
            {
                Console.WriteLine($"\t{i+1}. {_BmpOptions[i].Name}");
            }

            try
            {
                int bmpSelectedInt = int.Parse(Console.ReadLine())-1;
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Selected: {_BmpOptions[bmpSelectedInt].Name}");
                Console.ResetColor();

                _BmpOptions[bmpSelectedInt].func();

            } catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Argument. The entry must be a listed integer.");
                Console.ResetColor();
            } catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entered integer did not match a list item.");
                Console.ResetColor();
            }
        } while (_bmpInUse);
    }
    public void LoadJournal()
    {   
        bool notLoaded = true;
        while (notLoaded){
        try
        {
        //load a journal that matches user's input
        Console.WriteLine("What is the file name?");
        string fileName = Console.ReadLine();
        //txt is saved in an array
        string[] rawJournal = System.IO.File.ReadAllLines(fileName);
        //create an empty journal
        Journal newJournal = new Journal();
        //calles each element of the array
        foreach(string rawEntry in rawJournal)
                {
                Entry organizedEntry = new Entry();
                //break the element into a date, a prompt, and a writing
                organizedEntry._bmpDate = rawEntry.Split("|")[0];
                organizedEntry._bmpPrompt = rawEntry.Split("|")[1];
                organizedEntry._bmpWriting = rawEntry.Split("|")[2];
                //add the organized entry to the empty journal
                _bmpActiveJournal._entries.Add(organizedEntry); //hmmmm
                }
        _bmpActiveJournal = newJournal;
        notLoaded = false;
        } 
        catch (FileNotFoundException)
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cannot find the file.");
                Console.ResetColor();
        }
        catch (FileLoadException)
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to load the journal. Try again.");
                Console.ResetColor();        
                }
        }
    }
}

