using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces
{
    /// <summary>
    /// Interface that sets the methods required for the ToDo services from a generic repository
    /// </summary>
    public interface IToDoRepository
    {

        Task Add(ToDoItem newCustomer);

        Task<ToDoItem?> Get(string id);

        Task<List<ToDoItem>> GetAll();

        Task Update(string id, ToDoItem newToDoItem);

        Task Delete(string id);
    }
}
