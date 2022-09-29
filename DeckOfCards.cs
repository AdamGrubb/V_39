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
    public class CardDeck : DeckOfCards //Från CardDeck-klassen skapas både kortlek i form av List och Dictionary beroende på vilken metod man använder.
    {
        public Dictionary<string, int> cardDictionary { get; set; }  

        public List<string> cardsList { get; set; }

        private string[] colors;

        public CardDeck(params string[] Colors) //Här läggs önskade färger in i kortleken, om man av nån konstig anledning skulle ha fler än spader, hjärter, ruter och klöver. 
        {
            colors = Colors;
        }
        public void DrawCardFromList()  
        {
            int x = 0;
            FillListDeckOfCard();
            if (cardsList.Count() == 0) Console.WriteLine("You can't play draw without cards"); //Lite slö felhantering, går att köra metoden utan några färger på korten, vilket i programmet ger ett null-värde. Men det kraschar inte för det.

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
            FillDictonaryDeckOfCard(); //Här fylls först cardDictionary med kort som finns i metod nedan. 

            List<string> tempLista = new List<string>(); //Här så hade jag missat ElementAt (nu när jag kikat på era). Så då lägger jag in Nycklarna från Dictionary i en lista som jag använder en random i indexen för att få fram en nyckel i cardDictionary (Onödigt krångligt =P).
            tempLista.AddRange(cardDictionary.Keys);
            int pair = 0;

            for (int x = 0; x < 1000; x++)
            {
                Random f = new Random();
                int slumpKortEtt = f.Next(0, cardDictionary.Count);
                int slumpKortTvå = f.Next(0, cardDictionary.Count);
                if (cardDictionary.Count() == 0) //Här är det lite slö felhantering. I och med att man kan välja att ha fler typer av kort (utöver spader,klöver,hjärter,ruter) så kan man också ha färre. Vilket kan ge ett null-värde om man inte skriver in nått. 
                {
                    Console.WriteLine("You can't play pair without cards!"); break;
                }

                if (cardDictionary[tempLista[slumpKortEtt]] == cardDictionary[tempLista[slumpKortTvå]])
                {
                    Console.WriteLine($"Korten som dras är: {tempLista[slumpKortEtt]} och {tempLista[slumpKortTvå]}");
                    pair++;
                }

            }
            Console.WriteLine("Det blir ett par i : " + pair + " fall.");
        }
        public void FillListDeckOfCard()
        {
            List<string> templist = new List<string>();
            foreach (string type in colors)
            {
                templist.AddRange(type.FillCardColor());
            }
            cardsList = templist;
        }

        private void FillDictonaryDeckOfCard() //Den är metoden sätter värdet cardDictionary och "fyller den med kort" i klassen.
        {

            Dictionary<string, int> tempDirectory = new Dictionary<string, int>();
            for (int i = 0; i < colors.Length; i++)
            {
                List<string> templist = new List<string>(); //Här skapas en temporär lista för att kunna använda sig av extension metoden FillCardColor() som återfinns i Utilitys.cs
                templist.AddRange(colors[i].FillCardColor()); // <---- Här används utilityklassen.
                for (int x = 0; x < templist.Count; x++)
                {
                    tempDirectory.Add(templist[x], x + 1);
                }
            }
            cardDictionary = tempDirectory;
        }
    }
}
