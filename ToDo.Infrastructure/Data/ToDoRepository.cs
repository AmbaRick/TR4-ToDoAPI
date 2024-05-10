using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
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
        public ToDoRepository(IOptions<ToDoRepositorySettings> toDoRepositorySettings)
        {
            ToDoRepositorySetUp ToDoRepository = new ToDoRepositorySetUp(toDoRepositorySettings);
            toDoItemList = ToDoRepository.ToDoItems;
        }
        public async Task Add(ToDoItem newToDoItem) =>
          await toDoItemList.InsertOneAsync(newToDoItem);

        public async Task<ToDoItem?> Get(string id) =>
        await toDoItemList.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<ToDoItem>> GetAll() => await toDoItemList.Find(_ => true).ToListAsync();

        public async Task Update(string id, ToDoItem newToDoItem) => await toDoItemList.ReplaceOneAsync(x => x.Id == id, newToDoItem);

        public async Task Delete(string id) => await toDoItemList.DeleteOneAsync(x => x.Id == id);

    }
}
