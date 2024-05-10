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

            //TODO: consider all validation crerate more rules
            RuleFor(ToDoItem => ToDoItem.Description).NotNull().WithMessage("The ToDO item requires a description");
            RuleFor(x => x.Description).Must(x => x == null || x.Length == 24);
        }
    }
}
