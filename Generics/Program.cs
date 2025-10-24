using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookListGen<Book, int> bookListGen = new BookListGen<Book, int>();
            bookListGen.Add(new Book());
            Console.WriteLine(bookListGen[0]);

            Test<HasDefaultConctructor> test = new Test<HasDefaultConctructor>();
        }
    }

    // Exercice 1 : rendre cette classe générique
    public class bookList
    {
        public void Add(Book book)
        {

        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public double Price { get; set; }
    }

    // on passe T et U en types génériques, ou T doit être de type classe et U de type struct (int)
    public class BookListGen<T, U> where T : class where U : struct
    {
        public List<T> BookList { get; set; } = new List<T>();
        public void Add(T book)
        {
            BookList.Add(book);
        }

        public T this[U index]
        {
            get { return BookList[Convert.ToInt32(index)];}
        }
    }

    // class utilitaire générique, disposant d'une fonction qui renvoie le maximum
    // Contrainte sur IComparable 
    // Il existe différents types de contraintes : 
    // Where T : Interface, class, Objet en particulier, struc, new() -> object disposant d'un paramètre par défaut
    public class Utilities<T> where T : IComparable
    {
        public T Compare(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    // Exemple aevc contrainte sur Objet ayant un constructeur pas défaut. 
    public class Test<T> where T : new() 
    {
        public T Implements()
        {
            return new T();
        }
    }

    public class HasDefaultConctructor
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public HasDefaultConctructor()
        {

        }
    }

    // Contrainte sur objet de type Book
    public class Objectdetails<TBook> where TBook : Book
    {
        // Attention à ne pas déclarer à nouveau un type dans la méthode
        public void Showdetails(TBook book)
        {
            // Ici on dispose des propriétés / méthodes de l'objet Book :), car on a restreint sur ce type.
            Console.WriteLine(book.Description);
        }
    }

    //Contrainte sur un type valeur (struct).
    // Ici : On 'BOX' le struct ! On converti le INT en objet
    // 1 - struct : TVALUE est stockée dns la pile 
    // 2 - affectation à object, le compilateur converti le type valeur en type object (référence) C'est le Boxing
    // Le int est copié dans une nouvelle case mémoire sur le heap, et référnce par Value.
    // 3 - Attention, pour l'associer à nouveau à TValue, nécessite un Unboxing. 
    public class Nullable<TValue> where TValue : struct
    {
        // Ici le type struct devient un type référence
        public object Value { get; set; }

        public Nullable(TValue value)
        {
            Value = value;
        }

        // méthode HasValue : réprésente une action ou un comportement, 
/*        public bool HasValue()
        {
            return Value != null; 
            
        }*/
 
        // propriété : un état ou une caratéristique 
        public bool HasValue
        {
            get { return Value != null; }
        }

        public TValue GetValueOrDefault()
        {
            if(HasValue)
            {
                return (TValue)Value;
            }
            // retourne la valeur par défaut du type générique 
            return default(TValue) ;
        }


    }
    
}
