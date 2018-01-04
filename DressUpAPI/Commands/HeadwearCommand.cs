using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class HeadwearCommand : ICommand
    {
        int id;
        public HeadwearCommand()
        {
            id = (int)CommandID.headwear;
        }

        public string GetResponse(Utility.Temperature temp)
        {
            return (temp == Temperature.HOT ? "sun visor" : "hat");
        }

        public int GetId()
        {
            return this.id;
        }
    }
}