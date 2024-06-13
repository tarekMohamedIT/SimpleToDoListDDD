using SimpleToDoListDDD.Core.Extensions;
using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Core.Validations;
using SimpleToDoListDDD.Core.Validations.Entries;
using SimpleToDoListDDD.Domain.ValueTypes;

namespace SimpleToDoListDDD.Domain.ToDoItems
{
    public sealed class SimpleToDoItem
    {
        public Guid Id { get; private set; }
        public Title Title { get; private set; }
        public Description Description { get; private set; }

        private SimpleToDoItem(Guid id, Title title, Description description)
        {
            Id = id.ThrowIfDefaultArgument(nameof(id));
            Title = title.ThrowIfNullArgument(nameof(title));
            Description = description.ThrowIfNullArgument(nameof(description));
        }

        public static Result<SimpleToDoItem> Create(Guid id, Title title, Description description)
        {
            var validator = new SimpleValidator()
                .Validate(ObjectValidations.IsNotNull("SimpleToDoItem.RequiredTitle", title))
                .Validate(ObjectValidations.IsNotNull("SimpleToDoItem.RequiredDescription", description));

            return validator.IsValid
                ? Result<SimpleToDoItem>.Success(new SimpleToDoItem(id, title, description))
                : Result<SimpleToDoItem>.Failure(validator.Errors);
        }

        public Result ChangeId(Guid id)
        {
            if (Id != Guid.Empty)
                return Result.Failure("SimpleToDoItem.IdAlreadySet");

            Id = id;
            return Result.Success();
        }

        public SimpleToDoItem UpdateTitle(Title title)
        {
            Title = title.ThrowIfNullArgument(nameof(title));

            return this;
        }

        public SimpleToDoItem UpdateDescription(Description description)
        {
            Description = description.ThrowIfNullArgument(nameof(description));

            return this;
        }
    }
}
