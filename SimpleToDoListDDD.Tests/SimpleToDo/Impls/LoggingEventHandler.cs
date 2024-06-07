using SimpleToDoListDDD.Core.Events;
using SimpleToDoListDDD.Core.Extensions;
using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Domain.ToDoItems.Events;

namespace SimpleToDoListDDD.Tests.SimpleToDo.Impls
{
    internal class LoggingEventHandler
        : IEventHandler<ToDoItemCreatedEvent>,
        IEventHandler<ToDoItemUpdatedEvent>
    {
        private readonly TestLogger logger;

        public LoggingEventHandler(TestLogger logger)
        {
            this.logger = logger.ThrowIfNullArgument(nameof(logger));
        }

        public Result Handle(ToDoItemCreatedEvent eventData)
        {
            logger.Log("TodoItemCreated [" + eventData.Item.Title + "]");

            return Result.Success();
        }

        public Result Handle(ToDoItemUpdatedEvent eventData)
        {
            logger.Log("TodoItemUpdated From [" + eventData.OldItem.Title + "] To [" + eventData.NewItem.Title + "]");
            return Result.Success();
        }
    }
}
