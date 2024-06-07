using SimpleToDoListDDD.Domain.ValueTypes;

namespace SimpleToDoListDDD.Tests.ValueTypesTests
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var creationResult = Title.Create("Test");
            Assert.IsTrue(creationResult.IsSuccess);
        }

        [TestMethod]
        public void IfIsNull_WillHaveUnsuccessfulResult()
        {
            var creationResult = Title.Create(null!);
            Assert.IsFalse(creationResult.IsSuccess);
        }

        [TestMethod]
        public void IfIsEmptyString_WillHaveUnsuccessfulResult()
        {
            var creationResult = Title.Create("");
            Assert.IsFalse(creationResult.IsSuccess);
            Assert.AreEqual("Title.Required", creationResult.ErrorKeys.First());
        }

        [TestMethod]
        public void IfIsLessThan3CharactersLong_WillHaveUnsuccessfulResult()
        {
            var creationResult = Title.Create("te");
            Assert.IsFalse(creationResult.IsSuccess);
            Assert.AreEqual("Title.TooShort", creationResult.ErrorKeys.First());
        }
    }
}
