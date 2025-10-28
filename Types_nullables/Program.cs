namespace Types_nullables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Les types nullables utilises la classe Nullable<T> : 
            // Il servent à rendre un type valeur capable d'accepter la valeur null
            Nullable<int> nullable = null;
            // possibilité d'utiliser le ? après le type
            int? nullable2 = null;

            string nullableStr = "";
            
            //if (string.IsNullOrWhiteSpace(nullableStr)).....

            //Exemple avec le type valeur DateTime
            DateTime? dateTime = null;

            Console.WriteLine($"HasValue : {dateTime.HasValue}");
            // GetValueOrDefault retourne la valeur par défaut du type si la valeur est null
            Console.WriteLine($"GetValueOrDefault : {dateTime.GetValueOrDefault()}");
            // Ici ça va générer une exception car on essaye d'accéder à la valeur d'un nullable qui est null
            Console.WriteLine($"Value : {dateTime.Value}");

            // Toujours privilégier la vérification avec HasValue avant d'accéder à la valeur ou utiliser directement
            // la méthode GetValueOrDefault

            // En C#8, pour vérifier qu'un type nullable a une valeuir, on peur utiliser l'opérateur null-coalescing

            Console.WriteLine(dateTime ?? DateTime.Now);

            DateTime today = dateTime ?? DateTime.Today; // The same that 

            DateTime? today2 = (dateTime != null) ? dateTime.GetValueOrDefault() : DateTime.Today;

            // Assigner un type nullable à un type non nullable : 

            DateTime? dateTime2 = DateTime.Now;
            DateTime dateTime3 = dateTime2; // Ici erreur car la valeur peut éventuellement être nulle. 
            DateTime dateTime4 = dateTime2.Value; // Possible mais risque d'exception si la valeur est null
            DateTime dateTime5 = dateTime2.GetValueOrDefault(); // Pas d'exception mais peut retourner la valeur par défaut du type DateTime
        }
    }
}
