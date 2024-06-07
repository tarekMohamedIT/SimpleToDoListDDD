using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Core.Validations.Entries;

namespace SimpleToDoListDDD.Core.Validations
{
    public class SimpleValidator
    {
        private readonly HashSet<string> errorKeys = [];

        public bool IsValid => errorKeys.Count == 0;

        public IEnumerable<string> Errors => errorKeys.ToList().AsReadOnly();

        public Result ValidationResult => IsValid
            ? Result.Success()
            : Result.Failure(Errors);

        public SimpleValidator Validate(ValidationEntry entry)
        {
            IsValidated(entry);

            return this;
        }
        private bool IsValidated(ValidationEntry entry)
        {
            if (errorKeys.Contains(entry.ErrorKey))
                return false;

            if (entry.ValidationFunc())
                return true;

            errorKeys.Add(entry.ErrorKey);
            return false;
        }

        public SimpleValidator ValidateOneOf(params ValidationEntry[] entries)
        {
            foreach (var entry in entries)
            {
                if (!IsValidated(entry)) return this;
            }

            return this;
        }

        public T? ValidateAndSet<T>(ValidationEntry entry, T? value)
        {
            return IsValidated(entry) ? value : default;
        }
    }
}
