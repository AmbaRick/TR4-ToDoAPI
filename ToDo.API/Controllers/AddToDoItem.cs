using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Service.Entities;
using ToDo.Service.Interfaces;
using ToDo.Service.ToDoItems;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoService toDoService;

        public ToDoItemController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ToDoItem newToDoItem)
        {
            await toDoService.Add(newToDoItem);
            return CreatedAtAction(nameof(GetById), new { id = newToDoItem.Id }, newToDoItem);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ToDoItem>> GetById(string id)
        { 
            //TODO: Set up for mocking purposes
        //    var toDoItem = await toDoService.GetEntryById(id);

        //    if (toDoItem == null)
        //    {
        //        return NotFound();
        //    }
        //    return toDoItem;
            ToDoItem toDoDoItem = new ToDoItem();
            toDoDoItem.Id = id;
            return toDoDoItem;
        }
    }
}
