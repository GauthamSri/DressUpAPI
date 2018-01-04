using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DressUpAPI.Processors;
using DressUpAPI.Utility;
using DressUpAPI.Models;
using Newtonsoft.Json;
using System.Web.Http.Results;
using Newtonsoft.Json.Serialization;

namespace DressUpAPI.Controllers
{
    public class CommandsController : ApiController
    {
        ICommandProcessor commandProcessor;

        public CommandsController(ICommandProcessor _commandProcessor)
        {
            commandProcessor = _commandProcessor;
        }


        [HttpGet]
        public HttpResponseMessage GetProcessedResult(string temperature, [FromUri]int[] cmds)
        {
            try
            {
                Temperature temp = (Temperature)Enum.Parse(typeof(Temperature), temperature);
                return Request.CreateResponse(commandProcessor.ProcessCommands(cmds, temp));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }
            
        }
    }
}
