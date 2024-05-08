using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ToDo.Service.Entities;


namespace ToDo.Infrastructure.Data
{
    /// <summary>
    /// Creates the Instance of database based on MongoDB Settings
    /// </summary>
    public class ToDoRepositorySetUp
    {
        public IMongoCollection<ToDoItem> ToDoItems
        {

            get;

        }

        public ToDoRepositorySetUp(IOptions<ToDoRepositorySettings> customerDBSettings)
        {
            ToDoRepositoryMapping.Instance
               .RegisterToDoRepository<ToDoItem>(cm =>
               {
               });
            var mongoClient = new MongoClient(customerDBSettings.Value.ConnectionString);
            var toDoDatabase = mongoClient.GetDatabase(customerDBSettings.Value.DatabaseName);

            this.ToDoItems = toDoDatabase.GetCollection<ToDoItem>(customerDBSettings.Value.CollectionName);
        }
    }

}

