using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("📺 YouTube Product Awareness Program\n");

        // --- Video 1 ---
        Video video1 = new Video("Exploring the Future of AI", "TechWorld", 540);
        video1.AddComment(new VideoComment("Alice", "Fascinating content, learned a lot!"));
        video1.AddComment(new VideoComment("John", "AI is changing the world faster than I thought."));
        video1.AddComment(new VideoComment("Mia", "Love how you explained complex ideas clearly!"));
        video1.AddComment(new VideoComment("Carlos", "Can you make a follow-up about AI ethics?"));

        // --- Video 2 ---
        Video video2 = new Video("How to Cook the Perfect Pasta", "ChefLuigi", 300);
        video2.AddComment(new VideoComment("Sophie", "This recipe is delicious!"));
        video2.AddComment(new VideoComment("Daniel", "My pasta finally turned out perfect!"));
        video2.AddComment(new VideoComment("Nina", "Can you do one for lasagna next?"));

        // --- Video 3 ---
        Video video3 = new Video("Building a Gaming PC in 2025", "GamerZone", 720);
        video3.AddComment(new VideoComment("Leo", "That cable management though!"));
        video3.AddComment(new VideoComment("Eva", "Finally a clear guide for beginners."));
        video3.AddComment(new VideoComment("Tom", "Loved the RGB setup, looks fire 🔥"));

        // --- Video 4 ---
        Video video4 = new Video("Morning Yoga Routine", "ZenWithEmma", 480);
        video4.AddComment(new VideoComment("Lucy", "This helped me feel calm and focused."));
        video4.AddComment(new VideoComment("Ryan", "My back pain is gone after a week!"));
        video4.AddComment(new VideoComment("Kate", "Could you post an evening routine too?"));

        // --- List of all videos ---
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // --- Display results ---
        foreach (Video v in videos)
        {
            v.DisplayVideoDetails();
        }

        // ---Creativity section ---
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✨ Thank you for using the YouTube Video Tracker!");
        Console.ResetColor();
        Console.WriteLine("This program showcases abstraction by separating video details and comments logic.\n");
        Console.WriteLine("Each class has clear responsibilities, making the code easy to extend and maintain.");
        Console.WriteLine("---------------------------------------------------------------");
    }
}
