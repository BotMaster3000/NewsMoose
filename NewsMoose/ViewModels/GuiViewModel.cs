using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMoose.Interfaces;
using NewsMoose.Models;

namespace NewsMoose.ViewModels
{
    class GuiViewModel : IViewModel, INotifyPropertyChanged
    {
        private List<Publisher> publishers;
        public List<Publisher> Publishers
        {
            get { return publishers; }
            set
            {
                // Anmerkung zur Entwicklung!: Nicht vergessen das OnPropertyChanged nicht ausgeführt wird, wenn man einen Publisher direkt ändert, sondern nur wenn die Liste geändert wird
                if (publishers != value)
                {
                    publishers = value;
                    OnPropertyChanged(nameof(Publishers));
                }
            }
        }
        public List<NewsPaper> Newsletters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CreateNewNewsPaper(string name)
        {
            throw new NotImplementedException();
        }

        public void CreateNewPublisher(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteNewsPaper(NewsPaper newsletter)
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void ShowNewsPaper()
        {
            throw new NotImplementedException();
        }

        public void ShowPublishers()
        {
            throw new NotImplementedException();
        }

        public void UpdateNewsPaper(NewsPaper newsletter, string newName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(Publisher publisher, string newName, string oldName)
        {
            throw new NotImplementedException();
        }
    }
}
