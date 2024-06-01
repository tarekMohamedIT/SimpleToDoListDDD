namespace SimpleToDoListDDD.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool EqualsIgnoreCase(this string str, string compared)
        {
            return str.Equals(compared, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
