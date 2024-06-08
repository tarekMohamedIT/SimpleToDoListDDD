using SimpleToDoListDDD.Core.Events;
using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Domain.ToDoItems;
using SimpleToDoListDDD.Domain.ToDoItems.Events;

namespace SimpleToDoListDDD.Tests.SimpleToDo.Impls
{
    public class ToDoItemCreatedEventHandler : IEventHandler<ToDoItemCreatedEvent>
    {
        private readonly TestLogger logger;
        private readonly ISimpleToDoItemsRepository repository;

        public ToDoItemCreatedEventHandler(TestLogger logger, ISimpleToDoItemsRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        public Result Handle(ToDoItemCreatedEvent eventData)
        {
            logger.Log("Creating new ToDoItem");

            repository.Save(eventData.Item);

            logger.Log("Created new ToDoItem");

            return Result.Success();
        }
    }
}
