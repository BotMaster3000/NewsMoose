using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseConsole.Interfaces;
using NewsMooseConsole.Models;
using NewsMooseClassLibrary.ViewModels;
using NewsMooseClassLibrary.Models;

namespace NewsMooseConsole.Controller
{
    public class CommandController : ICommandController
    {
        private List<ICommandModel> commandList;
        TuiViewModel viewModel = new TuiViewModel();

        public CommandController()
        {
            InitializeCommandModelsList();
        }

        private void InitializeCommandModelsList()
        {
            commandList = new List<ICommandModel>()
            {
                {new CommandModel(){ Method = DisplayMainMenu, Name = nameof(DisplayMainMenu), CanExecute = true}},
                {new CommandModel(){ Method = ShowPublishers, Name = nameof(ShowPublishers), CanExecute = true}},
                {new CommandModel(){ Method = ShowNewsPaper, Name = nameof(ShowNewsPaper), CanExecute = true}},
                {new CommandModel(){ Method = CreateNewsPaper, Name = nameof(CreateNewsPaper), CanExecute = true}},
                {new CommandModel(){ Method = CreatePublisher, Name = nameof(CreatePublisher), CanExecute = true}},
                {new CommandModel(){ Method = DeleteNewsPaper, Name = nameof(DeleteNewsPaper), CanExecute = true}},
                {new CommandModel(){ Method = DeletePublisher, Name = nameof(DeletePublisher), CanExecute = true}},


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
            DisplayOptions(false);
        }

        private void DisplayOptions(bool additionalEmptyLine = true)
        {
            if (additionalEmptyLine)
            {
                Console.WriteLine();
            }

            Console.WriteLine("Current Options:");
            int counter = 1;
            foreach (ICommandModel commandModel in commandList)
            {
                if (commandModel.CanExecute)
                {
                    Console.WriteLine($"{counter}: {commandModel.Name}");
                    ++counter;
                }
            }
        }

        private void ShowPublishers()
        {
            Console.Clear();
            viewModel.ShowPublishers();
            DisplayOptions();
        }

        private void ShowNewsPaper()
        {
            Console.Clear();
            viewModel.ShowNewsPaper();
            DisplayOptions();
        }

        private void CreateNewsPaper()
        {
            Console.Clear();
            Console.WriteLine("Creating new NewsPaper");
            Console.WriteLine("Enter name:");
            string newspaperName = Console.ReadLine();
            if (string.IsNullOrEmpty(newspaperName))
            {
                Console.WriteLine("No valid NewsPapername");
            }
            else if (NewsPaperAlreadyExists(newspaperName))
            {
                Console.WriteLine("NewsPaper already exists");
            }
            else
            {
                viewModel.CreateNewNewsPaper(newspaperName);
                Console.WriteLine("Newspaper created");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            DisplayMainMenu();
        }

        private bool NewsPaperAlreadyExists(string newsPaperName)
        {
            foreach (NewsPaper paper in viewModel.Newspapers)
            {
                if (paper.Name == newsPaperName)
                {
                    return true;
                }
            }
            return false;
        }

        private void CreatePublisher()
        {
            Console.Clear();
            Console.WriteLine("Creating new Publisher");
            Console.WriteLine("Enter name:");
            string publisherName = Console.ReadLine();
            if (string.IsNullOrEmpty(publisherName))
            {
                Console.WriteLine("Invalid Input");
            }
            else if (PublisherAlreadyExists(publisherName))
            {
                Console.WriteLine("Publisher already exists");
            }
            else
            {
                viewModel.CreateNewPublisher(publisherName);
                Console.WriteLine("Publisher created");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            DisplayMainMenu();
        }

        private bool PublisherAlreadyExists(string publisherName)
        {
            foreach (Publisher publisher in viewModel.Publishers)
            {
                if (publisher.Name == publisherName)
                {
                    return true;
                }
            }
            return false;
        }

        private void DeleteNewsPaper()
        {
            Console.Clear();
            Console.WriteLine("Enter name of Publisher to Delete");
            string newsPaperName = Console.ReadLine();
            if (DeleteCommandConfirmed())
            {
                if (DeleteNewsPaper(newsPaperName))
                {
                    Console.WriteLine("Newspaper deleted");
                }
                else
                {
                    Console.WriteLine("No newspaper found");
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            DisplayMainMenu();
        }

        private bool DeleteCommandConfirmed()
        {
            Console.WriteLine("Enter 'delete' to confirm deletion");
            return Console.ReadLine() == "delete";
        }

        private bool DeleteNewsPaper(string newsPaperName)
        {
            bool found = false;
            for (int i = 0; i < viewModel.Newspapers.Count; i++)
            {
                if(viewModel.Newspapers[i].Name == newsPaperName)
                {
                    viewModel.DeleteNewsPaper(viewModel.Newspapers[i]);
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void DeletePublisher()
        {

        }
    }
}
