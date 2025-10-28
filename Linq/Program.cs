namespace Linq
{
    // LINQ : Language Integrated Query
    // Permet d'effectuer des requêtes SQL en C# sur
    // des collections d'objets, des bases de données, des XML, etc.
    internal class Program
    {
        static void Main(string[] args)
        {
            BooksRepository booksRepository = new BooksRepository();
            // Le ToList permet de convertir un IEnumerable en List et d'avoir accès aux méthodes de List :) ;) 
            List<Book> booksList =  booksRepository.GetBooks().ToList();

            // Récupérer les livres ayant un prix supérieur à 6 de manière classique
            List<Book> books = booksList.FindAll(book => book.Price > 6);

            // utilisation de la méthode ForEach de la classe List
            books.ForEach(book => Console.WriteLine(book.Title));

            // utilisation du foreach classique
            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }

            // Récupérer les livres ayant un prix > à 5 avec Linq
            var booksList2 = booksList.Where(book => book.Price > 5);

            foreach (Book book in booksList2)
            {
                Console.WriteLine(book.Title);
            }

            // autre manière d'afficher la liste des livres : 
            booksList2.ToList().ForEach(book => Console.WriteLine(book.Title));

            //linq : order by croissant
            books.OrderBy(book => book.Title);

            //Linq : order by décroissant
            books.OrderByDescending(book => book.Price);


            // LINQ EXTENSION METHOD
            //Linq : select : utilisé pour les projections et les transformations 
            // Rappel : Projection -> récupérer certaines colonnes d'une table
            //          Transformation -> modifier ou calculer de nouvelles valeurs. 
            var valueTuples = booksList
                    // On filtre d'abord
                .Where(book => book.Price == 5)
                // On projette ensuite sur un type anonyme
                .OrderBy(book => book.Price) 
                // Ici le livre devient un tuple, car on select sur le titre et le prix
                .Select(book => (book.Price, book.Title))
                .ToList();

            valueTuples.ForEach(book => Console.WriteLine(book.Title));

            // Retourner qu'un seul élément, mais pas null
            Book book2 = books.Single(book => book.Price == 6);

            // Retourner un seul ou rien
            Book? book3 = books.SingleOrDefault(book => book.Title == "Hy Friends");

            // retourner premier élement remplissant condition
            Book? book4 = books.FirstOrDefault(book => book.Price > 6);

            //First -> certain de retourner un élément
            //Last, LastOrDefault
            //Skip(n) -> saute n enregistrements
            //Take(n) -> prend n enregistrements
            //Count, Max, Min, Sum, Average


            // LINQ QUERY OPERATOR 
            // Commence toujours par from et termine toujours par select
            var bookQuery =
                from b in books
                where b.Price > 6
                orderby b.Price
                select b.Title;
        }
    }

    public class Book
    {
        public string Title { get; set; }   
        public double Price  { get; set; }
    }

    public class BooksRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            // On crée une liste mais on la retourne en tant qu'IEnumerable : liste en lecture seule, ne peut pas être modifiée 
            return new List<Book>
            {
                new Book() { Title = "Hello World", Price = 10D },
                new Book() { Title = "ASP DOTNET FOR NOOBS", Price = 8D },
                new Book() { Title = "I Like Cobol", Price = 5D }
            };

        }
    }

}
