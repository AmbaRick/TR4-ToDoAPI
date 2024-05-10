using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;

namespace ToDo.Tests.ToDoService
{
    public class ToDoServicePut
    {

        private readonly Mock<IToDoRepository> _toDoRepository;
        private readonly ToDoItemService _toDoService;

        public ToDoServicePut()
        {
            _toDoRepository = new Mock<IToDoRepository>();
            _toDoService = new ToDoItemService(_toDoRepository.Object);
        }

        [Fact]
        public async Task UpdateToDoItem_ExistingId_ReturnsTask()
        {
            // Arrange
            string existingId = "1";
            var updatedToDoItem = new ToDoItem { Id = "1", Description = "Description 1 Updated", IsCompleted = true };
            _toDoRepository.Setup(r => r.Update(existingId, updatedToDoItem)).Returns(Task.CompletedTask);

            // Act
            await _toDoService.UpdateToDoItem(existingId, updatedToDoItem);

            // Assert
            _toDoRepository.Verify(r => r.Update(existingId, updatedToDoItem), Times.Once);
        }
    }
}
