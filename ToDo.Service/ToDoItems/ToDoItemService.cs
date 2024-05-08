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
        public async Task Add(ToDoItem newToDoItem)
        {

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
    }
}
