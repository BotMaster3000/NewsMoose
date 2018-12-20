using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Models;

namespace NewsMooseClassLibrary.Interfaces
{
    interface IDataBase
    {
        List<NewsPaper> GetNewsPapers();
        void InsertNewsletters(List<NewsPaper> newsPapers);
        void UpdateNewsletters(List<NewsPaper> newsPapers);
        void DeleteNewsLetters(List<NewsPaper> newsPaper);

        List<Publisher> GetPublishers();
        void InsertPublishers(List<Publisher> publishers);
        void UpdatePublishers(List<Publisher> publishers);
        void DeletePublishers(List<Publisher> publishers);

        void SaveDataBase(XmlDataBase database);
        XmlDataBase LoadDataBase();
    }
}
