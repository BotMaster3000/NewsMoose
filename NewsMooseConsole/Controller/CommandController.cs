using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseConsole.Interfaces;
using NewsMooseConsole.Models;

namespace NewsMooseConsole.Controller
{
    public class CommandController : ICommandController
    {
        private List<ICommandModel> commandList;

        public CommandController()
        {
            InitializeCommandModelsList();
        }

        private void InitializeCommandModelsList()
        {
            commandList = new List<ICommandModel>()
            {
                {new CommandModel(){ Method = DisplayMainMenu, Name = nameof(DisplayMainMenu), CanExecute = true} },
            };
        }

        public bool CanExecute(string command)
        {
            foreach (ICommandModel commandModel in commandList)
            {
                if (commandModel.Name == command)
                {
                    return commandModel.CanExecute;
                }
            }
            return false;
        }

        public void Execute(string command)
        {
            bool found = false;
            foreach (ICommandModel commandModel in commandList)
            {
                if (commandModel.Name == command)
                {
                    commandModel.Method.Invoke();
                    found = true;
                }
            }
            if (!found)
            {
                throw new Exception("Could not find Method wih name " + command);
            }
        }

        private void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("NewsMoose");
            Console.WriteLine("Current Options:");
            int counter = 1;
            foreach(ICommandModel commandModel in commandList)
            {
                if (commandModel.CanExecute)
                {
                    Console.WriteLine($"{counter}: {commandModel.Name}");
                    ++counter;
                }
            }
        }
    }
}
