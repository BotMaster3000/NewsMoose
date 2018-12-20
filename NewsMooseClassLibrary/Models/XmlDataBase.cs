using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseClassLibrary.Models
{
    public class XmlDataBase
    {
        public NewsPaper[] NewsPapers { get; set; }
        public Publisher[] Publishers { get; set; }
        

        public XmlDataBase(NewsPaper[] newsPapers, Publisher[] publishers)
        {
            NewsPapers = newsPapers;
            Publishers = publishers;
        }
    }
}
