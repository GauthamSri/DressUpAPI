using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressUpAPI.Commands
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(int id);
    }
}
