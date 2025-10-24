
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Named_parameters
{
    public class Program
    {
        // ATTENTION : ON PEUT RENDRE UN BOOLEEN NULLABLE : 
        // Dans ce cas, il pourra avoir 3 valeurs : 
        // null, vrai et faux 


        static void Main(string[] args)
        {
            // le fait de NOMMER LES PARAMETRES PERMET DE S'ASTREINDRE DE L'ORDRE DES PARAMETRES FACULTATIFS
            CarBuildWithStringBuilder(isTt: true, marque: "Dacia", type:null, vMax: null);
        }

        /// <summary>
        /// CarBuild avec Ternaire = la méthode du pauvre
        /// </summary>
        /// <param name="marque"></param>
        /// <param name="type"></param>
        /// <param name="vMax"></param>
        /// <param name="isTt"></param>
        public static void CarBuild(string? marque, string? type, double? vMax, bool isTt = false)
        {
            string description = "C'est un véhicule ";
            description += (marque != null && type == null && vMax == null && !isTt) ? $"de type {marque}." : "";
            description += (marque != null &&(type != null || vMax != null || isTt)) ? ',' : "";
            description += (type != null && vMax == null && !isTt) ? $" de type {type}." : "";
            description += (type != null && (vMax != null || isTt)) ? '.' : "";
            description += !isTt && vMax != null ? $" qui roule à {vMax}." : "";
            description += vMax != null && isTt ? ',' : "";
            description += isTt ? $" qui dispose d'un mode 4x4 {vMax}." : "";

            Console.WriteLine(description);
        }

        /// <summary>
        /// CarBuild avec List, un peu plus SMART 
        /// </summary>
        /// <param name="marque"></param>
        /// <param name="type"></param>
        /// <param name="vMax"></param>
        /// <param name="isTt"></param>
        public static void CarBuildWithList(string? marque, string? type, double? vMax, bool isTt = false)
        {
            List<string> CarList = new List<string>();

            string element = "";
            string sentence = "";

            element = "Ceci est un véhicule";

            if (!string.IsNullOrEmpty(marque))
            {
                // utiliser Add si liste, Append -> IEnumerable 
                CarList.Add($" de marque : {marque}");
            }

            if (!string.IsNullOrEmpty(type))
            {
                CarList.Add($" de type : {type}");
            }

            if (vMax.HasValue)
            {
                CarList.Add($" qui peut rouler jusqu'à : {vMax}");
            }

            if (isTt)
            {
                CarList.Add($" et qui est 4x4");
            }


            if (CarList.Count >= 0)
            {
                //Si la liste contient plus d'un élément, alors on la splitte avec des ,
                sentence = string.Join(",", CarList);
            }

            sentence = element + sentence;
            sentence +=(".");

            Console.WriteLine(sentence);
        }

        public static void CarBuildWithStringBuilder(string? marque, string? type, double? vMax, bool isTt = false)
        {


            StringBuilder myString = new StringBuilder();
            bool isFirst = true;
            string fragment = "Ceci est un véhicule";

            AppendFragment(fragment);

            void AppendFragment(string fragment)
            {
                if (!isFirst)
                {
                    myString.Append(", ");
                }
                myString.Append(fragment);
                isFirst = false;
            }

            if (!string.IsNullOrEmpty(marque))
            {
                fragment = $"de marque : {marque}";
                AppendFragment(fragment);
            }

            if (!string.IsNullOrEmpty(type))
            {
                fragment = $"de type : {type}";
                AppendFragment(fragment);   
            }

            if (vMax.HasValue)
            {
                fragment = $"qui peut rouler jusqu'à : {vMax}";
                AppendFragment(fragment);
            }

            if (isTt)
            {
                fragment = $"et qui est 4x4";
                AppendFragment(fragment);
            }

            myString.Append(".");

            Console.WriteLine(myString);
        }
    }
}
