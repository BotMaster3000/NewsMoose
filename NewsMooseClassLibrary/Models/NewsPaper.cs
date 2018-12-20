using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseClassLibrary.Models
{
    public class NewsPaper
    {
        public string Name { get; set; }
        public Publisher Publisher { get; set; }

        public NewsPaper(string name, Publisher publisher = null)
        {
            Name = name;
            Publisher = publisher;
        }

        public NewsPaper()
        {

        }
    }
}
