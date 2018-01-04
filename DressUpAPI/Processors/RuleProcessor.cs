using System;
using System.Collections.Generic;
using System.Linq;
using DressUpAPI.Models;
using DressUpAPI.Utility;

namespace DressUpAPI.Processors
{
    public class RuleProcessor : IRuleProcessor
    {
        List<DependencyRule> rules = null;


        public RuleProcessor()
        {
            loadRules();
        }

        //Rules can be added here
        public void loadRules()
        {
            rules = new List<DependencyRule>();

            rules.Add(new DependencyRule((int)CommandID.socks, (int)CommandID.footwear, Temperature.COLD.ToString())); //conditional rule i.e this rule applies only for the specified temperature
            rules.Add(new DependencyRule((int)CommandID.pants, (int)CommandID.footwear));
            rules.Add(new DependencyRule((int)CommandID.shirt, (int)CommandID.headwear));
            rules.Add(new DependencyRule((int)CommandID.shirt, (int)CommandID.jacket));
            rules.Add(new DependencyRule((int)CommandID.footwear, (int)CommandID.leaveHouse));
            rules.Add(new DependencyRule((int)CommandID.headwear, (int)CommandID.leaveHouse));
            rules.Add(new DependencyRule((int)CommandID.socks, (int)CommandID.leaveHouse, Temperature.COLD.ToString()));
            rules.Add(new DependencyRule((int)CommandID.shirt, (int)CommandID.leaveHouse));
            rules.Add(new DependencyRule((int)CommandID.jacket, (int)CommandID.leaveHouse, Temperature.COLD.ToString()));
            rules.Add(new DependencyRule((int)CommandID.pants, (int)CommandID.leaveHouse));

        }

        public bool ValidateRules(int cmdId, Temperature temperature, List<int> processedCmds)
        {
            var applicableRules = rules.Where(t => t.GetSuccessorId() == cmdId && (string.IsNullOrEmpty(t.GetConditionalTemp()) || t.GetConditionalTemp().Equals(temperature))).Select(t => t).ToList();

            foreach (var rule in applicableRules)
            {
                if (!(rule.ValidateRuleForCmd(processedCmds)))
                {
                    return false;
                }
            }
            return true;
        }

    }
}