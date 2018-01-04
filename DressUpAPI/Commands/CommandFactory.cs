using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DressUpAPI.Utility;

namespace DressUpAPI.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(int id)
        {
            switch((CommandID)id)
            {
                case CommandID.footwear:
                    return new FootwearCommand();

                case CommandID.headwear:
                    return new HeadwearCommand();

                case CommandID.socks:
                    return new SocksCommand();

                case CommandID.shirt:
                    return new ShirtCommand();

                case CommandID.jacket:
                    return new JacketCommand();

                case CommandID.pants:
                    return new PantCommand();

                case CommandID.leaveHouse:
                    return new LeaveHouseCommand();

                case CommandID.takeOffPjs:
                    return new PJCommand();

                default:
                    return null;
            }
        }
    }
}