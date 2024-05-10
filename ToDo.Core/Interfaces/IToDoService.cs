using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces
{
    //interface to set methods available for service
    public interface IToDoService
    {

        //TODO: add excpetion handling throughout the method
        Task AddToDoItem(ToDoItem toDoItem);

        Task<ToDoItem?> GetToDoItem(string id);

        Task<List<ToDoItem>> GetAllToDoItems();

        Task UpdateToDoItem(string id,  ToDoItem toDoItem);

        Task DeleteToDoItem(string id);
    }
}
