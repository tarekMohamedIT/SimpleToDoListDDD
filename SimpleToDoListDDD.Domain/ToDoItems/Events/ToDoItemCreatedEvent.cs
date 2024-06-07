using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoListDDD.Domain.ToDoItems.Events
{
    public class ToDoItemCreatedEvent
    {
        public ToDoItemCreatedEvent(SimpleToDoItem item)
        {
            Item = item;
        }

        public SimpleToDoItem Item { get; }
    }
}
