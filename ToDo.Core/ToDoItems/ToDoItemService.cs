using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Common;
using ToDo.Core.Entities;
using FluentValidation.Results;

using ToDo.Core.Interfaces;

namespace ToDo.Core.ToDoItems
{
    /// <summary>
    /// Service dedicated to dealing with CRUD opertions
    /// Separated the service from API controllers for decoupling and cleaner code
    /// </summary>
    public class ToDoItemService : IToDoService
    {

        //TODO: sepearte the methods in to their own classes to keep the code clean
        private readonly IToDoRepository toDoRepository;
        public ToDoItemService(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }
        public async Task AddToDoItem(ToDoItem newToDoItem)
        {
            //Added fluent validation in the business rules to see how it works
            ToDoItemValidator validator = new ToDoItemValidator();
            ValidationResult results = await validator.ValidateAsync(newToDoItem);
            if (results.IsValid)
            {
                await this.toDoRepository.Add(newToDoItem);
            }
            else
            {
                //TODO: this is not working and needs reviewing - validation review
                //Wanted to validate in the business rules. 
                Task.FromResult(results);
            }
        }

        public async Task<ToDoItem?> GetToDoItem(string id) => await this.toDoRepository.Get(id);
        
        public async Task<List<ToDoItem>> GetAllToDoItems() => await this.toDoRepository.GetAll();

        public async Task UpdateToDoItem(string id, ToDoItem newToDoItem) => await this.toDoRepository.Update(id, newToDoItem);

        public async Task DeleteToDoItem(string id) => await this.toDoRepository.Delete(id);
    }
}
