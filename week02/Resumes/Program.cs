
using System;

// Abstract class defining common interface
public abstract class MusicPlayer
{
    public abstract void Play();
    public abstract void Pause();
}

// Implementation for MP3 files
public class MP3Player : MusicPlayer
{
    private string fileName;
    
    public MP3Player(string fileName) { this.fileName = fileName; }
    
    public override void Play() => Console.WriteLine($"Playing MP3: {fileName}");
    public override void Pause() => Console.WriteLine("Pausing MP3");
}

// Implementation for streaming
public class StreamingPlayer : MusicPlayer
{
    private string url;
    
    public StreamingPlayer(string url) { this.url = url; }
    
    public override void Play() => Console.WriteLine($"Streaming from: {url}");
    public override void Pause() => Console.WriteLine("Pausing stream");
}

// Using abstraction
class Program
{
    static void Main()
    {
        MusicPlayer mp3 = new MP3Player("song.mp3");
        MusicPlayer stream = new StreamingPlayer("radio.com");
        
        mp3.Play();
        stream.Play();
    }
}