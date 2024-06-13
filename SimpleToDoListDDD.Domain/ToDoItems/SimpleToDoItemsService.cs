using SimpleToDoListDDD.Core.Events;
using SimpleToDoListDDD.Core.Extensions;
using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Domain.ToDoItems.Events;

namespace SimpleToDoListDDD.Domain.ToDoItems
{
    public class SimpleToDoItemsService
    {
        private readonly ISimpleToDoItemsRepository _repository;
        private readonly IEventDispatcher _eventDispatcher;

        public SimpleToDoItemsService(
            ISimpleToDoItemsRepository repository,
            IEventDispatcher eventDispatcher)
        {
            _repository = repository.ThrowIfNullArgument(nameof(repository));
            _eventDispatcher = eventDispatcher.ThrowIfNullArgument(nameof(eventDispatcher));
        }

        public IEnumerable<SimpleToDoItem> GetAll()
        {
            return _repository.GetAll();
        }

        public Result<SimpleToDoItem> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return Result<SimpleToDoItem>.Failure("SimpleToDoItem.InvalidId");

            SimpleToDoItem item = _repository.GetById(id);

            return item != null
                ? Result<SimpleToDoItem>.Success(item)
                : Result<SimpleToDoItem>.Failure("SimpleToDoItem.NotFound");
        }

        public Result Save(SimpleToDoItem item)
        {
            if (item == null)
                return Result.Failure("SimpleToDoItem.Required");

            return item.Id == Guid.Empty ? Create(item) : Edit(item);
        }

        private Result Create(SimpleToDoItem item)
        {
            _repository.Save(item);

            var createEvent = new ToDoItemCreatedEvent(item);
            return _eventDispatcher.Dispatch(createEvent);
        }

        private Result Edit(SimpleToDoItem item)
        {
            var itemFromDbResult = GetById(item.Id);

            if (!itemFromDbResult.IsSuccess)
                return itemFromDbResult;

            var itemCreationResult = SimpleToDoItem.Create(
                itemFromDbResult.Value!.Id,
                item.Title,
                item.Description);

            if (!itemCreationResult.IsSuccess) return itemCreationResult;

            _repository.Save(itemCreationResult.Value!);

            var updateEvent = new ToDoItemUpdatedEvent(itemFromDbResult.Value, itemCreationResult.Value!);
            return _eventDispatcher.Dispatch(updateEvent);
        }
    }
}
