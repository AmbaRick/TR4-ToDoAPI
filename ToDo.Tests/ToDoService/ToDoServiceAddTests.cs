using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;
using ToDo.Core;

namespace ToDo.Tests.ToDoService
{
    public class ToDoServiceAddTests
    {
        private readonly Mock<IToDoRepository> _toDoRepository;
        private readonly ToDoItemService _toDoService;

        public ToDoServiceAddTests()
        {
            _toDoRepository = new Mock<IToDoRepository>();
            _toDoService = new ToDoItemService(_toDoRepository.Object);
        }

        [Fact]
        public async Task AddToDoItem_ValidItem_ReturnsTask()
        {
            // Arrange
            var toDoItem = new ToDoItem {Description = "Task Test 1", IsCompleted = false };

            // Act
            await _toDoService.AddToDoItem(toDoItem);

            // Assert
            _toDoRepository.Verify(r => r.Add(toDoItem), Times.Once);
        }

        [Fact]
        public async Task GetAllToDoItems_ReturnsListOfToDoItems()
        {
            // Arrange
            var expectedToDoItems = new List<ToDoItem>
            {
                new ToDoItem { Id = "1", Description = "Description 1", IsCompleted = false },
                new ToDoItem { Id = "2",  Description = "Description 2", IsCompleted = true },
                new ToDoItem { Id = "3",  Description = "Description 3", IsCompleted = false }
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

        [Fact]
        public async Task UpdateToDoItem_ExistingId_ReturnsTask()
        {
            // Arrange
            string existingId = "1";
            var updatedToDoItem = new ToDoItem { Id = "1",  Description = "Description 1 Updated", IsCompleted = true };
            _toDoRepository.Setup(r => r.Update(existingId, updatedToDoItem)).Returns(Task.CompletedTask);

            // Act
            await _toDoService.UpdateToDoItem(existingId, updatedToDoItem);

            // Assert
            _toDoRepository.Verify(r => r.Update(existingId, updatedToDoItem), Times.Once);
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

        [Fact]
        public async Task DeleteToDoItem_NonExistingId_ThrowsException()
        {
            // Arrange
            string nonExistingId = "100";
            _toDoRepository.Setup(r => r.Delete(nonExistingId)).Returns(Task.CompletedTask);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _toDoService.DeleteToDoItem(nonExistingId));
        }
    }

}

