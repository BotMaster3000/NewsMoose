using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseClassLibrary.Models
{
    public class Publisher
    {
        public string Name { get; set; }
        public List<NewsPaper> NewsPapers { get; set; } = new List<NewsPaper>();

        public Publisher(string name, List<NewsPaper> newsPapers = null)
        {
            Name = name;
            NewsPapers = NewsPapers;
        }

        public Publisher()
        {

        }
    }
}
