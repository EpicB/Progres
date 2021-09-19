using microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using first.models;
using first.Data;


namespace first.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockFirstRepo _repository = new MockFirstRepo();

        //Get api/commands
        [HttpGet]
        public ActionResult <IEnumarable<command>> GetAllCommands(){
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }
    
    [HttpGet("{id}")]
    public ActionResult <command> GetCommandById(int id)
    {
        var commandItems = _repository.GetCommandById();
    }
}
}