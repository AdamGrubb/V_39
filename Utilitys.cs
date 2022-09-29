using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Utilitys
{
    internal static class Utilitys
    {
       public static int Int32TryParser(this string ReadLine)
        {
            if (Int32.TryParse(ReadLine, out int value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Wrong input, must be int");
               return Console.ReadLine().Int32TryParser();
            }
        }
        public static string[] FillCardColor(this string color)
        {
            string[] unColoredCards = { "ess", "2", "3", "4", "5", "6", "7", "8", "9", "10", "knekt", "dam", "kung" };
            for (int i=0; i<unColoredCards.Length; i++)
            {
                unColoredCards[i] = color +" "+ unColoredCards[i];
            }
            return unColoredCards;
        }
        public static string FormateraTextFörWordCount(this string Oformaterad)
        {
            Oformaterad = Oformaterad.Trim().ToLower();
            //string string2 = Oformaterad[0].ToString().ToUpper();
            //string Formated = string2 + Oformaterad.Substring(1);
            return Oformaterad;

        }
        public static string TrimOfCharacters(this string UnwantedCharacters)
        {
           return UnwantedCharacters.Trim('.', ',', '!', '?', ']', '#', ';', '{', '}', '\n', '[', ']', '\r', '"', '\'', '*', ')', '(', '-');
        }
    }

}