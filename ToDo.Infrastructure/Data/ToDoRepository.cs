using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Entities;
using ToDo.Service.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace ToDo.Infrastructure.Data
{
    /// <summary>
    /// Sets up the instance of MongoDB and creates CRUD commands and queries
    /// </summary>
    public class ToDoRepository : IToDoRepository
    {
        public readonly IMongoCollection<ToDoItem> toDoItemList;
        //TODO: check this is being injected
        public ToDoRepository(IOptions<ToDoRepositorySettings> toDoRepositorySettings)
        {
            ToDoRepositorySetUp ToDoRepository = new ToDoRepositorySetUp(toDoRepositorySettings);
            toDoItemList = ToDoRepository.ToDoItems;
        }
        public async Task Add(ToDoItem newToDoItem) =>
          await toDoItemList.InsertOneAsync(newToDoItem);
    }
}
