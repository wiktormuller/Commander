using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.DTO;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();

            var model = _mapper.Map<IEnumerable<CommandReadDto>>(commands);

            return Ok(model);    //Ok 202
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)    //The id comming from binding sources from [FromQuery]
        {
            var command = _repository.GetCommandById(id);
            if(command != null)
            {
                var model = _mapper.Map<CommandReadDto>(command);
                return Ok(model);
            }
            return NotFound();  //Instead of NoContent()
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto) //It is CommandReadDto because as a respond of POST method is exactly that dto
        {
            var model = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(model);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(model);    //It;s made for return a response to client as a CommandReadDto to maintain contract - response as a location

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id}, commandReadDto);    //https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            //return Ok(commandReadDto);
        }
    }
}