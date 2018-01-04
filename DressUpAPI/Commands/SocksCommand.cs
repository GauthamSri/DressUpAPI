using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class SocksCommand : ICommand
    {
        int id;
        public SocksCommand()
        {
            id = (int)CommandID.socks;
        }

        public string GetResponse(Utility.Temperature temp)
        {
            return (temp == Temperature.HOT ? State.fail.ToString() : "socks");
        }

        public int GetId()
        {
            return this.id;
        }
    }
}