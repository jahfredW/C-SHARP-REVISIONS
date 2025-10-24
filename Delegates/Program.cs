using System.ComponentModel;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ShapeFactory factory = new ShapeFactory();
            factory.Register("rectangle", (x, y) => new Rectangle(x, (double)y));
            factory.Register("carre", (x, y) => new Carre(x));

            Shape car = factory.Create("carre", 10);
            Shape rect = factory.Create("rectangle", 5, 6);

            car.CalculPerimetre();
            rect.CalculPerimetre();

            
        }
    }

    public delegate Shape ShapeCreator(double x, double? y = null);

    public class ShapeFactory
    {
        // new() est un raccourci pour new Dictionnary<string, ShapeCreator>()
        // Est possible qund le contrcuteur n'a pas d'arguments.
        // new() peut également être utilisé dans le cadre des types génrique, pour exprimer un contrainte
        // public class MyClass<T> where T : new() -> T doit avoir un constructeur public sans paramètre 
        // public T Create() => new T() (T est une classe est à un constructeur par défaut).
        // public void MaMethode<T>  where T : struct 
        private readonly Dictionary<string, ShapeCreator> _creators = new();

        // dictionnaire avec clé de type string 
        //                   valeur de type callback (delegate) qui prend 2 doucles en apramètre d'entrée, 
        private readonly Dictionary<string, Func<double, double?, Shape>> _creators2 = new();

        // Fonction Reegistrer : prend un string et un objet de type Shapecreator, sous forme de callback
        // ShapeCreator est un delegate, c'est à dore une fonction qui renvoie un obejt de type shape 
        public void Register(string type, ShapeCreator creator)
        {
            _creators[type] = creator;
        }

        public Shape Create(string type, double x, double? y = null )
        {
            if (_creators.TryGetValue(type, out var creator))
            {
                return creator(x, y); // appelle le constructeur enregistré
            }
            throw new ArgumentException("Type inconnu");
        }

    }

    public abstract class Shape
    {
        public double Cote{ get; set; }

        public string Type { get; set; } = string.Empty;

        public Shape(double cote )
        {
            Cote = cote;
        }

        public void ShapeDescription()
        {
            Console.WriteLine($"Type du shape : {Type}");
        }

        public virtual void CalculPerimetre()
        {

        }
    }

    public class Rectangle : Shape
    {
        public double Cote2 { get; set; }
        public Rectangle(double cote, double cote2) : base(cote)
        {
            Cote2 = cote2;
        }

        public override void CalculPerimetre()
        {
            double perimetre = (2 * Cote) + (2 * Cote2);
            Console.WriteLine($"perimetre : {perimetre}");
        }

    }


    public class Carre : Shape
    {
        public Carre(double cote) : base(cote) { }

        public override void CalculPerimetre()
        {
            double perimetre = 4 * Cote;
            Console.WriteLine($"perimetre : {perimetre}");
        }
    }

}
