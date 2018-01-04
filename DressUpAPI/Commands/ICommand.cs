using System;
using DressUpAPI.Utility;

namespace DressUpAPI.Commands
{
    public interface ICommand
    {
        string GetResponse(Temperature temp);
        int GetId();
    }
}
