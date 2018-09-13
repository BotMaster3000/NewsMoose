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
    class TuiViewModel : IViewModel
    {
        public List<Publisher> Publishers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<NewsLetter> Newsletters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CreateNewNewsLetter(string name)
        {
            throw new NotImplementedException();
        }

        public void CreateNewPublisher(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteNewsletter(NewsLetter newsletter)
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void ShowNewsletters()
        {
            throw new NotImplementedException();
        }

        public void ShowPublishers()
        {
            throw new NotImplementedException();
        }

        public void UpdateNewsletter(NewsLetter newsletter, string newName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(Publisher publisher, string newName, string oldName)
        {
            throw new NotImplementedException();
        }
    }
}
