namespace SimpleToDoListDDD.Core.Validations.Entries
{
    public static class ObjectValidations
    {
        public static ValidationEntry IsNotNull(string key, object obj)
        {
            return new ValidationEntry(key, () => obj != null);
        }

        public static ValidationEntry IsNotDefault<T>(string key, T obj)
        {
            return new ValidationEntry(key, () => !obj!.Equals(default(T)));
        }
    }
}
