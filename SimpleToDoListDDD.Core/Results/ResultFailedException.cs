
namespace SimpleToDoListDDD.Core.Results
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator",
        "RCS1194:Implement exception constructors",
        Justification = "Doesn't need the full constructor list")]
    public class ResultFailedException : Exception
    {
        private readonly List<string> errorKeys;

        public IEnumerable<string> ErrorKeys => errorKeys.AsReadOnly();

        public ResultFailedException(string key)
            : base($"The result failed with the following error key: [{key}]")
        {
            this.errorKeys = [key];
        }

        public ResultFailedException(params string[] errorKeys)
            : this((IEnumerable<string>)errorKeys)
        {
        }

        public ResultFailedException(IEnumerable<string> errorKeys)
            : base($"The result failed with the following error keys: [{string.Join(",", errorKeys)}]")
        {
            this.errorKeys = [.. errorKeys];
        }
    }
}
