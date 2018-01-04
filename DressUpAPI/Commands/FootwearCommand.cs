using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DressUpAPI.Utility;

namespace DressUpAPI.Commands
{
    public class FootwearCommand : ICommand
    {
        int id;

        public FootwearCommand()
        {
            id = (int)CommandID.footwear;
        }

        public string GetResponse(Temperature temp)
        {
            return (temp == Temperature.HOT ? "sandals" : "boots");
        }

        public int GetId()
        {
            return this.id;
        }
    }
}