using System;

class Program
{
    static void Main(string[] args)
    {
        bool playing = true;
        while (playing){
            Console.WriteLine("What is the magic number?");
            string input1 = Console.ReadLine();
            int magic = int.Parse(input1);
            
            bool incorrect = true;
            int count = 0;
            while (incorrect){
                count++;
                Console.WriteLine("What is your guess?");
                string input2 = Console.ReadLine();
                int guess = int.Parse(input2);
                
                if (magic > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magic < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You made {count} guess(es).");
                    incorrect = false;
                }
            }
            Console.WriteLine("Do you want to play agian?(yes/no)");
            string answer = Console.ReadLine();
            if (answer == "no")
            {
                playing = false;
                Console.WriteLine("Thanks for playing!");
            }
            else if (answer == "yes")
            {
                Console.WriteLine("OKay! New round!");
            }
            else
            {
                Console.WriteLine("Please enter a valid answer. (yes/no)");
            }
        }

    
    }
}