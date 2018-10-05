using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Interfaces;
using NewsMooseClassLibrary.Models;

namespace NewsMooseClassLibrary.ViewModels
{
    class TuiViewModel : IViewModel
    {
        private List<Publisher> publishers;
        public List<Publisher> Publishers
        {
            get
            {
                return publishers;
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
        public List<NewsPaper> Newspapers
        {
            get
            {
                return newspapers;
            }
            set
            {
                if (newspapers != value)
                {
                    newspapers = value;
                    OnPropertyChanged(nameof(Newspapers));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CreateNewNewsPaper(string name)
        {
            NewsPaper newspaper = new NewsPaper(name);
            Newspapers.Add(newspaper);
            OnPropertyChanged(nameof(Newspapers));
        }

        public void CreateNewPublisher(string name)
        {
            Publisher publisher = new Publisher(name);
            Publishers.Add(publisher);
            OnPropertyChanged(nameof(Publishers));
        }

        public void DeleteNewsPaper(NewsPaper newsletter)
        {
            Newspapers.Remove(newsletter);
            OnPropertyChanged(nameof(Newspapers));
        }

        public void DeletePublisher(Publisher publisher)
        {
            Publishers.Remove(publisher);
            OnPropertyChanged(nameof(Publishers));
        }

        public void ShowNewsPaper()
        {
            throw new NotImplementedException();
        }

        public void ShowPublishers()
        {
            throw new NotImplementedException();
        }

        public void UpdateNewsPaper(NewsPaper newspaper, string newName)
        {
            newspaper.Name = newName;
            OnPropertyChanged(nameof(Newspapers));
        }

        public void UpdatePublisher(Publisher publisher, string newName)
        {
            publisher.Name = newName;
            OnPropertyChanged(nameof(Publishers));
        }
    }
}
