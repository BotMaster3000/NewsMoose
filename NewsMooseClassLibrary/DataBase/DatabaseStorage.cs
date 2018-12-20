using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Interfaces;
using NewsMooseClassLibrary.Models;
using System.Data.SQLite;

namespace NewsMooseClassLibrary.DataBase
{
    public class DatabaseStorage : IDataBase
    {
        private string DATA_SOURCE = "DataBase.sqlite";
        SQLiteConnection connection;

        public DatabaseStorage()
        {
            connection = new SQLiteConnection("Data Source=" + DATA_SOURCE);
            connection.Open();
        }

        public void DeleteNewsLetters(List<NewsPaper> newsPaper)
        {
            throw new NotImplementedException();
        }

        public void DeletePublishers(List<Publisher> publishers)
        {
            throw new NotImplementedException();
        }

        public List<NewsPaper> GetNewsPapers()
        {
            throw new NotImplementedException();
        }

        public List<NewsPaper> GetNewsPapers(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public List<Publisher> GetPublishers()
        {
            throw new NotImplementedException();
        }

        public void InsertNewsletters(List<NewsPaper> newsPapers)
        {
            throw new NotImplementedException();
        }

        public void InsertPublishers(List<Publisher> publishers)
        {
            throw new NotImplementedException();
        }

        public XmlDataBase LoadDataBase()
        {
            throw new NotImplementedException();
        }

        public void SaveDataBase(XmlDataBase database)
        {
            throw new NotImplementedException();
        }

        public void UpdateNewsletters(List<NewsPaper> newsPapers)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublishers(List<Publisher> publishers)
        {
            throw new NotImplementedException();
        }
    }
}
