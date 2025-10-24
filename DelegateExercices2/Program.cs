namespace DelegateExercices2
{
    //exercice : utiliser les pattern design factory et singleton pour créer un builder d'opération (+, -, * /).
    // les classes devront être instancier en singleton 
    public class Program
    {

        public class OperationsFactory
        {
            private Dictionary<string, Func<double, double, Operation>> _operationList = new();

            //méthode d'abonnement
            public void Subscribe(string operationType, Func<double, double, Operation> operationBuiler)
            {
                _operationList[operationType] = operationBuiler;
            }

            //méthode de création d'opérations
            public Func<double, double, Operation> OperationBuilder(string type)
            {
                if (_operationList.TryGetValue(type, out Func<double, double, Operation> operation))
                {
                    return operation;
                }

                throw new ArgumentException("L'opération n'existe pas");

            }
        }

        public abstract class Operation
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Result { get; set; }
            public string OperationType { get; set; }


            // Quand on déclare un delegate avec le mot clé delegate, on crée un nouveau type, mais aucune instance n'est créée.
            /* public delegate void Display();
            Display display;*/

            Action<int> _display;


            public Operation(string type, int x, int y)
            {
                X = x; 
                Y = y;
                OperationType = type;

                switch (OperationType)
                {
                    case "addition":
                        _display  = DisplayOperationType;
                        break;
                    default:
                        break;
                }
            }

            // Fonction de display du type d'opération
            public virtual void DisplayOperationType()
            {
                Console.WriteLine("Operation generique");
            }

            // fonction de display du résultat
            public virtual void DisplayResult()
            {
                Console.WriteLine(Result);
            }

            // Fonction de calcul 
            public virtual int CalculOperation()
            {
                return 0;
            }

            public void methodeTest(Action<int> action)
            {

            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


    }
}
