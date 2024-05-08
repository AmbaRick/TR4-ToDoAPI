using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Entities;

namespace ToDo.Service.Interfaces
{
    //interface to set methods available for service
    public interface IToDoService
    {
        Task AddToDoItem(ToDoItem toDoItem);

        Task<ToDoItem?> GetToDoItem(string id);

        Task<List<ToDoItem>> GetAllToDoItems();

        Task UpdateToDoItem(string id,  ToDoItem toDoItem);

        Task DeleteToDoItem(string id);
    }
}
