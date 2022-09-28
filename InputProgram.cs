using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utilitys;

namespace Övningar_V39
{
    public interface InputProgram
    {
        public void TurnOnInput();

    }
    public class InputOutput : InputProgram
    {
        private List<int> UserInputList= new List<int>();
        public void TurnOnInput()
        {
            bool stopLoop = true;
            while(stopLoop)
            {
                Console.WriteLine("Input number in list. Press 0 exit.");
                int input = Console.ReadLine().Int32TryParser();
                if (input == 0) stopLoop = false;
                UserInputList.Add(input);
               Console.WriteLine("Medelvärdet är: "+ UserInputList.Average()); 
            }

        }
    }
}
