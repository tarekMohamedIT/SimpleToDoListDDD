namespace SimpleToDoListDDD.Core.Results
{
    public sealed class Result<T> : Result
    {
        private T? value;

        public T? Value
        {
            get
            {
                if (!IsSuccess)
                    throw new ResultFailedException(ErrorKeys);

                return value;
            }

            set => this.value = value;
        }

        private Result(bool isSuccess, string errorKey, T? value)
            : base(isSuccess, errorKey)
        {
            Value = value;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, "", value);
        }

        public static new Result<T> Failure(string errorKey)
        {
            return new Result<T>(false, errorKey, default);
        }
    }
}
