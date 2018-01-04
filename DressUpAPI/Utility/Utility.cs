using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Utility
{
    public enum Temperature
    {
        HOT = 1,
        COLD = 2
    }

    public enum State
    {
        fail
    }

    // this enum is to avoid hardcording id values throughout the code
    public enum CommandID
    {
        footwear = 1,
        headwear = 2,
        socks = 3,
        shirt = 4,
        jacket = 5,
        pants = 6,
        leaveHouse = 7,
        takeOffPjs = 8,
        fail = -1
    }
}