using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commands = _repository.GetAppCommands();

            return Ok(commands);    //Ok 202
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)    //The id comming from binding sources from [FromQuery]
        {
            var command = _repository.GetCommandById(id);

            return Ok(command);
        }
    }
}