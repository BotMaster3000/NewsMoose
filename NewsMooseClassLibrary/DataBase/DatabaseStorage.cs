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
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "CREATE TABLE IF NOT EXISTS Publisher (publisher_id varchar(20), publishername varchar(50))";
            command.ExecuteNonQuery();

            command.CommandText = "CREATE TABLE IF NOT EXISTS Newspaper (newspapername varchar(50), publisher_id varchar(20))";
            command.ExecuteNonQuery();
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
            Array publishers = this.LoadDataBase()?.Publishers;
            if (publishers != null)
            {
                foreach (Publisher xpublisher in publishers)
                {
                    if (xpublisher.Name == publisher.Name)
                    {
                        return xpublisher.NewsPapers.ToList();
                    }
                }

            }
            return new List<NewsPaper>();
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
            SQLiteDataReader reader = command.ExecuteReader();

            List<NewsPaper> newspapers = new List<NewsPaper>();
            List<Publisher> publishers = new List<Publisher>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Publisher xpublisher = new Publisher();
                    xpublisher.Name = reader.GetString(1);
                    string publisherid = reader.GetString(0);

                    command.CommandText = "SELECT FROM Newspaper WEHRE publisher_id = '" + publisherid + "'";
                    SQLiteDataReader newsreader = command.ExecuteReader();

                    List<NewsPaper> xnewspapers = new List<NewsPaper>();
                    if (newsreader.HasRows)
                    {
                        while (newsreader.Read())
                        {
                            NewsPaper newspaper = new NewsPaper();
                            newspaper.Name = newsreader.GetString(0);
                            xnewspapers.Add(newspaper);
                        }
                    }
                    newspapers.AddRange(xnewspapers);

                    publishers.Add(xpublisher);
                }
            }

            return new XmlDataBase(newspapers.ToArray(), publishers.ToArray());

        }

        public void SaveDataBase(XmlDataBase database)
        {
            ClearDatabase();

            Dictionary<string, int> publisherNameAndId = new Dictionary<string, int>();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {

                int counter = 0;
                foreach (Publisher publisher in database.Publishers)
                {
                    command.CommandText = $"INSERT INTO Publisher(publisher_id, publishername) VALUES ('{counter}', '{publisher.Name}')";
                    command.ExecuteNonQuery();

                    publisherNameAndId.Add(publisher.Name, counter);

                    ++counter;
                }

                foreach (NewsPaper paper in database.NewsPapers)
                {
                    string publisherID = "NULL";
                    if (paper.Publisher != null && publisherNameAndId.Keys.Contains(paper.Publisher?.Name))
                    {
                        publisherID = publisherNameAndId[paper.Publisher.Name].ToString();
                    }

                    command.CommandText = $"INSERT INTO Newspaper(newspapername, publisher_id) VALUES('{paper.Name}', '{publisherID}');";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ClearDatabase()
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM Publisher";
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM Newspaper";
                command.ExecuteNonQuery();
            }
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
