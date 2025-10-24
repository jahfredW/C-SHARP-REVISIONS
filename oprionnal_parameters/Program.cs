using System.Security.Cryptography.X509Certificates;

namespace oprionnal_parameters
{
    internal class Program
    {
        //dateDuJour facultatif, init à null -> comme type référence (objet) alors nullable -> ? 
        public static void DisplayId(string nom, string prenom, DateTime? dateDuJour = null)
        {
            //opérateur de coalescence : si dateDuJour nulle alors on init à Now
            dateDuJour ??= DateTime.Now;
            Console.WriteLine(String.Concat("nom : {0}, prénom : {1}, date de Naissance : {2}"), nom, prenom, dateDuJour);
        }

        // le champs est facultatif 
        static void Main(string[] args)
        {
            DisplayId("Fred", "Gruwe");
        }

        //LES CHAMPS FACULTATIFS CONCERNENT EXCLUSIVEMENT LES PARAMETRES PASSEES EN DERNIER !!! 
    }
}
