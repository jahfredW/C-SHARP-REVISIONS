namespace Polymorphism
{
    // le polymorphisme permet à une méthode d'avoir plusieurs comportements selon le contexte : 
    // 2 types de polymorphisme : 
    // - A la compilation = compile-time polymorphism, aussi appelé method OVERLOADING = surcharge de méthode: 
    // C'est une méthode qui porte le même nom, mais qui a des signatures différentes 
    // Le compilateur sait quelle version appeler au moment de la compilation 
    // - A l'éxécution = runtime polymorphism, appelé method OVERRIDING: surcharge de méthode dite virtuelle via héritage
    // La méthode est dite virtuelle dans la classe de base, override dans la classe dérivée. 
    internal class Program
    {
        static void Main(string[] args)
        {
            Employe[] employelist = new Employe[2];
            employelist[0] = new Employe();
            employelist[1] = new Intern();

            foreach (Employe employe in employelist)
            {
                employe.Presentation();
            }
        }
    }

    public class Employe
    {
        public string Status { get; set; } = "employe";

        // méthode virtuelle de la classe de base. 
        public virtual void Presentation()
        {
            Console.WriteLine($"Hy, I am an {Status} from IBM");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Status : {Status}");
        }

    }

    public class Intern : Employe
    {
        public Intern()
        {
            Status = "Stagiaire";
        }
        // méthode surchargée = method overriding 
        public override void Presentation()
        {
            Console.WriteLine($"Hi, I am {Status} from IBM, and I am very glad to mmeet you");
        }

        public void ShowStatus(int indice)
        {
            Console.WriteLine($"Indice ! {indice}");
            Console.WriteLine($"Status : {Status}");
        }
    }
}
