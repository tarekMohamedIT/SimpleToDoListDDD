using SimpleToDoListDDD.Core.Events;
using SimpleToDoListDDD.Domain.ToDoItems;
using SimpleToDoListDDD.Domain.ToDoItems.Events;
using SimpleToDoListDDD.Domain.ValueTypes;
using SimpleToDoListDDD.Tests.SimpleToDo.Impls;

namespace SimpleToDoListDDD.Tests.SimpleToDo
{
    [TestClass]
    public class SimpleToDoServiceTests
    {
        private EventDispatcher dispatcher = null!;
        private TestLogger logger = null!;
        private SimpleToDoItemsService service = null!;

        [TestInitialize]
        public void Initialize()
        {
            dispatcher = new EventDispatcher();
            logger = new TestLogger(Guid.NewGuid());
            var handler = new LoggingEventHandler(logger);

            dispatcher.RegisterHandler<ToDoItemCreatedEvent>(handler);
            dispatcher.RegisterHandler<ToDoItemUpdatedEvent>(handler);

            service = new SimpleToDoItemsService(new TestTodoItemsRepository(), dispatcher);
        }

        [TestMethod]
        public void CanCreateTodoItemAndDispatchEventSuccessfully()
        {
            var title = Title.Create("Test").Value;
            var description = Description.Create("This is a test").Value;

            var creationResult = SimpleToDoItem.Create(Guid.Empty, title!, description!);

            var result = service.Save(creationResult.Value!);

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(1, logger.LogMessages.Count);
        }
    }
}
