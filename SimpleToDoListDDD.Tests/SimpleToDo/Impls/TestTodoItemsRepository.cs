using SimpleToDoListDDD.Domain.ToDoItems;

namespace SimpleToDoListDDD.Tests.SimpleToDo.Impls
{
    internal class TestTodoItemsRepository : ISimpleToDoItemsRepository
    {
        public IEnumerable<SimpleToDoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public SimpleToDoItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(SimpleToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
