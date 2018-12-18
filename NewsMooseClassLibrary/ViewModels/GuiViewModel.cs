using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Interfaces;
using NewsMooseClassLibrary.DataBase;
using NewsMooseClassLibrary.Models;
using System.Windows;

namespace NewsMooseClassLibrary.ViewModels
{
    public class GuiViewModel : IViewModel, INotifyPropertyChanged
    {

        
        private IDataBase data = new DatabaseStorage();

        private List<Publisher> publishers = new List<Publisher>();
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
        private List<NewsPaper> newsPapers = new List<NewsPaper>();
        public List<NewsPaper> NewsPapers
        {
            get { return newsPapers; }
            set
            {
                // Anmerkung zur Entwicklung!: Nicht vergessen das OnPropertyChanged nicht ausgeführt wird, wenn man einen Publisher direkt ändert, sondern nur wenn die Liste geändert wird
                if (newsPapers != value)
                {
                    newsPapers = value;
                    OnPropertyChanged(nameof(newsPapers));
                }
            }
        }

        public List<NewsPaper> Newspapers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CreateNewNewsPaper(string name)
        {
            Publisher publisher = new Publisher(name);
            if (publishers.Contains(publisher)){
                NewsPaper newsletter = new NewsPaper(name,publisher);
                
            }
        }

        public void CreateNewPublisher(string name)
        {
            Publisher newPublisher = new Publisher(name);
            bool exist = false;
            foreach (Publisher publisher in Publishers) {
                if (publisher.Name == name) {
                    exist = true;
                }
            }
            if (!exist)
            {
                Publishers.Add(newPublisher);
                //data.InsertPublishers(Publishers);
            }
            
            OnPropertyChanged(nameof(Publishers));
        }

        public void DeleteNewsPaper(NewsPaper newsletter)
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(Publisher publisher)
        {
            if (Publishers.Contains(publisher))
            {
                Publishers.Remove(publisher);
            }
            //data.DeletePublisher(publisher)

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

        public void UpdatePublisher(Publisher publisher, string newName)
        {
            if (Publishers.Contains(publisher))
            {
                bool exist = false;
                foreach (Publisher xpublisher in Publishers)
                {
                    if (xpublisher.Name == newName)
                    {
                        exist = true;
                    }
                }
                if (!exist)
                {
                    publisher.Name = newName;
                    Publishers[Publishers.IndexOf(publisher)] = publisher;
                }
                else
                {
                    MessageBox.Show("Der von Ihnen gewählte Verlagsname ist bereits vorhanden!");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Verlag aus, bevor Sie diesen ändern können.");
            }
        }
    }
}
