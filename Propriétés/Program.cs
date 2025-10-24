namespace Propriétés
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Console.WriteLine("Hello, World!");
        }
    }

    /*
     * On distingue champs != propriétés. Les champs sont des membres de l'intance. Ils peuvent être public, privés, protected
     * Necessité de mettre en place des méthodes pour récupérer (Get) et mettre à jour (Set) la valeur d'un champ.
     * Les propriétés sont des champs qui disposent déja de ces méthodes. 
     */
    public class Test
    {
        // Raccourci pour créer une propriété : prop + tabx2
        // Raccoruci pour créer un constructeur : ctor + tabX2
        private int _Id;
        private string _Name;

        //Rappel : possibilité de modifier les getters et setter par défaut :) 
        public int Id
        {
            set {
                if (value > 0)
                {
                    _Id = value;
                } else
                {
                    throw new Exception("L'id doit être positif");
                }
            }

            get { return _Id; }
        }

        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _Name = value;
                }
                else
                {
                    throw new Exception("Vous devez indiquer un nom");
                }
            }

            get
            {
                return _Name;   
            }
        }
    }
}
