using System.Reflection.Metadata.Ecma335;

namespace Events;

public class VideoEncoder
{
    // 3 étapes pour donner la possibilité à cette classe de publier un événement : *

    /*// 1. définir un delegate
    public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

    // 2. définir un Event basé sur ce delegate  
    public event VideoEncodedEventHandler VideoEncoded;*/

    // On pourait directement faire : 
    public event EventHandler<VideoEventArgs>? VideoEncoded;
    public event EventHandler? VideoEncoding;
    public void Encode(Video video)
    {
        Console.WriteLine("Encoding video...");

        Thread.Sleep(3000);
        // Encoding logic here...      

        // 3. déclenchement de l'évènement
        OnVideoEncoded(video, 5);
    }

    // 3. invocation de l'événement
    protected virtual void OnVideoEncoded(Video video, int rate)
    {
        VideoEncoded?.Invoke(this, new VideoEventArgs(video, rate));
        VideoEncoding?.Invoke(this, EventArgs.Empty);
    }
}

public class audioEncoder
{
    //permet de définir un événement basé sur un delegate implicite
    public EventHandler AudioEncoded;

    public void Encode()
    {

    }
}