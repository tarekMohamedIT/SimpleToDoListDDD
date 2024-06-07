namespace SimpleToDoListDDD.Domain.ToDoItems.Events
{
    public class ToDoItemUpdatedEvent
    {
        public SimpleToDoItem OldItem { get; }
        public SimpleToDoItem NewItem { get; }

        public ToDoItemUpdatedEvent(SimpleToDoItem oldItem, SimpleToDoItem newItem)
        {
            OldItem = oldItem;
            NewItem = newItem;
        }
    }
}
