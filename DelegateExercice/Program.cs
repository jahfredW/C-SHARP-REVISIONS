namespace DelegateExercice
{
    //Exercice
    //Mise en place du design pattern Factory 
    //Utiliser un Delegate
    //Dans une classe factory, référencer des objets SHAPE dans un dictionnaire : clé : type de l'objet (string carré, rectangle etc)
    //Dans la classe Factory, il faut une fonction d'abonnement pour les objets créés, et une fonction de création de l'objet en question
    //Utilisation du runtime polymorphisme ( Overriding ) pour les méthodes. 
    //une méthode qui affiche le type de Shape, et une méthode qui calcule le préimètre de l'objet. 

    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory factory = new ShapeFactory();
            factory.Register("carre", (type) => new Carre(type));
            Shape carre = factory.Builder("carre");
            carre.DisplayShapeType();

        }
    }

    public delegate Shape ShaperTest(string type);
    // delegate peut être remplacé par Func<string, Shape> 
    // On peut lui affecté une fonction : 
    // x => new Shape(x)

    public delegate void shaperTest2(string type);
    // Peut être remplacé par Action<string>
    // on peut lui affecter la fonction : 
    // x => Console.writeLine(x).

    //Classe ShapeFactory
    public class ShapeFactory
    {
        // Déclaration d'un membre privé de type dictionnaire, clé string = type de shape et valeur = delegate -> pointeur vers
        // une fonction d'instanciation 
        private Dictionary<string, Func<string, Shape>> _shaper = new();

        public void Register(string type, Func<string,Shape> shaper)
        {
            _shaper[type] = shaper;
        }

        public Shape Builder(string type)
        {
            if (_shaper.TryGetValue(type, out Func<string, Shape> value))
            {
                return value(type);
            }
            throw new ArgumentException($"type : {type} inconnu");
        }

    }


    //création d'un classe de base Shape
    public abstract class Shape 
    {
        protected string ShapeType  { get; set; }

        public Shape(string type)
        {
            ShapeType = type;
        }

        public virtual void DisplayShapeType()
        {
            Console.WriteLine($"Shape Générique");
        }
    }

    //Classe permettant d'instancier un Shape de type rectangle
    public class Rectangle : Shape
    {
        public double Cote2  { get; set; }
        public Rectangle(string type) : base(type)
        {

        }

        /// <summary>
        /// Display du type de Shape
        /// </summary>
        public override void DisplayShapeType()
        {
            Console.WriteLine("Shape de type Rectangle");
        }


    }

    //Classe permettant d'instancier un Shape de type Carré
    public class Carre : Shape
    {
        public Carre(string type) : base(type)
        {

        }

        /// <summary>
        /// Display du type de Shape
        /// </summary>
        public override void DisplayShapeType()
        {
            Console.WriteLine("Shape de type Carre");
        }


    }

}
