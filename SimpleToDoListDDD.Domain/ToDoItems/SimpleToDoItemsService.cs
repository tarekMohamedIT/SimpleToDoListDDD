using SimpleToDoListDDD.Core.Results;

namespace SimpleToDoListDDD.Domain.ToDoItems
{
    public class SimpleToDoItemsService(ISimpleToDoItemsRepository repository)
    {
        private readonly ISimpleToDoItemsRepository repository = repository;

        public IEnumerable<SimpleToDoItem> GetAll()
        {
            return repository.GetAll();
        }

        public Result<SimpleToDoItem> GetById(Guid id)
        {
            SimpleToDoItem item = repository.GetById(id);

            return item != null
                ? Result<SimpleToDoItem>.Success(item)
                : Result<SimpleToDoItem>.Failure("SimpleToDoItem.NotFound");
        }

        public Result Save(SimpleToDoItem item)
        {
            if (item == null)
                return Result.Failure("SimpleToDoItem.Required");

            if (item.Id == Guid.Empty)
                return Create(item);

            else return Edit(item);
        }

        private Result Create(SimpleToDoItem item)
        {
            repository.Save(item);

            return Result.Success();
        }

        private Result Edit(SimpleToDoItem item)
        {
            var itemFromDbResult = GetById(item.Id);

            if (!itemFromDbResult.IsSuccess)
                return itemFromDbResult;

            var itemToBeSaved = itemFromDbResult.Value!
                .UpdateTitle(item.Title)
                .UpdateDescription(item.Description);

            repository.Save(itemToBeSaved);

            return Result.Success();
        }
    }
}
