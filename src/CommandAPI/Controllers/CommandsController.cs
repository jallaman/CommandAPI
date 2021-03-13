using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;
using CommandAPI.Data;

namespace CommandAPI.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
      public class CommandsController : ControllerBase
      {

        // Add the following code for DI to work
        private readonly ICommandAPIRepo _repository;

        public CommandsController(ICommandAPIRepo repository)
        {
          _repository = repository;
        }
        [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //   return new string [] {"this", "is", "hard", "coded"};
        // }
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
          var commandItems = _repository.GetAllCommands();
          return Ok(commandItems);
        }

        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<Command>> GetCommandById(int id)
        {
          var commandItem = _repository.GetCommandById(id);
          if (commandItem == null){
            return NotFound();
          }
          return Ok(commandItem);
        }
      }

}