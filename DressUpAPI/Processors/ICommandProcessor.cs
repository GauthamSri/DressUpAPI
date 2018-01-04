using System;
using System.Collections.Generic;
using DressUpAPI.Models;
using DressUpAPI.Utility;


namespace DressUpAPI.Processors
{
    public interface ICommandProcessor
    {
        string ProcessCommands(int[] iCmds, Temperature temperature);
    }
}
