namespace SimpleToDoListDDD.Tests.SimpleToDo.Impls
{
    public class TestLogger
    {
        private readonly Guid sessionId;

        public List<string> LogMessages { get; }

        public TestLogger(Guid sessionId)
        {
            LogMessages = [];
            this.sessionId = sessionId;
        }

        public void Log(string message)
        {
            LogMessages.Add(message);
        }
    }
}
