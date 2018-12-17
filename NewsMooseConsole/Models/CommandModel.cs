using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMooseConsole.Interfaces;

namespace NewsMooseConsole.Models
{
    public class CommandModel : ICommandModel
    {
        public bool CanExecute { get; set; }
        public Action Method { get; set; }
        public string Name { get; set; }
    }
}
