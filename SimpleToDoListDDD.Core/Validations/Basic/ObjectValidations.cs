namespace SimpleToDoListDDD.Core.Validations.Basic
{
    public static class ObjectValidations
    {
        public static bool IsNotNull(object obj)
        {
            return obj != null;
        }

        public static bool IsNotDefault<T>(T obj)
        {
            return !obj!.Equals(default(T));
        }
    }
}
