using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseConsole.Interfaces
{
    public interface ICommandModel
    {
        bool CanExecute { get; set; }
        Action Method { get; set; }
        string Name { get; set; }
    }
}
