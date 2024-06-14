using SimpleToDoListDDD.Core.Extensions;

namespace SimpleToDoListDDD.Core.Validations.Basic
{
    public static class StringValidations
    {
        public static bool IsNotNullOrEmpty(string value)
        {
            return !value.IsNullOrEmpty();
        }

        public static bool IsNotNullOrWhiteSpace(string value)
        {
            return !value.IsNullOrWhiteSpace();
        }

        public static bool IsLengthInRange(string value, int min, int max)
        {
            return !value.IsNullOrWhiteSpace()
                && value.Length >= min && value.Length <= max;
        }
    }
}
