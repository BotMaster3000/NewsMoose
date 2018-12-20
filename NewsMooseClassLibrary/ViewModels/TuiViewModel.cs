using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Interfaces;
using NewsMooseClassLibrary.Models;
using NewsMooseClassLibrary.DataBase;

namespace NewsMooseClassLibrary.ViewModels
{
    public class TuiViewModel : IViewModel
    {
        private IDataBase database;

        private List<Publisher> publishers;

        public List<Publisher> Publishers
        {
            get
            {
                return publishers ?? (publishers = new List<Publisher>());
            }
            set
            {
                if (publishers != value)
                {
                    publishers = value;
                    OnPropertyChanged(nameof(Publishers));
                }
            }
        }

        private List<NewsPaper> newspapers;

        public List<NewsPaper> NewsPapers
        {
            get
            {
                return newspapers ?? (newspapers = new List<NewsPaper>());
            }
            set
            {
                if (newspapers != value)
                {
                    newspapers = value;
                    OnPropertyChanged(nameof(NewsPapers));
                }
            }
        }

        public TuiViewModel()
        {
            //database = new XmlStorage();
            database = new DatabaseStorage();
            XmlDataBase loadedDataBase = database.LoadDataBase();
            Publishers = loadedDataBase?.Publishers.ToList();
            NewsPapers = loadedDataBase?.NewsPapers.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CreateNewNewsPaper(string name)
        {
            NewsPaper newspaper = new NewsPaper(name);
            NewsPapers.Add(newspaper);
            OnPropertyChanged(nameof(NewsPapers));
            SaveDataBase();
        }

        public void CreateNewPublisher(string name)
        {
            Publisher publisher = new Publisher(name);
            Publishers.Add(publisher);
            OnPropertyChanged(nameof(Publishers));
            SaveDataBase();
        }

        public void DeleteNewsPaper(NewsPaper newsPaper)
        {
            NewsPapers.Remove(newsPaper);
            OnPropertyChanged(nameof(NewsPapers));
            SaveDataBase();
        }

        public void DeletePublisher(Publisher publisher)
        {
            Publishers.Remove(publisher);
            OnPropertyChanged(nameof(Publishers));
            SaveDataBase();
        }

        public void ShowNewsPaper()
        {
            foreach (NewsPaper paper in NewsPapers)
            {
                Console.WriteLine($"Name: {paper.Name} | Publisher: {paper.Publisher?.Name}");
            }
        }

        public void ShowPublishers()
        {
            foreach (Publisher publisher in Publishers)
            {
                Console.WriteLine($"Publisher: {publisher.Name}");
                Console.WriteLine("NewsPapers:");
                foreach (NewsPaper paper in publisher.NewsPapers)
                {
                    Console.WriteLine($"- {paper.Name}");
                }
            }
        }

        public void UpdateNewsPaper(NewsPaper newsPaper, string newName)
        {
            newsPaper.Name = newName;
            OnPropertyChanged(nameof(NewsPapers));
            SaveDataBase();
        }

        public void UpdatePublisher(Publisher publisher, string newName)
        {
            publisher.Name = newName;
            OnPropertyChanged(nameof(Publishers));
            SaveDataBase();
        }

        private void SaveDataBase()
        {
            database.SaveDataBase(new XmlDataBase(NewsPapers.ToArray(), Publishers.ToArray()));
        }
    }
}
