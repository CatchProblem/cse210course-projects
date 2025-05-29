using System;
using System.Collections.Generic;

// Comment class definition
public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

// Video class definition
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Cook Pasta", "Chef Mario", 420);
        Video video2 = new Video("Learn to Draw a Cat", "ArtWithAmy", 300);
        Video video3 = new Video("Soccer Tricks for Beginners", "Coach Leo", 500);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Thanks, this was super helpful!"));
        video1.AddComment(new Comment("Bob", "I love pasta!"));
        video1.AddComment(new Comment("Charlie", "Great instructions, easy to follow."));

        // Add comments to video2
        video2.AddComment(new Comment("Daisy", "My cat looks so cute now!"));
        video2.AddComment(new Comment("Ethan", "Please do a dog next."));
        video2.AddComment(new Comment("Faith", "Very clear steps!"));

        // Add comments to video3
        video3.AddComment(new Comment("George", "I learned so much, thanks!"));
        video3.AddComment(new Comment("Hannah", "Awesome tricks."));
        video3.AddComment(new Comment("Ivan", "Now I can impress my friends!"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}