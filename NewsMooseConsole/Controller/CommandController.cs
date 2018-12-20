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
                {new CommandModel(){ Method = UpdatePublisher, Name = nameof(UpdatePublisher), CanExecute = true}},
                {new CommandModel(){ Method = UpdateNewsPaper, Name = nameof(UpdateNewsPaper), CanExecute = true}},
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
            DisplayMenuAfterUserInput();
        }

        private void DisplayMenuAfterUserInput()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            DisplayMainMenu();
        }

        private bool NewsPaperAlreadyExists(string newsPaperName)
        {
            foreach (NewsPaper paper in viewModel.NewsPapers)
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
            DisplayMenuAfterUserInput();
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
            DisplayMenuAfterUserInput();
        }

        private bool DeleteCommandConfirmed()
        {
            Console.WriteLine("Enter 'delete' to confirm deletion");
            return Console.ReadLine() == "delete";
        }

        private bool DeleteNewsPaper(string newsPaperName)
        {
            bool found = false;
            for (int i = 0; i < viewModel.NewsPapers.Count; i++)
            {
                if (viewModel.NewsPapers[i].Name == newsPaperName)
                {
                    viewModel.DeleteNewsPaper(viewModel.NewsPapers[i]);
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void DeletePublisher()
        {
            Console.Clear();
            Console.WriteLine("Enter name of Publisher to Delete");
            string publisherName = Console.ReadLine();
            if (DeleteCommandConfirmed())
            {
                if (DeletePublisher(publisherName))
                {
                    Console.WriteLine("Publisher deleted");
                }
                else
                {
                    Console.WriteLine("No publisher found");
                }
            }
            DisplayMenuAfterUserInput();
        }

        private bool DeletePublisher(string publisherName)
        {
            bool found = false;
            for (int i = 0; i < viewModel.Publishers.Count; i++)
            {
                if (viewModel.Publishers[i].Name == publisherName)
                {
                    viewModel.DeletePublisher(viewModel.Publishers[i]);
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void UpdatePublisher()
        {
            Console.Clear();
            Console.WriteLine("Enter name for publisher to Update");
            string publisherName = Console.ReadLine();
            Publisher publisher = GetPublisher(publisherName);
            if (publisher == null)
            {
                Console.WriteLine("No publisher found");
            }
            else
            {
                Console.WriteLine("Enter number of Option: ");
                string[] options = new string[]
                {
                    "Rename Publisher",
                    "Add existing Newspaper to publisher"
                };

                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i}: {options[i]}");
                }

                switch (Console.ReadLine())
                {
                    case "0":
                        RenamePublisher(publisher);
                        break;
                    case "1":
                        AssignNewsPaperToPublisher(publisher);
                        break;
                    default:
                        Console.WriteLine("No valid option");
                        break;
                }
            }

            DisplayMenuAfterUserInput();
        }

        private Publisher GetPublisher(string publisherName)
        {
            foreach (Publisher publisher in viewModel.Publishers)
            {
                if (publisher.Name == publisherName)
                {
                    return publisher;
                }
            }
            return null;
        }

        private void RenamePublisher(Publisher publisher)
        {
            Console.WriteLine("Enter new name for publisher: ");
            string newPublisherName = Console.ReadLine();
            if (PublisherAlreadyExists(newPublisherName))
            {
                Console.WriteLine("Newly entered publisher already exists");
            }
            else
            {
                foreach (NewsPaper paper in viewModel.NewsPapers)
                {
                    if (paper.Publisher.Name == publisher.Name)
                    {
                        paper.Publisher.Name = newPublisherName;
                    }
                }

                publisher.Name = newPublisherName;
                Console.WriteLine("Updated publisher and references");
            }
        }

        private void AssignNewsPaperToPublisher(Publisher publisher)
        {
            Console.WriteLine("Enter name of Newspaper to assign to publisher");
            string newspaperName = Console.ReadLine();
            NewsPaper paper = GetNewsPaper(newspaperName);
            if (paper != null)
            {
                publisher.NewsPapers.Add(paper);
                paper.Publisher = publisher;
                Console.WriteLine("Assigned newspaper to publisher");
            }
        }

        private NewsPaper GetNewsPaper(string newsPaperName)
        {
            foreach (NewsPaper paper in viewModel.NewsPapers)
            {
                if (paper.Name == newsPaperName)
                {
                    return paper;
                }
            }
            return null;
        }

        private void UpdateNewsPaper()
        {
            Console.Clear();
            Console.WriteLine("Enter name of Newspaper to update:");
            string newsPaperName = Console.ReadLine();
            NewsPaper paper = GetNewsPaper(newsPaperName);
            if (paper == null)
            {
                Console.WriteLine("No paper found");
            }
            else
            {
                Console.WriteLine("Enter number of option");
                string[] options = new string[]
                {
                    "Rename NewsPaper",
                    "Set publisher",
                };
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i}: {options[i]}");
                }
                switch (Console.ReadLine())
                {
                    case "0":
                        RenameNewsPaper(paper);
                        break;
                    case "1":
                        AssignPublisherToNewsPaper(paper);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

            DisplayMenuAfterUserInput();
        }

        private void RenameNewsPaper(NewsPaper paper)
        {
            Console.WriteLine("Enter new name for NewsPaper: ");
            string newName = Console.ReadLine();
            if (NewsPaperAlreadyExists(newName))
            {
                Console.WriteLine("Newspaper with new name already exists");
            }
            else
            {
                foreach(Publisher publisher in viewModel.Publishers)
                {
                    foreach(NewsPaper tempPaper in publisher.NewsPapers)
                    {
                        if(tempPaper.Name == paper.Name)
                        {
                            tempPaper.Name = newName;
                        }
                    }
                }
                paper.Name = newName;
            }
        }

        private void AssignPublisherToNewsPaper(NewsPaper paper)
        {
            Console.WriteLine("Enter name of Publisher to assign:");
            string publisherName = Console.ReadLine();
            Publisher newPublisher = GetPublisher(publisherName);
            if(newPublisher == null)
            {
                Console.WriteLine("Publisher not found");
            }
            else
            {
                paper.Publisher = newPublisher;
                foreach(Publisher tempPublisher in viewModel.Publishers)
                {
                    for (int i = 0; i < tempPublisher.NewsPapers.Count; i++)
                    {
                        if (tempPublisher.NewsPapers[i].Name == paper.Name)
                        {
                            tempPublisher.NewsPapers.RemoveAt(i);
                            break;
                        }
                    }
                    if(tempPublisher.Name == newPublisher.Name)
                    {
                        tempPublisher.NewsPapers.Add(paper);
                    }
                }
            }
        }
    }
}
