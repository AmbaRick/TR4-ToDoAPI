using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Data
{
    /// <summary>
    /// Handles the mapping of the mongoDB spefic fields to class members
    /// </summary>
    public class ToDoRepositoryMapping
    {
        private static ToDoRepositoryMapping instance = null;

        private static readonly object _lock = new object();

        public static ToDoRepositoryMapping Instance
        {
            get
            {
                //check a instance exists othersise causes an error
                if (instance == null)
                {
                    instance = new ToDoRepositoryMapping();
                }
                return instance;
            }
        }

        public ToDoRepositoryMapping RegisterToDoRepository<T>(Action<BsonClassMap<ToDoItem>> classMapInitializer)
        {

            //This ensures locks the instance of async tasks until the mapping has completed
            lock (_lock)
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                {

                    BsonClassMap.RegisterClassMap<ToDoItem>(cm =>
                    {
                        cm.AutoMap();
                        cm.MapIdMember(p => p.Id)
                            .SetIdGenerator(StringObjectIdGenerator.Instance)
                            .SetSerializer(new StringSerializer(BsonType.ObjectId));


                    });
                   
                }
            }
            return this;
        }
    }
}
