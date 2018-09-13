using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMoose.Interfaces;
using NewsMoose.Models;

namespace NewsMoose.DataStorage
{
    class DatabaseStorage : IDataBase
    {
        public void DeleteNewsLetters(List<NewsLetter> newsLetter)
        {
            throw new NotImplementedException();
        }

        public void DeletePublishers(List<Publisher> publishers)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetNewsletters()
        {
            throw new NotImplementedException();
        }

        public List<Publisher> GetPublishers()
        {
            throw new NotImplementedException();
        }

        public void InsertNewsletters(List<NewsLetter> newsLetters)
        {
            throw new NotImplementedException();
        }

        public void InsertPublishers(List<Publisher> publishers)
        {
            throw new NotImplementedException();
        }

        public void UpdateNewsletters(List<NewsLetter> newsLetters)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublishers(List<Publisher> publishers)
        {
            throw new NotImplementedException();
        }
    }
}
