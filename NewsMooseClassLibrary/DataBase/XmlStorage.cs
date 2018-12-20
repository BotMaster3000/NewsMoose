using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseClassLibrary.Interfaces;
using NewsMooseClassLibrary.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace NewsMooseClassLibrary.DataBase
{
    public class XmlStorage : IDataBase
    {
        private const string DATABASE_NAME = "XmlDataStorage.xml";
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

        public List<Publisher> GetPublishers()
        {
            throw new NotImplementedException();
        }

        public void SaveDataBase(XmlDataBase database)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlDataBase));
            using (StreamWriter writer = new StreamWriter(DATABASE_NAME))
            {
                serializer.Serialize(writer, database);
            }
        }

        public XmlDataBase LoadDataBase()
        {
            XmlDataBase database = null;
            if (File.Exists(DATABASE_NAME))
            {
                using (StreamReader streamReader = new StreamReader(DATABASE_NAME))
                {
                    XmlReader reader = XmlReader.Create(streamReader);
                    XmlSerializer serializer = new XmlSerializer(typeof(XmlDataBase));
                    if (serializer.CanDeserialize(reader))
                    {
                        database = (XmlDataBase)serializer.Deserialize(reader);
                    }
                }
            }
            return database;
        }

        public void InsertNewsletters(List<NewsPaper> newsPapers)
        {
            throw new NotImplementedException();
        }

        public void InsertPublishers(List<Publisher> publishers)
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
