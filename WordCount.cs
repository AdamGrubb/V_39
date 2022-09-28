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
                if (TempLista[i] == string.Empty || TempLista[i]==null) continue;

                TempLista[i] = TempLista[i].FormateraTextFörWordCount();
            }
            for (int i = 0; i < TempLista.Length; i++)
            {
                if (TempLista[i] == string.Empty || TempLista[i] == null) continue;
                if (HistrogramListan.ContainsKey(TempLista[i])) HistrogramListan[TempLista[i]] ++;
                else HistrogramListan.Add(TempLista[i], 0);
            }
        }
        public void WordsAndValue()
        {

            foreach (KeyValuePair<string, Int32> word in HistrogramListan.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("Key: {0}.     Value: {1}", word.Key, word.Value);
            }
        }
        public void ConvertToSortedList()
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


