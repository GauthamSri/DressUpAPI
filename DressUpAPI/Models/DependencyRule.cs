using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DressUpAPI.Models
{
    public class DependencyRule
    {
        int primaryCmdId = 0; // the command which should be present in prior
        int dependentCmdId = 0; // the command for which this rule applies
        string temperature = string.Empty;   // conditional rule i.e if the temperature is set, then this rule applies only for that temperature.

        public DependencyRule(int pId, int dId, string temp = null)
        {
            primaryCmdId = pId;
            dependentCmdId = dId;
            temperature = temp;

        }

        public bool ValidateRuleForCmd(List<int> cmds)
        {
            return cmds.Contains(primaryCmdId);

        }

        public int GetSuccessorId()
        {
            return dependentCmdId;
        }

        public string GetConditionalTemp()
        {
            return temperature;
        }
    }
}