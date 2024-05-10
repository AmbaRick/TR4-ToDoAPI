using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.API.Controllers;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;

namespace ToDo.Tests.ToDoAPIController
{

    /// <summary>
    /// Tests or the ToDO controller when creating a new To Do item
    /// 
    /// </summary>
    public class ToDoControllerGetTest
    {
        //mock reference to service
        private readonly Mock<IToDoRepository> _toDoRepository;
        private readonly Mock<IToDoService> toDoItemService;

        public ToDoControllerGetTest()
        {

            toDoItemService = new Mock<IToDoService>();
        }

        [Fact]
        public async void GetToDoItemList_ReturnsList()
        {
            //Set up
            var expected = new List<ToDoItem>(){
                new ToDoItem {
                    Id =  "ObjectID1212123",
                    Description = "Test Task 1",
                    IsCompleted = false

                },
                new ToDoItem {
                    Id =  "ObjectID1212dd123",
                    Description = "Test Task 2",
                    IsCompleted = true
                }
                ,
                new ToDoItem {
                    Id = "ObjectID121ddff2123",
                    Description = "Test Task 3",
                    IsCompleted = false
                }
            };

            toDoItemService.Setup(x => x.GetAllToDoItems())
                .Returns(Task.FromResult(expected));


            //Act

            var toDoController = new ToDoItemController(toDoItemService.Object);
            var result = await toDoController.GetAll();

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void GetToDoItemList_ReturnsOneResult()
        {

            //Set up
            var expected = new ToDoItem
            {
                Id = "ObjectID1212123",
                Description = "Test Task 1",
                IsCompleted = false

            };


            toDoItemService.Setup(x => x.GetToDoItem(expected.Id))
                .ReturnsAsync(expected);

            var toDoController = new ToDoItemController(toDoItemService.Object);


            //Act
            string IdExpected = "ObjectID1212123";
            var result = await toDoController.GetById(IdExpected);


            //Assert
            //Checking the result did return and the result exists.
            Assert.IsType<ActionResult<ToDoItem>>(result);
            Assert.NotNull(result);
        }
    }
}
