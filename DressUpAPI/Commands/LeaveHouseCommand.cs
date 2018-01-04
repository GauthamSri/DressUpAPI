using DressUpAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Commands
{
    public class LeaveHouseCommand : ICommand
    {
        int id;

        public LeaveHouseCommand()
        {
            id = (int)CommandID.leaveHouse;
        }

        public string GetResponse(Temperature temp)
        {
            return "leaving house";
        }

        public int GetId()
        {
            return this.id;
        }
    }
}