using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMoose.Models
{
    class Publisher
    {
        public string Name { get; set; }
        public List<NewsPaper> NewsPapers { get; set; }

        public Publisher(string name, List<NewsPaper> newsPapers = null)
        {
            Name = name;
            NewsPapers = NewsPapers;
        }
    }
}
