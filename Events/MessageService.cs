namespace Events;

public class MessageService()
{
    public void OnVideoEncoded(object source, VideoEventArgs args)
    {
        Console.WriteLine($"titre : {args.Video.Title}, note : {args.Rate.ToString()}");
    }

    public void OnVideoEncoding(object source, EventArgs args)
    {
        Console.WriteLine("Video en cours d'encodage...");
    }
}