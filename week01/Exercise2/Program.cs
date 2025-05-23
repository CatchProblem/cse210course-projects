using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percent = int.Parse(input);

        // Determine the letter grade
        string letter = "";
        string sign = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Determine the sign (+ or -)
        int lastDigit = percent % 10;

        if (letter != "F")
        {
            if (lastDigit >= 7 && letter != "A")
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        // There is no A+ or F+/F- grades
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }

        // Print the letter grade with sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Print pass/fail message
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}