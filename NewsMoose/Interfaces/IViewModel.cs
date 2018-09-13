using System;
using System.Collections.Generic;
using System.ComponentModel;
using NewsMoose.Models;

namespace NewsMoose.Interfaces
{
    interface IViewModel : INotifyPropertyChanged
    {
        List<Publisher> Publishers { get; set; }
        List<NewsLetter> Newsletters { get; set; }

        void CreateNewPublisher(string name);
        void UpdatePublisher(Publisher publisher, string newName, string oldName);
        void DeletePublisher(Publisher publisher);
        void ShowPublishers();

        void CreateNewNewsLetter(string name);
        void UpdateNewsletter(NewsLetter newsletter, string newName);
        void DeleteNewsletter(NewsLetter newsletter);
        void ShowNewsletters();
    }
}
