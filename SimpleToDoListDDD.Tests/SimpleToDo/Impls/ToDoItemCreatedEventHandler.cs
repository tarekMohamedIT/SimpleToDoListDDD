using SimpleToDoListDDD.Core.Events;
using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Domain.ToDoItems.Events;

namespace SimpleToDoListDDD.Tests.SimpleToDo.Impls
{
    public class ToDoItemCreatedEventHandler : IEventHandler<ToDoItemCreatedEvent>
    {
        private readonly TestLogger logger;

        public ToDoItemCreatedEventHandler(TestLogger logger)
        {
            this.logger = logger;
        }

        public Result Handle(ToDoItemCreatedEvent eventData)
        {
            logger.Log("Created new ToDoItem");

            return Result.Success();
        }
    }
}
