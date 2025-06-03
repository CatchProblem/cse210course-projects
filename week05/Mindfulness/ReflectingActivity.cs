using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity helps you reflect on times in your life when you have shown strength and resilience.";
        _duration = 30;
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public void Run()
    {
        // TODO: Implement Reflecting activity logic
    }

    public string GetRandomPrompt()
    {
        // TODO: Return random prompt
        return "";
    }

    public string GetRandomQuestion()
    {
        // TODO: Return random question
        return "";
    }

    public void DisplayPrompt()
    {
        // TODO: Display the prompt
    }

    public void DisplayQuestions()
    {
        // TODO: Display questions
    }
}
