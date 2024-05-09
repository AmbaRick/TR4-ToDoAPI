using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using ToDo.API.Controllers;
using ToDo.Infrastructure.Data;
using ToDo.Service.Entities;
using ToDo.Service.Interfaces;
using ToDo.Service.ToDoItems;
using Xunit;
using static MongoDB.Libmongocrypt.CryptContext;

namespace ToDo.Tests
{

    /// <summary>
    /// Tests to ensure expected results from API 
    /// </summary>
    public class UnitTestsAPI
    {
        //mock reference to service
        private readonly Mock<IToDoService> toDoItemService;

        public UnitTestsAPI()
        {
            toDoItemService = new Mock<IToDoService>();
        }

       

        [Fact]
        public async void GetToDoItemList_ReturnsList()
        {
            //Set up
            var expected = new List<ToDoItem>(){
                new ToDoItem {
                    Id = "ObjectID1212123",
                    Description = "Test Task 1",
                    IsCompleted = false

                },
                new ToDoItem {
                    Id = "ObjectID1212dd123",
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
            Assert.Equal(expected, result);
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

      //TODO: add more unit tests - covering other operations


       
    }
}