/*
Eternal Quest Program - BYU-I CSE 210 W06 Project

CREATIVITY: This program exceeds the core requirements by including:
- Level system: Your score determines your level (1-10), and you "level up" with audio and text when you reach new thresholds.
- Badges: Earn badges for milestones (e.g., first completion, 1000 points, etc.), shown on the main menu.
- Negative Goals: Track and lose points for bad habits (e.g., missed workouts, unhealthy snacks).
- Code is fully organized, each class in its own file, with encapsulation, abstraction, inheritance, and polymorphism.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        string menu = @"
Eternal Quest Main Menu
-----------------------
1. Display Goals
2. Create New Goal
3. Record Event
4. Save Goals
5. Load Goals
6. View Badges
7. Quit
-----------------------";
        bool running = true;
        while (running)
        {
            Console.Clear();
            goalManager.ShowScoreAndLevel();
            goalManager.ShowBadges();
            Console.WriteLine(menu);
            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    goalManager.DisplayGoals();
                    break;
                case "2":
                    goalManager.CreateGoal();
                    break;
                case "3":
                    goalManager.RecordEvent();
                    break;
                case "4":
                    goalManager.SaveGoals();
                    break;
                case "5":
                    goalManager.LoadGoals();
                    break;
                case "6":
                    goalManager.ShowBadges(detailed:true);
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter...");
                    Console.ReadLine();
                    break;
            }
        }
        Console.WriteLine("Thank you for playing the Eternal Quest!");
    }
}