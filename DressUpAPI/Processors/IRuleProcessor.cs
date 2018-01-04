using System;
using System.Collections.Generic;
using DressUpAPI.Utility;

namespace DressUpAPI.Processors
{
    public interface IRuleProcessor
    {
        bool ValidateRules(int cmdId, Temperature temperature, List<int> processedCmds);
    }
}
