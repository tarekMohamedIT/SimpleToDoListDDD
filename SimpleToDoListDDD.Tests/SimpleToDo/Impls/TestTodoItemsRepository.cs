using SimpleToDoListDDD.Domain.ToDoItems;

namespace SimpleToDoListDDD.Tests.SimpleToDo.Impls
{
    internal class TestTodoItemsRepository : ISimpleToDoItemsRepository
    {
        private List<SimpleToDoItem> simpleToDoItems;

        public TestTodoItemsRepository()
        {
            simpleToDoItems = new List<SimpleToDoItem>();
        }

        public IEnumerable<SimpleToDoItem> GetAll()
        {
            return simpleToDoItems.AsReadOnly();
        }

        public SimpleToDoItem GetById(Guid id)
        {
            return simpleToDoItems.Find(i => i.Id == id)!;
        }

        public void Save(SimpleToDoItem item)
        {
            if (item.Id == Guid.Empty)
            {
                simpleToDoItems.Add(item);
                return;
            }

            var itemFromList = GetById(item.Id);

            itemFromList.UpdateTitle(item.Title)
                .UpdateDescription(item.Description);
        }
    }
}
