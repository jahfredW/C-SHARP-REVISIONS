namespace Expressions_lambda
{
    public class Program
    {
        // une expression lambda n'a pas de modificateurs d'accès, de nom et ne déclare pas expressement de return

        static void Main(string[] args)
        {
            // Display de la fonction 'normale'
            /*            Console.WriteLine(Square(5));*/

            // display de la fonction lambda relative : ne fonctionnera pas ! 
            //Console.WriteLine(x => x * x);

            // il faut associer cette fonction lambda à un deleguate
            // fonction prend un type int et retourne un type int
            // sans argument : () => 
            // avec argument : x => 
            // (x, y, z) => ...

            Func<int, int> squareLambda = x => x * x;
            Action action = () => Console.WriteLine("Hello World");

            action();
            Console.WriteLine(squareLambda(5));

            // un expression lambda a accès à toutes les variables déclarées à l'intérieur de la méthode englobante

            int factor = 3;

            Func<int, int> multiplyLambda = x => x * factor;
            multiplyLambda(5);


            static List<Book> BookList()
            {
                return new List<Book>
                {
                    // pas de constructeur, objet 'brut'
                    new Book { Title = "Book A", Price = 100 },
                    new Book { Title = "Book B", Price = 200 },
                    new Book { Title = "Book C", Price = 150 }
                };
            }

            // récupérer les livres dont le prix est supérieur à 150
            List<Book> MyList = BookList().FindAll(book => book.Price > 150);

            // Ici au lieu de passer un expression lambda on aurait pu passer une méthode normale
            static bool priceGreaterThan150(Book books)
            {
                return books.Price > 150;
            }

            List<Book> MyList2 = BookList().FindAll(priceGreaterThan150);

            foreach (var item in MyList2)
            {
                Console.WriteLine((item.Title));
            }

            foreach (var item in MyList)
            {
                Console.WriteLine((item.Title));
            }
        }
    }

    // objet basique Book
    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }

}
