using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DressUpAPI.Utility;
using DressUpAPI.Processors;
using DressUpAPI.Commands;
using System.Collections.Generic;

namespace DressUpAPI.Tests.Controllers
{
    [TestClass]
    public class CommandProcessorTest
    {
        class CommandProcessorWrapper : CommandProcessor
        {
            public CommandProcessorWrapper(IRuleProcessor _ruleProcessor, ICommandFactory _cmdFactory)
                : base(_ruleProcessor, _cmdFactory)
            {

            }

            public new Dictionary<int, string> ProcessCmds(int[] iCmds, Temperature temperature)
            {
                return base.ProcessCmds(iCmds, temperature);
            }
        }

        //Wrote only limited test cases due to time constraints but to get an idea of test cases

        [TestMethod]
        public void SuccessCase1Test()
        {
            string temperature = Temperature.HOT.ToString();

            int[] cmds = new int[] { (int)CommandID.takeOffPjs, (int)CommandID.pants, (int)CommandID.shirt, (int)CommandID.headwear, (int)CommandID.footwear, (int)CommandID.leaveHouse };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.HOT);

            Assert.AreEqual(6, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.takeOffPjs), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.pants), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.shirt), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.headwear), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.footwear), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.leaveHouse), "expected command not found");
        }

        [TestMethod]
        public void SuccessCase2Test()
        {
            string temperature = Temperature.COLD.ToString();

            int[] cmds = new int[] { (int)CommandID.takeOffPjs, (int)CommandID.pants, (int)CommandID.socks, (int)CommandID.shirt, (int)CommandID.headwear, (int)CommandID.jacket, (int)CommandID.footwear, (int)CommandID.leaveHouse };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.COLD);

            Assert.AreEqual(8, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.takeOffPjs), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.pants), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.socks), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.shirt), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.headwear), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.jacket), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.footwear), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.leaveHouse), "expected command not found");
        }

        [TestMethod]
        public void FailureCase1Test()
        {
            string temperature = Temperature.HOT.ToString();
            int[] cmds = new int[] { (int)CommandID.takeOffPjs, (int)CommandID.pants, (int)CommandID.pants };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.HOT);

            Assert.AreEqual(3, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.takeOffPjs), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.pants), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.fail), "expected command not found");
        }

        [TestMethod]
        public void FailureCase2Test()
        {
            string temperature = Temperature.HOT.ToString();
            int[] cmds = new int[] { (int)CommandID.takeOffPjs, (int)CommandID.pants, (int)CommandID.socks };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.HOT);

            Assert.AreEqual(3, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.takeOffPjs), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.pants), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.fail), "expected command not found");
        }

        [TestMethod]
        public void FailureCase3Test()
        {
            string temperature = Temperature.COLD.ToString();
            int[] cmds = new int[] { (int)CommandID.takeOffPjs, (int)CommandID.pants, (int)CommandID.socks, (int)CommandID.shirt, (int)CommandID.headwear, (int)CommandID.jacket, (int)CommandID.leaveHouse };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.COLD);

            Assert.AreEqual(7, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.takeOffPjs), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.pants), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.socks), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.shirt), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.headwear), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.jacket), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.fail), "expected command not found");
        }

        [TestMethod]
        public void FailureCase4Test()
        {
            string temperature = Temperature.COLD.ToString();
            int[] cmds = new int[] { (int)CommandID.pants };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.COLD);

            Assert.AreEqual(1, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.fail), "expected command not found");
        }

        [TestMethod]
        public void FailureCaseInValidCommand()
        {
            string temperature = Temperature.COLD.ToString();

            int[] cmds = new int[] { (int)CommandID.takeOffPjs, (int)CommandID.pants, (int)CommandID.socks, 15 };

            var commandProcessor = new CommandProcessorWrapper(new RuleProcessor(), new CommandFactory());
            var output = commandProcessor.ProcessCmds(cmds, Temperature.COLD);


            Assert.AreEqual(4, output.Count, "Incorrect number of output commands received");
            Assert.IsTrue(output.ContainsKey((int)CommandID.takeOffPjs), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.pants), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.socks), "expected command not found");
            Assert.IsTrue(output.ContainsKey((int)CommandID.fail), "expected command not found");
        }
    }
}
