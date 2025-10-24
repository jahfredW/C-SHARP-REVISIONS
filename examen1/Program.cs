// ecrire une classe standard qui va effectuer une validation de l'entrée
// en vérifiant qu'il s'agit d'un INT,
// ecrire une classe générique avec un méthode qui indique le type utilisé.
// cette class générique doit pouvoir utiliser un Value Type et tester sur 3 types de cette catégorie. 

/*Examen examen = new Examen();
examen.InputValidation();*/

Generique<int> generique = new Generique<int>(42);
generique.TesterType2();


public class Generique<T> where T : struct
{
    public T Input { get; set; }
    public Generique(T input)
    {
        Input = input;
    }
    public void TesterType()
    {
        string result = Input switch
        {
            int a => "C'est un int",
            double b => "C'est un double",
            bool c => "C'est un booléen",
            _      => "Type inconnu"
        };
        Console.WriteLine(result);
    }

    public void TesterType2()
    {
        string result = Input.GetType() switch
        {
            Type a when a == typeof(int) => "C'est un int",
            Type b when b == typeof(double) => "C'est un double",
            Type c when c == typeof(bool) => "C'est un booléen",
            _ => "Type inconnu"
        };
        Console.WriteLine(result);
    }
}



public class Examen
{
    // propriété input
    public string Input { get; private set; }
    public int InputInt { get; private set; }
    public bool InputOk = false;


    //constructeur surchargé avec un string
    public Examen(string input) 
    {
        Input = input;
    }


    //méthode d'affichage entrée
    public void AffichageIn()
    {
        Console.WriteLine("Entrez un nombre");

        Input = Console.ReadLine() ?? "";
  
    }

    //méthode d'affichage Sortie
    public void AffichageOut(bool Inputok)
    {
        string message = InputOk switch
        {
            true => "Validation OK",
            _    => "L'entrée n'est pas valide"
        };

        Console.WriteLine(message);
    }

    //validation de l'input
    public void InputValidation()
    {
        while (!InputOk)
        {
            AffichageIn();
            if (int.TryParse(Input, out int result))
            {
                InputOk = true;
                InputInt = result;
            }
            else
            {
                InputOk = false;
            }
            AffichageOut(InputOk);
        }
    }
}

