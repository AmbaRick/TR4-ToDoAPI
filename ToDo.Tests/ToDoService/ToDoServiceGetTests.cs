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
    public class ToDoServiceGetTests
    {

        private readonly Mock<IToDoRepository> _toDoRepository;
        private readonly ToDoItemService _toDoService;

        public ToDoServiceGetTests()
        {
            _toDoRepository = new Mock<IToDoRepository>();
            _toDoService = new ToDoItemService(_toDoRepository.Object);
        }

        [Fact]
        public async Task GetAllToDoItems_ReturnsListOfToDoItems()
        {
            // Arrange
            var expectedToDoItems = new List<ToDoItem>
            {
                new ToDoItem { Id = "GUid1234567891234567890", Description = "Task 1", IsCompleted = false },
                new ToDoItem { Id = "GUid1234567891234567891",  Description = "Task 2", IsCompleted = true },
                new ToDoItem { Id = "GUid1234567891234567892",  Description = "Task 3", IsCompleted = false }
            };
            _toDoRepository.Setup(r => r.GetAll()).ReturnsAsync(expectedToDoItems);

            // Act
            var result = await _toDoService.GetAllToDoItems();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedToDoItems, result);
        }

        [Fact]
        public async Task GetToDoItem_ExistingId_ReturnsToDoItem()
        {
            // Arrange
            string existingId = "1";
            var expectedToDoItem = new ToDoItem { Id = "1", Description = "Description 1", IsCompleted = false };
            _toDoRepository.Setup(r => r.Get(existingId)).ReturnsAsync(expectedToDoItem);

            // Act
            var result = await _toDoService.GetToDoItem(existingId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedToDoItem, result);
        }

        [Fact]
        public async Task GetToDoItem_NonExistingId_ReturnsNull()
        {
            // Arrange
            string nonExistingId = "100";
            _toDoRepository.Setup(r => r.Get(nonExistingId)).ReturnsAsync((ToDoItem)null);

            // Act
            var result = await _toDoService.GetToDoItem(nonExistingId);

            // Assert
            Assert.Null(result);
        }

       
    }
}
