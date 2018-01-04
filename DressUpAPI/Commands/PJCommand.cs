using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class PJCommand : ICommand
    {
        int id;

        public PJCommand()
        {
            id = (int)CommandID.takeOffPjs;
        }

        public string GetResponse(Temperature temp)
        {
            return "Removing PJs";
        }

        public int GetId()
        {
            return this.id;
        }
    }
}