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
using System.IO;

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
                if (publishers != value)
                {
                    publishers = value;
                    OnPropertyChanged(nameof(Publishers));
                }
            }
        }
        private List<NewsPaper> newspapers = new List<NewsPaper>();
        public List<NewsPaper> NewsPapers
        {
            get { return newspapers; }
            set
            {
                if (newspapers != value)
                {
                    newspapers = value;
                    OnPropertyChanged(nameof(newspapers));
                }
            }
        }

        private XmlStorage database = new XmlStorage();

        public GuiViewModel()
        {
            XmlDataBase tempDataBase = database.LoadDataBase();
            Publishers = tempDataBase.Publishers.ToList();
            NewsPapers = tempDataBase.NewsPapers.ToList();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void SaveData()
        {
            XmlDataBase xmldata = new XmlDataBase(NewsPapers.ToArray(), Publishers.ToArray());
            data.SaveDataBase(xmldata);
        }

        public void CreateNewNewsPaper(string name)
        {
            NewsPaper newnewsletter = new NewsPaper(name);
            bool exist = false;
            foreach (NewsPaper newsletter in NewsPapers)
            {
                if (newsletter.Name == name)
                {
                    exist = true;
                }
            }
            if (!exist)
            {
                NewsPapers.Add(newnewsletter);
                SaveData();
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
                SaveData();
            }
            
            OnPropertyChanged(nameof(Publishers));
        }

        public void DeleteNewsPaper(NewsPaper newsletter)
        {
            if (NewsPapers.Contains(newsletter))
            {
                NewsPapers.Remove(newsletter);
            }
            SaveData();


        }

        public void DeletePublisher(Publisher publisher)
        {
            if (Publishers.Contains(publisher))
            {
                Publishers.Remove(publisher);
            }
            SaveData();

        }

        public void ShowNewsPaper(Publisher publisher)
        {
            NewsPapers = data.GetNewsPapers(publisher);
        }

        public void ShowPublishers()
        {
            Publishers = data.GetPublishers();
        }

        public void UpdateNewsPaper(NewsPaper newsletter, string newName)
        {
            if (NewsPapers.Contains(newsletter))
            {
                if (newName != "")
                {
                    bool exist = false;
                    foreach (NewsPaper xnewsPapers in NewsPapers)
                    {
                        if (xnewsPapers.Name == newName)
                        {
                            exist = true;
                        }
                    }
                    if (!exist)
                    {
                        newsletter.Name = newName;
                        NewsPapers[NewsPapers.IndexOf(newsletter)] = newsletter;
                        SaveData();
                    }
                    else
                    {
                        MessageBox.Show("Der von Ihnen gewählte Zeitungsname ist bereits vorhanden!");
                    }
                }
                else
                {
                    MessageBox.Show("Sie können kein leeren Namen für Zeitungen benutzen.");
                }

            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Zeitung aus, bevor Sie diesen ändern können.");
            }
        }

        public void UpdatePublisher(Publisher publisher, string newName)
        {
            if (Publishers.Contains(publisher))
            {
                if(newName != "")
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
                        SaveData();
                    }
                    else
                    {
                        MessageBox.Show("Der von Ihnen gewählte Verlagsname ist bereits vorhanden!");
                    }
                }
                else
                {
                    MessageBox.Show("Sie können kein leeren Namen für Verlage benutzen.");
                }
                
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Verlag aus, bevor Sie diesen ändern können.");
            }
        }

        public void ShowNewsPaper()
        {
            throw new NotImplementedException();
        }
    }
}
