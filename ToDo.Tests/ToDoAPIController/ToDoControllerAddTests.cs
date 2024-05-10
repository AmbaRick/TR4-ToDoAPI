using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;
using ToDo.Infrastructure.Data;

namespace ToDo.Tests.ToDoAPIController
{

    /// <summary>
    /// Tests or the ToDO controller when creating a new To Do item
    /// </summary>
    public class ToDoControllerAddTests
    {
        //mock reference to service
        private readonly Mock<IToDoRepository> _toDoRepository;
        private readonly Mock<IToDoService> toDoItemService;

        public ToDoControllerAddTests()
        {

            toDoItemService = new Mock<IToDoService>();
        }

       
    }
}
