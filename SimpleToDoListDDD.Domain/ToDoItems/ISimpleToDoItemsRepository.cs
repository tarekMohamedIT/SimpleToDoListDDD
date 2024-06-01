namespace SimpleToDoListDDD.Domain.ToDoItems
{
    public interface ISimpleToDoItemsRepository
    {
        IEnumerable<SimpleToDoItem> GetAll();
        SimpleToDoItem GetById(Guid id);
        void Save(SimpleToDoItem item);
    }
}
