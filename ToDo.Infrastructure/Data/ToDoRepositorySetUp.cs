using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ToDo.Core.Entities;


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
            try
            {
                var mongoClient = new MongoClient(customerDBSettings.Value.ConnectionString);
                var toDoDatabase = mongoClient.GetDatabase(customerDBSettings.Value.DatabaseName);

                this.ToDoItems = toDoDatabase.GetCollection<ToDoItem>(customerDBSettings.Value.CollectionName);
            }
            catch (Exception ex)
            {
                //TODO: add error handling for connection issues etc. would send to log. for not just throw .
                throw (ex);
            }

        }
    }

}

