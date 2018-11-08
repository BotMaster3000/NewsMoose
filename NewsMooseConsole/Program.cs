using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.OutputController outputController = new Controller.OutputController(100, 40);
            outputController.SetConsoleSize();

            outputController.AddOutput(new Models.OutputModel()
            {
                XPosStart = 1,
                YPosStart = 1,
                Length = 7,
                Text = "Hello, Test"
            });

            Console.ReadLine();
        }
    }
}
