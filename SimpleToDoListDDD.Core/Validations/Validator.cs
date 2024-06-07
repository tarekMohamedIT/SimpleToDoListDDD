using SimpleToDoListDDD.Core.Extensions;

namespace SimpleToDoListDDD.Core.Validations
{
    public class Validator
    {
        private readonly HashSet<string> errorKeys = [];

        public bool IsValid => errorKeys.Count == 0;

        public IEnumerable<string> Errors => errorKeys.ToList().AsReadOnly();

        public Validator Validate(string errorKey, Func<bool> checkFunc)
        {
            IsValidated(errorKey, checkFunc);

            return this;
        }

        private bool IsValidated(string errorKey, Func<bool> checkFunc)
        {
            errorKey.ThrowIfNullOrWhiteSpaceArgument(nameof(errorKey));
            checkFunc.ThrowIfNullArgument(nameof(checkFunc));

            if (errorKeys.Contains(errorKey))
                return false;

            if (checkFunc())
                return true;

            errorKeys.Add(errorKey);
            return false;
        }

        public T? ValidateAndSet<T>(string errorKey, T? value, Func<bool> isValid)
        {
            return IsValidated(errorKey, isValid) ? value : default;
        }
    }
}
