using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; private set; }
    public string Channel { get; private set; }
    public double Duration { get; private set; } // Duration in minutes

    public Video(string title, string channel, double duration)
    {
        Title = title;
        Channel = channel;
        Duration = duration;
    }

    public string GetVideoDetails()
    {
        return $"{Title} by {Channel}, Duration: {Duration} minutes";
    }
}

public class SearchService
{
    private List<Video> videos;

    public SearchService()
    {
        // Example video list
        videos = new List<Video>
        {
            new Video("Learn Abstraction", "TechChannel", 10.5),
            new Video("OOP Concepts", "CodeAcademy", 15.0),
            new Video("C# Basics", "LearnFast", 20.0)
        };
    }

    public List<Video> Search(string query)
    {
        List<Video> result = new List<Video>();

        foreach (var video in videos)
        {
            if (video.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(video);
            }
        }

        return result;
    }
}

public class VideoPlayer
{
    private Video currentVideo;

    public void Play(Video video)
    {
        currentVideo = video;
        Console.WriteLine($"Playing: {currentVideo.GetVideoDetails()}");
    }

    public void Pause()
    {
        if (currentVideo != null)
            Console.WriteLine($"Paused: {currentVideo.Title}");
    }

    public void Stop()
    {
        if (currentVideo != null)
        {
            Console.WriteLine($"Stopped: {currentVideo.Title}");
            currentVideo = null;
        }
    }
}

public class YouTubeApp
{
    private SearchService searchService;
    private VideoPlayer videoPlayer;

    public YouTubeApp()
    {
        searchService = new SearchService();
        videoPlayer = new VideoPlayer();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the YouTube App Simulation!");

        Console.WriteLine("\nEnter a search query:");
        string query = Console.ReadLine();

        var results = searchService.Search(query);

        if (results.Count == 0)
        {
            Console.WriteLine("No videos found.");
            return;
        }

        Console.WriteLine("\nSearch Results:");
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {results[i].GetVideoDetails()}");
        }

        Console.WriteLine("\nEnter the number of the video you want to play:");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= results.Count)
        {
            videoPlayer.Play(results[choice - 1]);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        YouTubeApp app = new YouTubeApp();
        app.Start();
    }
}
