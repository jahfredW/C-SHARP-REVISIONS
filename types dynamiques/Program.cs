using System.Security.Cryptography.X509Certificates;

namespace types_dynamiques
{
    public class Program
    {
        static void Main(string[] args)
        {
            DynaClass ClassTest = new DynaClass("Salut les chailles");
            ClassTest.SayType();
        }
    }

    public abstract class DynaClassMother<T>
    {
        // penser à le mettre nullable pour les types références. 
        protected T? Value;
        public DynaClassMother()
        {
            Console.WriteLine($"Je suis le constructeur de la classe {this.GetType().Name}");
        }

        public DynaClassMother(T word)
        {
            Console.WriteLine($"Je suis le constructeur de la classe {this.GetType().Name} surchargé avec {word} ");
        }

        public virtual void SayType()
        {
            Console.WriteLine($"Je suis de type : {typeof(T)}, et de valeur {Value}");
        }    
    }

    // class dérivée qui reste générique 
    public class DynaClass : DynaClassMother<string>
    {
        public DynaClass(string test) : base(test) 
        {
            Console.WriteLine($"Je suis le constructeur de {this.GetType().Name}");
            Value = test;
        }

    }

    // classe concrête : 
    public class ConcreteClass : DynaClassMother<string>
    {
        public ConcreteClass(string word) : base()
        {
            Console.WriteLine($"Je suis le constructeur de la classe ConcreteClass {this.GetType().Name}");
            Value = word;
        }
    }
}
