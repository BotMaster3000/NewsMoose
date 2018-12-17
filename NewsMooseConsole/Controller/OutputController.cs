using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseConsole.Models;

namespace NewsMooseConsole.Controller
{
    public class OutputController
    {
        public int ConsoleWidth { get; set; }
        public int ConsoleHeight { get; set; }

        public char[][] ConsoleText { get; set; }

        public OutputController(int consoleWidth, int consoleHeight)
        {
            ConsoleWidth = consoleWidth;
            ConsoleHeight = consoleHeight;

            InitializeConsoleArrays();
        }

        private void InitializeConsoleArrays()
        {
            ConsoleText = new char[ConsoleHeight][];
            for (int i = 0; i < ConsoleText.Length; ++i)
            {
                ConsoleText[i] = new char[ConsoleWidth];
            }
        }

        public void SetConsoleSize()
        {
            Console.WindowWidth = ConsoleWidth;
            Console.WindowHeight = ConsoleHeight;
        }

        public void AddOutput(OutputModel outputModel)
        {
            int currentCharCounter = 0;
            foreach(char c in outputModel.Text)
            {
                if(currentCharCounter < outputModel.Length)
                {
                    Console.CursorLeft = outputModel.XPosStart + currentCharCounter;
                    Console.CursorTop = outputModel.YPosStart;

                    Console.Write(c);
                    ++currentCharCounter;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
