using SimpleToDoListDDD.Domain.ValueTypes;

namespace SimpleToDoListDDD.Tests.ValueTypesTests
{
    [TestClass]
    public class DescriptionTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var creationResult = Description.Create("Test");
            Assert.IsTrue(creationResult.IsSuccess);
        }

        [TestMethod]
        public void IfIsNull_WillHaveUnsuccessfulResult()
        {
            var creationResult = Description.Create(null!);
            Assert.IsFalse(creationResult.IsSuccess);
            Assert.AreEqual("Description.Required", creationResult.ErrorKey);
        }
    }
}
