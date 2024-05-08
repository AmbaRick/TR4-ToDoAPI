using FluentValidation;
using ToDo.Service.Entities;

namespace ToDo.Service.Common
{
    public class ToDoItemValidator : AbstractValidator<ToDoItem>
    {
        public ToDoItemValidator()
        {
            RuleFor(ToDoItem => ToDoItem.Description).NotNull().WithMessage("The ToDO item requires a description");
            
        }
    }
}
