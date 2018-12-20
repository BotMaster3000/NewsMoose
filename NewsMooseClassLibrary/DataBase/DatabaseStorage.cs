using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Interfaces;
using NewsMooseClassLibrary.Models;
using System.Data.SQLite;
using System.IO;

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

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(DATA_SOURCE))
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE Publisher (publisher_id varchar(20), publishername varchar(50))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Newspaper (newspapername varchar(50), publisher_id varchar(20))";
                command.ExecuteNonQuery();
            }
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
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Publisher";
            command.ExecuteNonQuery();
            SQLiteDataReader reader =  command.ExecuteReader();

            List <Publisher> publishers = new List<Publisher>();
            foreach(Publisher xpublisher in reader)
            {
                publishers.Add(xpublisher);
            }
            List<NewsPaper> newspaper = new List<NewsPaper>();
            foreach (NewsPaper xnewspaper in reader)
            {
                newspaper.Add(xnewspaper);
            }

            XmlDataBase xmldata = new XmlDataBase(newspaper.ToArray(), publishers.ToArray());
            return xmldata;
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
