using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseConsole.Interfaces
{
    public interface ICommandController
    {
        bool CanExecute(string command);
        void Execute(string command);
    }
}
