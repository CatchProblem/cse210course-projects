using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private HashSet<string> _usedQuestions = new HashSet<string>();

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void ExecuteActivity()
    {
        Random rnd = new Random();
        Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < end)
        {
            if (_usedQuestions.Count == _questions.Count)
                _usedQuestions.Clear();

            string question;
            do
            {
                question = _questions[rnd.Next(_questions.Count)];
            } while (_usedQuestions.Contains(question));

            _usedQuestions.Add(question);

            Console.Write($"> {question} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }
}
