using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;

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
        //TODO: sepearte the methods in to their own classes to keep the code clean
        //TODO: review way set the endpoints - consider FastEndPoints 
        private readonly IToDoService toDoService;

        public ToDoItemController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        /// <summary>
        /// API method to add an item to the todo list
        /// </summary>
        /// <param name="newToDoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(ToDoItem newToDoItem)
        {
            newToDoItem.Id = string.Empty;
            await toDoService.AddToDoItem(newToDoItem);
            return CreatedAtAction(nameof(GetById), new { id = newToDoItem.Id }, newToDoItem);
        }

        /// <summary>
        /// API method to Get all todo items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ToDoItem>> GetAll() => await toDoService.GetAllToDoItems();


        //TODO: add validation on to input
        /// <summary>
        /// API method to get a ToDo item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// API method to update a to do item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UpdatedToDoItem"></param>
        /// <returns></returns>
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

            return Ok();
        
        }


        /// <summary>
        /// API method to delete a totdo item based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todoItem = await toDoService.GetToDoItem(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            await toDoService.DeleteToDoItem(id);

            return Ok();
        }


    }
}
