using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class JacketCommand : ICommand
    {
        int id;

        public JacketCommand()
        {
            id = (int)CommandID.jacket;
        }

        public string GetResponse(Temperature temp)
        {
            return (temp == Temperature.HOT ? State.fail.ToString() : "jacket");
        }

        public int GetId()
        {
            return this.id;
        }
    }
}