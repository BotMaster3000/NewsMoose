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
            foreach(ICommandModel commandModel in commandList)
            {
                if(commandModel.Name == command)
                {
                    return commandModel.CanExecute;
                }
            }
            return false;
        }

        public void Execute(string command)
        {
            throw new NotImplementedException();
        }

        private void DisplayMainMenu()
        {

        }
    }
}
