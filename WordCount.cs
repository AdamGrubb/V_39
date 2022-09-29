using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utilitys;

namespace Övningar_V39
{
    internal interface WordCount
    {

        public void AddText(string path);
        public void WordsAndValue(); 
    }
    public class Histrogram:WordCount
    {
        private string WordsToBeCounted;
        private Dictionary<string, int> HistrogramListan = new Dictionary<string, int>();

        public void AddText(string path)
        {
                FileInfo texten = new FileInfo(path);
                FileStream fs = texten.Open(FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string Boktexten = sr.ReadToEnd();
                fs.Close();
                sr.Close();
                WordsToBeCounted= Boktexten;

            string[] TempLista = WordsToBeCounted.Split(' ', '\n');
            for (int i = 0; i < TempLista.Length; i++)
            {
                TempLista[i] = TempLista[i].TrimOfCharacters();
                if (TempLista[i] == string.Empty || TempLista[i]==null) continue; //Ibland verkar den ta in ett värde som "?" som trimmas bort i TrimOfCharacters. Så när den skickar vidare null eller empty. Detta kraschar .FormateraTextFörWordCount i och med att den bland annat har indexering i sig. 

                TempLista[i] = TempLista[i].FormateraTextFörWordCount();
            }
            for (int i = 0; i < TempLista.Length; i++)
            {
                if (TempLista[i] == string.Empty || TempLista[i] == null) continue; //Här har det också hänt att det sluppit igenom en empty efter .FormateraTextFörWordCount. Och i och med att jag inte vill ha det i listan så startar den en ny loop och skippar adda den till HistogramListan.
                if (HistrogramListan.ContainsKey(TempLista[i])) HistrogramListan[TempLista[i]] ++;
                else HistrogramListan.Add(TempLista[i], 0);
            }
        }
        public void WordsAndValue() // Genererar mest använda orden.
        {

            foreach (KeyValuePair<string, Int32> word in HistrogramListan.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("Key: {0}.     Value: {1}", word.Key, word.Value);
            }
        }
        public void ConvertToSortedList() //Konverterad till en SortedList så att man istället kan kolla på orden i bokstavsordning, lite kul att leta skumma ord.
        {

            SortedList<string, int> keyValuePairs = new SortedList<string, int>();
            foreach (KeyValuePair<string, Int32> word in HistrogramListan)
            {
                keyValuePairs.Add(word.Key, word.Value);
            }
            foreach (KeyValuePair<string, int> ord in keyValuePairs) Console.WriteLine($"Keystring: {ord.Key} och  {ord.Value}");
        }

    }




}


