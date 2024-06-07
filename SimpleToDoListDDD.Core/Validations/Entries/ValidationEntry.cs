using SimpleToDoListDDD.Core.Extensions;

namespace SimpleToDoListDDD.Core.Validations.Entries
{
    public class ValidationEntry
    {
        public string ErrorKey { get; }
        public Func<bool> ValidationFunc { get; }

        public ValidationEntry(string errorKey, Func<bool> validationFunc)
        {
            ErrorKey = errorKey.ThrowIfNullOrWhiteSpaceArgument(nameof(errorKey));
            ValidationFunc = validationFunc.ThrowIfNullArgument(nameof(validationFunc));
        }
    }
}
