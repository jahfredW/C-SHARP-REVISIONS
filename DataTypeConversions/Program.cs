
#region Conversioninplicite
//conversion implicite : 
//int myint = 2;
//float myfloat;

//// conversion implicite, le compilateur comprend que flaot < int, donc ne fonctionnne pas et ne compile pas
//try
//{
//    //myint = myfloat;
//    myfloat = myint; //ceci fonctionnerai car floaot > int
//}
//catch (Exception)
//{
//    throw;
//}
#endregion

#region ConversionExplicite Exemple - TypeCast operator
//conversion implicite : 
//int myint;
//float myfloat = 345.3F;

//// conversion implicite, le compilateur comprend que flaot < int, donc ne fonctionnne pas et ne compile pas
//try
//{
//    //myint = myfloat;
//    myint = (int)myfloat; //utilisation du TypeCast Operator, on 'force' le compilateur à accepter un type.
//}
//catch (Exception)
//{
//    throw;
//}
#endregion

#region ConversionExplicite Exemple - Classe Convert
////conversion implicite : 
//int myint;
//float myfloat = 6666666666666345.3F;

//// conversion implicite, le compilateur comprend que flaot < int, donc ne fonctionnne pas et ne compile pas
//try
//{
//    //myint = myfloat;
//    myint = Convert.ToInt32(myfloat); //utilisation de la classe Convert
//    // Attention, le flaot sera arrondi dans tous les cas ! 
//}
//catch (Exception e)
//{
//    // Si le nombre est beaucoup trop grand, il ne pourra pas entrer dans un int.
//    // Une exepction sera donc levée. 
//    Console.WriteLine("C'est mort" + e);
//}
#endregion

#region ConversionExplicite Exemple - Parse
//conversion implicite : 
//string myString = "360";
//int myInt;

//// conversion implicite, le compilateur comprend que flaot < int, donc ne fonctionnne pas et ne compile pas
//try
//{
//    //myint = myfloat;
//    // myInt = (int)myString; //Ne fonctionnera pas, car string type de référence et int type valeur
//    myInt = int.Parse(myString); //fonctionne
//    // Attention, le flaot sera arrondi dans tous les cas ! 
//}
//catch (Exception e)
//{
//    // Si le nombre est beaucoup trop grand, il ne pourra pas entrer dans un int.
//    // Une exepction sera donc levée. 
//    Console.WriteLine("C'est mort" + e);
//}
#endregion

#region ConversionExplicite Exemple - TryParse
//conversion implicite : 
string myString = "360yy";
int myInt;

// retourne un booléen indiquant si la conversion a réussi
if(int.TryParse(myString, out myInt))
{
    Console.WriteLine("Conversion réussion, " + myString + " devient" + myInt.ToString() );
}
else
{
    Console.WriteLine(String.Format("La conversion de {0} a échoué", myString));
}
#endregion