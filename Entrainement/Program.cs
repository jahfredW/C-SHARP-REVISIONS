namespace Entrainement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // nouveau switch variable => objet
            object test = "test";

            // resultat -> switch sur le type de test
            string result = test switch
            {
                // délaration d'un type en tant que valeur et test du type avec typeof
                int i => "c'est un int",
                string s => "c'est un string",
                // cas par défaut 
                _ => "pas ok"
            };

            Console.WriteLine(result);


            // Variable typée
            string test2 = "test2";

            // retourne le type en chaine de caractères 
            Console.WriteLine(test2.GetType().ToString());


            string result2 = test2.GetType() switch
            {
                Type t when t == typeof(int) => "C'est un int",
                Type t when t == typeof(string) => "C'est un string",
                _ => "Type inconnu"
            };

            Console.WriteLine(result2);

            // Sur un type

            Type t2 = typeof(int);

            string result3 = t2 switch
            {
                Type t3 when t3 == typeof(int) => "C'est un int",
                _ => "Type inconnu"
            };

            Console.WriteLine(result3);


            //révision nouveau switch C#8
            int number = 0;

            int resultat = number switch
            {
                0 => 1,
                1 => 2,
                _ => 0
            };
            Console.WriteLine(resultat.ToString());

            //avec un objet
            object y = "hello";

            string res = y switch
            {
                int a => "c'est un int",
                string b => "c'est un string",
                _ => "hello"
            };
            Console.WriteLine(res);

            //avec un type
            Type Z = typeof(int);

            string r = Z switch
            {
                Type I when I == typeof(int) => "c'est un int",
                _ => "hello"
            };
            Console.WriteLine(r);

            // condition ternaire
            int U = y.GetType() == typeof(int) ? 1 : 0;
            Console.WriteLine(U);

            int? monInt = null;
            Console.WriteLine(monInt.HasValue);

            if (int.TryParse((string)y, out int resul))
            {
                Console.WriteLine(resul);
            }

        }
    }
}