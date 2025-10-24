// class multiplication
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;


Multiplication multiplication = new Multiplication();
multiplication.DemanderNombreDepart();
multiplication.DemanderNombreFin();
multiplication.TableGeneration();

public class Multiplication
{
    public int NbreDepart { get; set; }
    public int NbreFin { get; set; }

    public void DemanderNombreDepart()
    {
        bool NombreOk = false;
        while (!NombreOk)
        {
            Console.WriteLine("Entrez le nombre de départ : ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                NombreOk = true;
                NbreDepart = result;
            } else
            {
                Console.WriteLine("Valeur incorrecte");
            }
        }
    }

    public void DemanderNombreFin()
    {
        bool NombreOk = false;
        while (!NombreOk)
        {
            Console.WriteLine("Entrez le nombre de fin : ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                NombreOk = true;
                NbreFin = result;
            }
            else
            {
                Console.WriteLine("Valeur incorrecte");
            }
        }
    }

    public void TableGeneration()
    {
        // Boucle à partir du nombre de départ jusque nombre de fin 
        for (int index = NbreDepart; index <= NbreFin; index++)
        {
            Console.WriteLine("Table de : " + index);
            List<int> myList = BoucleUneTable(index);
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(i + 1 + " * " + NbreDepart + "= " + myList[i]);
            }
            Console.WriteLine();
        }
    }

    public List<int> BoucleUneTable(int nbreDepart)
    {
        List<int> result = new List<int>();
        for (int index = 1; index <= 10; index++)
        {
            result.Add(index * nbreDepart);
        }
        return result;
    }

}
