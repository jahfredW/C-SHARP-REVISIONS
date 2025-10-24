namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Daughter daughter = new Daughter(1, "Toto");
            Console.WriteLine(daughter.MyProperty1);
            // affichera Greetings from derived class
            daughter.Greetings();
            // affichera Grretigns from base class -> le cast permet d'utiliser les méthodes de la classe de base
            ((Mother)daughter).Greetings();
            // Ceci ne fonctionnera pas, le membre est protected, donc inaccessible depuis l'extérieur
            // Pour le display, il faut utiliser une méthode public de Daughter qui affiche de membre 
            daughter.DisplayMember();
        }
    }

    //method Hiding : 
    /*  Allows a derived class to define a method with the same name as a method in the base class
     *  This hide, shadow the base class method
     *  Method hiding is achieved by using the keyword 'new' 
     *  The hiding method must have the same name and the same parameters than base method
    */
    public class Mother
    {

        // member accessible from the derived class and from outside
        public int MyProperty1 { get; set; }
        // Member accessible within the derived class
        protected string MyProperty2 { get; set; } = string.Empty;
        // Member only accessible within the base class 
        private bool MyProperty3 { get; set; }

        public Mother()
        {
            Console.WriteLine("Constructeur de Mother");
            MyProperty2 = "Hello World";
        }

        // contructeur surchargé. 
        public Mother(int ind)
        {
            Console.WriteLine("Constructeur surchargé de la classe de base");
            MyProperty1 = ind;
        }
        public Mother(string test)
        {
            Console.WriteLine("Constructeur surchargé de la classe de base");
            MyProperty2 = test;
            Greetings();
        }

        public void Greetings()
        {
            Console.WriteLine("Greetings from base class!");
        }
    }

    //Dans le cas d'un héritage standard, l'instanciation de la classe dérivée entraine l'éxécution du constructeur de la
    //class mère, puis l'exécution du constructeur de la classe dérivée?
    public class Daughter : Mother
    {
        public int DProperty { get; set; }
        public Daughter()
        {
            Console.WriteLine("Constructeur de Daughter");
        }

        // Appelle du constructeur surchargé auquel on passe DProperty
        public Daughter(int x) : base(x)
        {
            Console.WriteLine("Constructeur surchargé de la classe dérivée");
            DProperty = x;
            MyProperty2 = "Test";
            Console.WriteLine($"{DProperty}");
        }

        // Appelle du contructeur surchargé, avec cette fois un string. 
        public Daughter(int x, string y) : base(y)
        {
            MyProperty1 = x;
            Greetings();
        }
        public void DisplayMember()
        {
            Console.WriteLine($" MyProperty1 : {MyProperty1}");
            Console.WriteLine($" MyProperty2 : {MyProperty2}");

        }

        //method hiding, the base method is redefine
        public new void Greetings()
        {
            Console.WriteLine("Greetings from derived class");
        }

    }
}
