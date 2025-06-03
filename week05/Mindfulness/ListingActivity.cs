using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity helps you reflect on the good things in your life.";
        _duration = 30;
        _prompts = new List<string>();
        _count = 0;
    }

    public void Run()
    {
        // TODO: Implement Listing activity logic
    }

    public void GetRandomPrompt()
    {
        // TODO: Display random prompt from _prompts
    }

    public List<string> GetListFromUser()
    {
        // TODO: Get list of items from user input
        return new List<string>();
    }
}
