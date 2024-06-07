using SimpleToDoListDDD.Core.Extensions;

namespace SimpleToDoListDDD.Core.Validations.Entries
{
    public static class StringValidations
    {
        public static ValidationEntry IsNotNullOrEmpty(string key, string value)
        {
            return new ValidationEntry(key, () => !value.IsNullOrEmpty());
        }

        public static ValidationEntry IsNotNullOrWhiteSpace(string key, string value)
        {
            return new ValidationEntry(key, () => !value.IsNullOrWhiteSpace());
        }

        public static ValidationEntry IsLengthInRange(string key, string value, int min, int max)
        {
            return new ValidationEntry(key, () =>
                !value.IsNullOrWhiteSpace()
                && value.Length >= min && value.Length <= max);
        }
    }
}
