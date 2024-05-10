using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;

namespace ToDo.Tests.ToDoService
{
    public class ToDoServiceDelete
    {
        private readonly Mock<IToDoRepository> _toDoRepository;
        private readonly ToDoItemService _toDoService;

        public ToDoServiceDelete()
        {
            _toDoRepository = new Mock<IToDoRepository>();
            _toDoService = new ToDoItemService(_toDoRepository.Object);
        }

        
        [Fact]
        public async Task DeleteToDoItem_ExistingId_ReturnsTask()
        {
            // Arrange
            string existingId = "1";
            _toDoRepository.Setup(r => r.Delete(existingId)).Returns(Task.CompletedTask);

            // Act
            await _toDoService.DeleteToDoItem(existingId);

            // Assert
            _toDoRepository.Verify(r => r.Delete(existingId), Times.Once);
        }
    }
}
