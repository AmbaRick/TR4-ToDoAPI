using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Common;
using ToDo.Service.Entities;
using FluentValidation.Results;

using ToDo.Service.Interfaces;

namespace ToDo.Service.ToDoItems
{
    /// <summary>
    /// Service dedicated to dealing with CRUD opertions
    /// Separated the service from API controllers for decoupling and cleaner code
    /// </summary>
    public class ToDoItemService : IToDoService
    {
        private readonly IToDoRepository toDoRepository;
        public ToDoItemService(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }
        public async Task AddToDoItem(ToDoItem newToDoItem)
        {
            //TODO: find a way to add validation in biz rules
            //Added fluent validation in the business model to see how it works
            ToDoItemValidator validator = new ToDoItemValidator();
            ValidationResult results = await validator.ValidateAsync(newToDoItem);
            if (results.IsValid)
            {
                await this.toDoRepository.Add(newToDoItem);
            }
            else
            {
                //TODO: this is not working and needs reviewing - validation review
                //Wanted to validate in the business rules.  Need to find a slick easy way and not throw an actual exception
                Task.FromResult(results);
            }
        }

        public async Task<ToDoItem?> GetToDoItem(string id) => await this.toDoRepository.Get(id);
        
        public async Task<List<ToDoItem>> GetAllToDoItems() => await this.toDoRepository.GetAll();

        public async Task UpdateToDoItem(string id, ToDoItem newToDoItem) => await this.toDoRepository.Update(id, newToDoItem);

        public async Task DeleteToDoItem(string id) => await this.toDoRepository.Delete(id);
    }
}
