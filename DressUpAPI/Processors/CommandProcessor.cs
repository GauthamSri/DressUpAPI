using System;
using System.Collections.Generic;
using System.Linq;
using DressUpAPI.Models;
using DressUpAPI.Commands;
using DressUpAPI.Utility;
using System.Text;

namespace DressUpAPI.Processors
{
    public class CommandProcessor : ICommandProcessor
    {
        ICommandFactory cmdFactory = null;
        IRuleProcessor ruleProcessor = null;

        public CommandProcessor(IRuleProcessor _ruleProcessor, ICommandFactory _cmdFactory)
        {
            ruleProcessor = _ruleProcessor;
            cmdFactory = _cmdFactory;
        }

        public string ProcessCommands(int[] iCmds, Temperature temperature)
        {
            StringBuilder result = new StringBuilder();
            var processedResult = ProcessCmds(iCmds, temperature);

            int i = 0;

            foreach (var res in processedResult.Values)
            {
                if (i != 0)
                {
                    result.Append(",");
                }
                result.Append(res + " ");
                i++;
            }

            return result.ToString();
        }

        protected Dictionary<int, string> ProcessCmds(int[] iCmds, Temperature temperature)
        {

            Dictionary<int, string> output = new Dictionary<int, string>();

            //pajamas must be taken off before wearing any
            if (iCmds[0] != (int)CommandID.takeOffPjs)
            {
                output.Add(-1, State.fail.ToString());
                return output;
            }


            foreach (var cmd in iCmds)
            {
                ICommand command = cmdFactory.CreateCommand(cmd);

                //invalid command check
                if (command == null)
                {
                    output.Add((int)CommandID.fail, State.fail.ToString());
                    return output;
                }

                //Only 1 piece of each type of clothing may be put on
                if (output.Keys.Contains(cmd))
                {
                    output.Add((int)CommandID.fail, State.fail.ToString());
                    return output;
                }

                if (ruleProcessor.ValidateRules(cmd, temperature, output.Keys.ToList()))
                {
                    string response = command.GetResponse(temperature);

                    if (response.Equals(State.fail.ToString()))
                    {
                        output.Add((int)CommandID.fail, State.fail.ToString());
                        return output;
                    }
                    else
                    {
                        output.Add(command.GetId(), response);
                    }
                }
                else
                {
                    output.Add((int)CommandID.fail, State.fail.ToString());
                    return output;
                }
            }

            return output;
        }
    }
}