using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class ShirtCommand : ICommand
    {
        int id;

        public ShirtCommand()
        {
            id = (int)CommandID.shirt;
        }

        public string GetResponse(Temperature temp)
        {
            return (temp == Temperature.HOT ? "t-shirt" : "shirt");
        }

        public int GetId()
        {
            return this.id;
        }
    }
}