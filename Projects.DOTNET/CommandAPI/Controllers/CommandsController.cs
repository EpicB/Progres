using System.Collections.Generic;
using CommandAPI.Data;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;
using AutoMapper;
using CommandAPI.Dtos;
namespace CommandAPI.Controllers
{
 [Route("api/Commands")]
 [ApiController]
 public class CommandsController : ControllerBase
 {
    private readonly IMapper _mapper;
    private readonly ICommandAPIRepo _repository;
    public CommandsController(ICommandAPIRepo repository,IMapper mapper)
    {
    _mapper = mapper;
    _repository = repository;
    }
    

    /*[HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
    return new string[] {  "this", "is", "hard", "coded"};
    }
    */
    [HttpGet]
        public ActionResult<CommandReadDto> GetAllCommands()
        {
        var commandItems = _repository.GetAllCommands();
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        [HttpGet("{id}",Name="GetCommandById")] 
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
        var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
                {
                return  StatusCode(403);
                }
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand (CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById),
            new {Id = commandReadDto.Id}, commandReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                {
                return NotFound();
                }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            //_repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
                {
                return NotFound();
                }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
