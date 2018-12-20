using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseConsole.Controller;

namespace NewsMooseConsole
{
    class Program
    {
        static void Main()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            CommandController controller = new CommandController();
            controller.Execute("DisplayMainMenu");
            string command = "";
            do
            {
                command = Console.ReadLine();
                if (!string.IsNullOrEmpty(command) && controller.CanExecute(command))
                {
                    controller.Execute(command);
                }
            }
            while (command != "exit");
        }
    }
}
