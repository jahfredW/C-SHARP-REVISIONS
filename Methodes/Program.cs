using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization.Metadata;

namespace Methodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Si méthode non statiques dans la classe, ne pas oublier de l'intancier ! 
            #region Structure d'une méthode
            /*
             access_modifier (public, private, static), return type, method_name(parameters)
             */
            #endregion
            Program program = new Program();
            // Call Instance 
            program.GetCurrentDate();
            Program.SayHello();
        }

        public void GetCurrentDate()
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            // Appel de la méthode statique
            string dayString = Program.FormatDate(day);
            string dayMonth = Program.FormatDate(month);

            Console.WriteLine(string.Format("Nous sommes le {0}/{1}/{2}", dayString, dayMonth, year));
        }

        // Les méthodes static n'appartiennent pas à l'instance de la classe, elle sont indépendantes, appartiennent à la classe. 
        public static string FormatDate(int date)
        {
            return (date.ToString().Length < 2 ? ("0" + date.ToString()) : date.ToString());
        }

        public static void SayHello()
        {
            Console.WriteLine("Hello");
        }

        //ref : permet de passer un paramètre par référence. Sa valeur est globale et non interne à la classe 
        //out: permet de définir des paramètres de retour, à affecter à l'intérieur de la classe.
        //Dans les deux cas, le return n'est pas necessaire. 


    }
}
