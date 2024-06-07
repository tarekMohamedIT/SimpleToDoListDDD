using SimpleToDoListDDD.Domain.ToDoItems;
using SimpleToDoListDDD.Domain.ValueTypes;
using System.Linq;

namespace SimpleToDoListDDD.Tests.SimpleToDo
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

        [TestMethod]
        public void SimpleToDoItem_IfNullTitleIsPassed_WillHaveUnsuccessfulResult()
        {
            Title title = null!;
            var description = Description.Create("This is a test").Value;

            var creationResult = SimpleToDoItem.Create(Guid.Empty, title!, description!);

            Assert.IsFalse(creationResult.IsSuccess);
            Assert.AreEqual("SimpleToDoItem.RequiredTitle", creationResult.ErrorKeys.First());
        }

        [TestMethod]
        public void SimpleToDoItem_IfNullDescriptionIsPassed_WillHaveUnsuccessfulResult()
        {
            var title = Title.Create("Test").Value;
            Description description = null!;

            var creationResult = SimpleToDoItem.Create(Guid.Empty, title!, description!);

            Assert.IsFalse(creationResult.IsSuccess);
            Assert.AreEqual("SimpleToDoItem.RequiredDescription", creationResult.ErrorKeys.First());
        }

        [TestMethod]
        public void SimpleToDoItem_IfNullParametersArePassed_WillHaveUnsuccessfulResult()
        {
            Title title = null!;
            Description description = null!;

            var creationResult = SimpleToDoItem.Create(Guid.Empty, title, description);

            Assert.IsFalse(creationResult.IsSuccess);
            Assert.AreEqual("SimpleToDoItem.RequiredTitle", creationResult.ErrorKeys.ElementAt(0));
            Assert.AreEqual("SimpleToDoItem.RequiredDescription", creationResult.ErrorKeys.ElementAt(1));
        }
    }
}