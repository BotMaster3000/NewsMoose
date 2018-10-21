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

        public List<OutputModel> OutputModels { get; }

        public OutputController(int consoleWidth, int consoleHeight)
        {
            ConsoleWidth = consoleWidth;
            ConsoleHeight = consoleHeight;
        }

        public void SetConsoleSize()
        {
            Console.WindowWidth = ConsoleWidth;
            Console.WindowHeight = ConsoleHeight;
        }
    }
}
