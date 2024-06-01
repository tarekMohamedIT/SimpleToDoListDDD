using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Domain.ValueTypes;

namespace SimpleToDoListDDD.Domain.ToDoItems
{
    public sealed class SimpleToDoItem
    {
        public Guid Id { get; }
        public Title Title { get; private set; }
        public Description Description { get; private set; }

        private SimpleToDoItem(Guid id, Title title, Description description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public static Result<SimpleToDoItem> Create(Guid id, Title title, Description description)
        {
            if (title == null)
                return Result<SimpleToDoItem>.Failure("SimpleToDoItem.RequiredTitle");

            if (description == null)
                return Result<SimpleToDoItem>.Failure("SimpleToDoItem.RequiredDescription");

            return Result<SimpleToDoItem>.Success(new SimpleToDoItem(id, title, description));
        }

        public SimpleToDoItem UpdateTitle(Title title)
        {
            this.Title = title;

            return this;
        }

        public SimpleToDoItem UpdateDescription(Description description)
        {
            this.Description = description;

            return this;
        }
    }
}
