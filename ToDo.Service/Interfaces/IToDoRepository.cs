using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Entities;

namespace ToDo.Service.Interfaces
{
    /// <summary>
    /// Interface that sets the methods required for the ToDo services from a generic repository
    /// </summary>
    public interface IToDoRepository
    {

      ///  Task<List<ToDoItem>> GetAll();

        Task Add(ToDoItem newCustomer);

        Task<ToDoItem?> Get(string id);

        //Task Delete(string id);

        //Task Update(ToDoItem newCustomer);
    }
}
