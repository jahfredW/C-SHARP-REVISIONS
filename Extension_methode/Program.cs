using System.Threading.Channels;

namespace Extension_methode
{
    // principe : 
    // - permet d'ajouter des méthodes à des types existants sans modifier leur code source
    // ni créer un nouveau type dérivé
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "SALuT";
            Console.WriteLine(str.IsCapitalized().isMaj ? $"Maj" : $"Min trouvé à {str.IsCapitalized().index}");
        }

    }

    public static class StringExtension
    {
        //la méthode doit être statique et prendre la classe que l'on veut modifier en premier paramètre
        public static MyTuple IsCapitalized(this string str)
        {
            MyTuple myTuple = new MyTuple();
            // Quand on travaille avec des strings, ne jamais oublier de tester avec IsNullOrEmpty
            if (string.IsNullOrEmpty(str))
            {
                myTuple.index = null;
                myTuple.isMaj = true;
                return myTuple;
            }


            for (int i = 0; i < str.Length; i++ )
            {
                if (char.IsLower(str[i]))
                {
                    myTuple.index = i;
                    myTuple.isMaj = false;
                    return myTuple;
                }

            }

            myTuple.index = null;
            myTuple.isMaj = true;
            return myTuple;
        }
    }

    // possibilité de créer un type Générique (ici struct) permet de retourner plusieurs valeurs
    public struct MyTuple
    {
        public bool isMaj { get; set; }
        public int? index { get; set; } = null;

        public MyTuple()
        {
            
        }
    }

    // possibilité d'utiliser un tuple directement pour retourner plusieurs valeurs.
}

