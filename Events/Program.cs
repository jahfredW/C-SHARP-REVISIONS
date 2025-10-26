namespace Events
{
    // Utilise les delegates
    // Mécanisme qui permet aux objets de communiquer, et offrant un faible couplage entre les objets
    // Assure un bonne maintenabilité 

    // Il y a un publisher (éditeur) et un subscriber (abonné)
    // le publisher publie un événement ( event sender ) tandis que le subscriber s'abonne à cet événement ( event receiver )

    // Le publisher ne connait absolument pas le subscriber

    // Le publisher n'a jamais besoin d'être recompilé si un nouveau subscriber s'abonne à son événement,
    // Impact très faible sur l'application. 

    // Un 'contrat' est defini entre le publisher et le subscriber via un delegate qui se base sur une 
    // méthode ayant une signature spécifique.

    // Video encoder -> VideoEncoded event -> appel de la méthode OnVideoEncoded dans les subscribers

    // quelle méthode appeler dans les subsribers ? grace au delegate : contrat entre le Publisher et le Subscriber, 
    // détermine la signature de la méthode à appeler dans les subscribers
    internal class Program
    {
        static void Main(string[] args)
        {
            // instanciation d'une vidéo
            var video = new Video() { Title = "Video 1" };
            // istanciation d'un piublisher : contient la méthode Encode qui va déclencher l'evt VideoEncoded
            var videoEncoder = new VideoEncoder(); // publisher
            var messageService = new MessageService(); // subscriber

            // abonnement de la méthode OnVideoEncoded de messageService à l'événement VideoEncoded de videoEncoder
            // La méthode doit avoir la même signature que le delegate VideoEncodedEventHandler
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.VideoEncoding += messageService.OnVideoEncoding;

            videoEncoder.Encode(video);
        }
    }

    //Pour résumer : 
    /*
     * On a un objet video
     * puis un Publisher, dans ce publisher on trouve :
     * -    un delegate qui définit la signature de la méthode à appeler dans les subscribers
     * -    un évènement basé sur ce delegate
     * -    Une méthode Encode qui déclenche l'évènement une fois le traitement terminé
     * -    Une méthode protégée OnVideoEncoded qui invoque l'évènement
     * Un Subscriber, ici MessageService, qui contient une méthode OnVideoEncoded
     * -    Le nom de la méthode n'a pas d'importance, seule la signature compte
     * -    La signature doit correspondre à celle du delegate défini dans le publisher
     * Il faut ensuite abonner la méthode du subscriber à l'évènement du publisher
     */

    /*
     * Si on veut créer un subcriber avec des paramètres personnalisés, on peut créer une classe qui hérite de EventArgs
     *
    */
    public class VideoEventArgs(Video video, int rate) : EventArgs
    {
        public Video Video { get; set; } = video;
        public int Rate { get; set; } = rate;
    }

}