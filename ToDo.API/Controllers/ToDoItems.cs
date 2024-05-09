using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Service.Entities;
using ToDo.Service.Interfaces;
using ToDo.Service.ToDoItems;

namespace ToDo.API.Controllers
{
    /// <summary>
    /// API controller to manage the CRUD commands and queries for TODO Items
    /// Creates an DI instance of ToDoService
    /// </summary>
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
            await toDoService.AddToDoItem(newToDoItem);
            return CreatedAtAction(nameof(GetById), new { id = newToDoItem.Id }, newToDoItem);
        }

        [HttpGet]
        public async Task<List<ToDoItem>> GetAll() => await toDoService.GetAllToDoItems();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ToDoItem>> GetById(string id)
        {
            var toDoItem = await toDoService.GetToDoItem(id);

            if (toDoItem == null)
            {
                return NotFound();
            }
            return toDoItem;
            
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ToDoItem UpdatedToDoItem)
        {


            var todoItem = await toDoService.GetToDoItem(id); 

            if (todoItem is null)
            {
                return NotFound();
            }

            UpdatedToDoItem.Id = todoItem.Id;

            await toDoService.UpdateToDoItem(id, UpdatedToDoItem);

            return NoContent();
        
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todoItem = await toDoService.GetToDoItem(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            await toDoService.DeleteToDoItem(id);

            return NoContent();
        }


    }
}
