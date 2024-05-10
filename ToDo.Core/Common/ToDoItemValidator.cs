using FluentValidation;
using ToDo.Core.Entities;

namespace ToDo.Core.Common
{

    /// <summary>
    /// Validate set up to validate the entry for ToDoItem
    /// </summary>
    public class ToDoItemValidator : AbstractValidator<ToDoItem>
    {
        public ToDoItemValidator()
        {
            RuleFor(ToDoItem => ToDoItem.Description).NotNull().WithMessage("The ToDO item requires a description");
            
        }
    }
}
