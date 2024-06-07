namespace SimpleToDoListDDD.Core.Extensions
{
    public static class ParametersExtensions
    {
        public static T ThrowIfNullArgument<T>(this T param, string paramName)
            where T : class
        {
            if (param == null)
                throw new ArgumentNullException(paramName);

            return param;
        }

        public static string ThrowIfNullOrEmptyArgument(this string param, string paramName)
        {
            if (param.IsNullOrEmpty())
                throw new ArgumentNullException(paramName);

            return param;
        }

        public static string ThrowIfNullOrWhiteSpaceArgument(this string param, string paramName)
        {
            if (param.IsNullOrWhiteSpace())
                throw new ArgumentNullException(paramName);

            return param;
        }
    }
}
