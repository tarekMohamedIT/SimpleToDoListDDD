using SimpleToDoListDDD.Domain.ToDoItems;
using SimpleToDoListDDD.Domain.ValueTypes;

namespace SimpleToDoListDDD.Tests
{
    [TestClass]
    public class SimpleToDoTests
    {
        [TestMethod]
        public void SimpleToDoItem_CanCreate()
        {
            var title = Title.Create("Test").Value;
            var description = Description.Create("This is a test").Value;

            var creationResult = SimpleToDoItem.Create(Guid.Empty, title!, description!);

            Assert.IsTrue(creationResult.IsSuccess);
        }
    }
}