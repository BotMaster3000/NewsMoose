using System;
using System.Collections.Generic;
using System.ComponentModel;
using NewsMooseClassLibrary.Models;

namespace NewsMooseClassLibrary.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged
    {
        List<Publisher> Publishers { get; set; }
        List<NewsPaper> Newspapers { get; set; }

        void CreateNewPublisher(string name);
        void UpdatePublisher(Publisher publisher, string newName);
        void DeletePublisher(Publisher publisher);
        void ShowPublishers();

        void CreateNewNewsPaper(string name);
        void UpdateNewsPaper(NewsPaper newsPaper, string newName);
        void DeleteNewsPaper(NewsPaper newsPaper);
        void ShowNewsPaper();
    }
}
