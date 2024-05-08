using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Entities;

namespace ToDo.Service.Interfaces
{
    public interface IToDoService
    {
        Task AddToDoItem(ToDoItem toDoItem);

        Task<ToDoItem?> GetToDoItem(string id);
    }
}
