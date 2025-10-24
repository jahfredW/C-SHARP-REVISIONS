namespace PatternDesignSingleTon
{

    /// <summary>
    /// Pour créer un singleton : 
    /// - 1 champ static qui contient l'instance
    /// - Un constructeur privé ( non appelable depuis l'extérieur). 
    /// - Une méthode de récupération de l'instance.
    /// 
    /// - Si un champ peut être variable et commun entre plusieurs instances, alors le passer en statique = shared member. 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Car car1 = Car.GetInstance();
            Car car2 = Car.GetInstance();

            Console.WriteLine(car1 == car2);
        }
    }

    public class Car
    {
        //champ sttaic, appartient au type (classe) et non à l'objet en lui même 
        static Car? _intance;

        //Constructeur privé
        private Car() { }

        //Une méthode qui gère la création de l'objet ou la récupération de l'instance. 
        public static Car GetInstance()
        {
            if(_intance == null)
            {
                Console.WriteLine("objet non init, création");
                _intance = new Car();
            } else
            {
                Console.WriteLine("Objet existant, déja créé");
            }
            return _intance;
        }
    }
}
