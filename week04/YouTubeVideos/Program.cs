using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public void Display()
    {
        Console.WriteLine($"{CommenterName}: {CommentText}");
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in Comments)
        {
            comment.Display();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1 - Product: BrewMaster
        Video video1 = new Video("Unboxing the new BrewMaster Coffee Kit", "HomeCafe", 420);
        video1.AddComment(new Comment("Lily", "I love BrewMaster's filters!"));
        video1.AddComment(new Comment("Max", "Is that the new BrewMaster Pro 300?"));
        video1.AddComment(new Comment("Nina", "Great review. I’m sold on BrewMaster now."));
        videos.Add(video1);

        // Video 2 - Product: TravelLite
        Video video2 = new Video("Top 5 Budget Travel Gadgets", "JetSetLife", 540);
        video2.AddComment(new Comment("Omar", "That TravelLite pillow looks awesome."));
        video2.AddComment(new Comment("Paula", "I’ve used TravelLite for years—never disappointed."));
        video2.AddComment(new Comment("Quinn", "Wish I had known about this brand earlier."));
        videos.Add(video2);

        // Video 3 - Product: PureShine
        Video video3 = new Video("How to Clean Sneakers with PureShine", "StyleFix", 315);
        video3.AddComment(new Comment("Rita", "PureShine really works! Thanks for the demo."));
        video3.AddComment(new Comment("Sam", "Do they sell PureShine at Target?"));
        video3.AddComment(new Comment("Tina", "Love how clean my shoes get with this."));
        videos.Add(video3);

        // Video 4 - Product: SlimPad
        Video video4 = new Video("Best Laptops for College Students", "TechTalk", 600);
        video4.AddComment(new Comment("Uma", "Is the SlimPad 14 better than SlimPad 13?"));
        video4.AddComment(new Comment("Victor", "I just bought the SlimPad. Super fast."));
        video4.AddComment(new Comment("Wendy", "Looking at SlimPad or LightNote—any thoughts?"));
        videos.Add(video4);

        // Display information for all videos
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
