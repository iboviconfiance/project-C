using System;
using System.Collections.Generic;

// Class representing a comment on a video
public class VideoComment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public VideoComment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Class representing a YouTube video
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

    // Method to display video information and comments
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

// Main program
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("📺 YouTube Product Awareness Program\n");

        // Creation of videos and comments
        Video video1 = new Video("Exploring the Future of AI", "TechWorld", 540);
        video1.AddComment(new VideoComment("Alice", "Fascinating content, learned a lot!"));
        video1.AddComment(new VideoComment("John", "AI is changing the world faster than I thought."));
        video1.AddComment(new VideoComment("Mia", "Love how you explained complex ideas clearly!"));
        video1.AddComment(new VideoComment("Carlos", "Can you make a follow-up about AI ethics?"));

        Video video2 = new Video("How to Cook the Perfect Pasta", "ChefLuigi", 300);
        video2.AddComment(new VideoComment("Sophie", "This recipe is delicious!"));
        video2.AddComment(new VideoComment("Daniel", "My pasta finally turned out perfect!"));
        video2.AddComment(new VideoComment("Nina", "Can you do one for lasagna next?"));

        Video video3 = new Video("Building a Gaming PC in 2025", "GamerZone", 720);
        video3.AddComment(new VideoComment("Leo", "That cable management though!"));
        video3.AddComment(new VideoComment("Eva", "Finally a clear guide for beginners."));
        video3.AddComment(new VideoComment("Tom", "Loved the RGB setup, looks fire 🔥"));

        Video video4 = new Video("Morning Yoga Routine", "ZenWithEmma", 480);
        video4.AddComment(new VideoComment("Lucy", "This helped me feel calm and focused."));
        video4.AddComment(new VideoComment("Ryan", "My back pain is gone after a week!"));
        video4.AddComment(new VideoComment("Kate", "Could you post an evening routine too?"));

        // List of videos
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Displaying all videos and their comments
        foreach (Video v in videos)
        {
            v.DisplayVideoDetails();
        }

        // --- Creativity ---
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✨ Thank you for using the YouTube Video Tracker!");
        Console.ResetColor();
        Console.WriteLine("This program showcases abstraction by separating video details and comments logic.\n");
        Console.WriteLine("Each class has clear responsibilities, making the code easy to extend and maintain.");
        Console.WriteLine("---------------------------------------------------------------");
    }
}
