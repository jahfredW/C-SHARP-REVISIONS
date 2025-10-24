namespace POO_basique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialisateur d'objet : appel du constructeur par défaut (SANS PARAMETRES) ET initialisation des props
            MyObject myObject = new MyObject { MyProperty1 = 1, MyProperty2 = 2};
            // Constructeur avec paramètres
            MyObject2 myObject2 = new MyObject2(2, 3);
            // Mixte
            MyObject2 myObject3 = new MyObject2(5,4) { MyProperty3 = 3};

        }
    }

    //objet sans constructeur explicite, constructeur par défaut implicite
    public class MyObject
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }

    //objet avec constrcteur explicite + paramètres

    public class MyObject2
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }

        public MyObject2(int value1, int value2)
        {
            MyProperty1 = value1;
            MyProperty2 = value2;
        }
    }
}
