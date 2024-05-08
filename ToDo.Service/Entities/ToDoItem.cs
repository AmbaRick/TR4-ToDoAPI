using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Service.Entities
{
    /// <summary>
    /// Class to define the properties of ToDoItem
    /// </summary>
    public class ToDoItem
    {
        public string? Id { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
