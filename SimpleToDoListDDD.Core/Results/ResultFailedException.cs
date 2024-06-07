namespace SimpleToDoListDDD.Core.Results
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator",
        "RCS1194:Implement exception constructors",
        Justification = "Doesn't need the full constructor list")]
    public class ResultFailedException : Exception
    {
        public string ErrorKey { get; }

        public ResultFailedException(string key)
            : base($"The result failed with the following error key: [{key}]")
        {
            this.ErrorKey = key;
        }

    }
}
