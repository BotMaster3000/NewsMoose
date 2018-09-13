using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMoose.Models;

namespace NewsMoose.Interfaces
{
    interface IDataBase
    {
        List<NewsLetter> GetNewsletters();
        void InsertNewsletters(List<NewsLetter> newsLetters);
        void UpdateNewsletters(List<NewsLetter> newsLetters);

        List<Publisher> GetPublishers();
        void InsertPublishers(List<Publisher> publishers);
        void UpdatePublishers(List<Publisher> publishers);
    }
}
