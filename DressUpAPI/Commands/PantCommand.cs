using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class PantCommand : ICommand
    {
        int id;

        public PantCommand()
        {
            id = (int)CommandID.pants;
        }

        public string GetResponse(Temperature temp)
        {
            return (temp == Temperature.HOT ? "shorts" : "pants");
        }

        public int GetId()
        {
            return this.id;
        }
    }
}