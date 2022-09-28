using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitys;

namespace Övningar_V39
{
    internal interface DeckOfCards
    {
        List<string> cardsList { get; set; }
        Dictionary<string, int> cardDictionary { get; set; }

        public void DrawCardFromList();
        public void DrawCardAPair();
    }
    public class CardDeck : DeckOfCards
    {
        public Dictionary<string, int> cardDictionary { get; set; }

        public List<string> cardsList { get; set; }

        private string[] colors;

        public CardDeck(params string[] Colors)
        {
            colors = Colors;
        }
        public void DrawCardFromList()
        {
            int x = 0;
            FillListDeckOfCard();
            if (cardsList.Count() == 0) Console.WriteLine("You can't play draw without cards");

            while (cardsList.Count > 0)
            {
                Random f = new Random();
                int slumpKort = f.Next(0, cardsList.Count);
                x++;
                Console.WriteLine("The card is: " + cardsList[slumpKort]);
                cardsList.RemoveAt(slumpKort);

            }
        }
        public void DrawCardAPair()
        {
            FillDictonaryDeckOfCard();

            List<string> tempLista = new List<string>();
            tempLista.AddRange(cardDictionary.Keys);
            int pair = 0;

            for (int x = 0; x < 1000; x++)
            {
                Random f = new Random();
                int slumpKortEtt = f.Next(0, cardDictionary.Count);
                int slumpKortTvå = f.Next(0, cardDictionary.Count);
                if (cardDictionary.Count()==0)
                {
                    Console.WriteLine("You can't play pair without cards!"); break;
                }

                if (cardDictionary[tempLista[slumpKortEtt]] == cardDictionary[tempLista[slumpKortTvå]])
                {
                    pair++;
                }

            }
            Console.WriteLine("Det blir ett par i : " + pair + " fall.");
        }
        private void FillListDeckOfCard()
        {
            List<string> templist = new List<string>();
            foreach (string type in colors)
            {
                templist.AddRange(type.FillCardColor());
            }
            cardsList = templist;
        }

        private void FillDictonaryDeckOfCard()
        {

            Dictionary<string, int> tempDirectory = new Dictionary<string, int>();
            for (int i = 0; i < colors.Length; i++)
            {
                List<string> templist = new List<string>();
                templist.AddRange(colors[i].FillCardColor());
                for (int x = 0; x < templist.Count; x++)
                {
                    tempDirectory.Add(templist[x], x + 1);
                }
            }
            cardDictionary = tempDirectory;
        }
    }
}
