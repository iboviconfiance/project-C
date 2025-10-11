using System;

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