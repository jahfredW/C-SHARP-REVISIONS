#region Length property // retourne la longueur de la chaine de caractère
string maChaine = "ma chaine";
Console.WriteLine(maChaine.Length);
#endregion

#region Substring methode // extrait une sous-chaine de la chaine principale
string maChaine2 = "ma chaine";
// par défaut, pas besoin de maettre de length, il ira jusqu'au bout :) 
string mySubstring = maChaine2.Substring(maChaine2.IndexOf('c'), (maChaine2.Length - maChaine2.IndexOf('c')));
Console.WriteLine(mySubstring);
#endregion

//IndexOf -> donne la position du premier caractère trouvé
//LastIndexOf -> donne la position du dernier caractère trouvé

//ToUpper, toLower -> modifier la casse d'une chaine de caractère. 

//Replace : remplacer n'importe qu'elle caractèr / sous chaine 

#region SplitMethod

string myString = "Fred, Fabien, Aurélie, Stéphanie";
string[] myArray = myString.Split(',');
// ou pour convertir directement en liste : 
List<string> list = myString.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(); // StringSplitOptions : efface les champs vides
Console.WriteLine(myArray);

#endregion

#region TrimMethod

string myStringToTrim = "asa       hello     df";
// va nettoyer si a au debut, s au début (ou fin).
// a chaque 'nettoyage', va vérifier que le caractère désigné ne se retrouve pas en début
// ou en fin de chaine. 
string myStringTrimed = myStringToTrim.TrimEnd('s','a',' ');
// Va nettoyer les espaces avant et après
/*string myStringToTrim = "       hello     ";
string myStringTrimed = myStringToTrim.Trim();*/
Console.WriteLine(myStringTrimed);

// TrimStart -> nettoie AVANT 
// TrimEnd   -> Nettoie APRES 

// TRIM method removes leading ans trailing caractérs from a specified string. 

#endregion

#region StartsWith, EndsWith, Contains

//StartWith : check if a string Start With a Substring 
string test5 = "https://";

// le paramètre StringComparaison.OrdinalIgnoireCase permet d'ignorer la casse. 
Console.WriteLine(test5.StartsWith("HTT", StringComparison.OrdinalIgnoreCase));

//EndsWith // hyper efficace pour les extensions
string nomFichier = "monfichier.mp3";

if (nomFichier.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("C'est un mp3");
}

//Contains : check si une string contient une substring. 

string[] pays = { "Bangkok", "Paris", "Tokyio" };
int index = 0;

foreach(string s in pays)
{
    
    if (s.Contains("Tok", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Index du pays trouvé : " + index);
    }
    index++;
}


#endregion