class Program
{
    static void Main(string[] args)
    {
        // Create a scripture instance
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, scriptureText);

        // Main program loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 random words each time
        }

        // Show final state
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}