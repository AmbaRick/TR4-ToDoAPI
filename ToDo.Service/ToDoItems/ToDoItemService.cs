using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Entities;


using ToDo.Service.Interfaces;

namespace ToDo.Service.ToDoItems
{
    public class ToDoItemService : IToDoService
    {
        private readonly IToDoRepository toDoRepository;
        public ToDoItemService(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }
        public async Task Add(ToDoItem newToDoItem) =>
          await this.toDoRepository.Add(newToDoItem);
    }
}
