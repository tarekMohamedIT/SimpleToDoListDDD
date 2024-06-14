using SimpleToDoListDDD.Core.Validations.Basic;

namespace SimpleToDoListDDD.Core.Validations.Entries
{
    public static class ObjectValidationEntries
    {
        public static ValidationEntry IsNotNull(string key, object obj)
        {
            return new ValidationEntry(key, () => ObjectValidations.IsNotNull(obj));
        }

        public static ValidationEntry IsNotDefault<T>(string key, T obj)
        {
            return new ValidationEntry(key, () => ObjectValidations.IsNotDefault(obj));
        }
    }
}
