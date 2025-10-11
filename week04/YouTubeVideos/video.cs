using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    private List<VideoComment> comments = new List<VideoComment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(VideoComment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<VideoComment> GetAllComments()
    {
        return comments;
    }

    public void DisplayVideoDetails()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n🎬 Title: {Title}");
        Console.ResetColor();

        Console.WriteLine($"👤 Author: {Author}");
        Console.WriteLine($"⏱️ Length: {LengthInSeconds} seconds");
        Console.WriteLine($"💬 Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("------------------------------------------------");

        foreach (VideoComment comment in comments)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"🗣️ {comment.CommenterName}: ");
            Console.ResetColor();
            Console.WriteLine($"\"{comment.Text}\"");
        }

        Console.WriteLine("================================================\n");
    }
}
