using SimpleToDoListDDD.Core.Validations.Basic;

namespace SimpleToDoListDDD.Core.Validations.Entries
{
    public static class StringValidationEntries
    {
        public static ValidationEntry IsNotNullOrEmpty(string key, string value)
        {
            return new ValidationEntry(key, () => StringValidations.IsNotNullOrEmpty(value));
        }

        public static ValidationEntry IsNotNullOrWhiteSpace(string key, string value)
        {
            return new ValidationEntry(key, () => StringValidations.IsNotNullOrWhiteSpace(value));
        }

        public static ValidationEntry IsLengthInRange(string key, string value, int min, int max)
        {
            return new ValidationEntry(key, () => StringValidations.IsLengthInRange(value, min, max));
        }
    }
}
