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

        private Result(bool isSuccess, T? value, string errorKey)
            : base(isSuccess, errorKey)
        {
            Value = value;
        }

        private Result(bool isSuccess, T? value, params string[] errorKeys)
            : this(isSuccess, value, (IEnumerable<string>)errorKeys)
        {
        }

        private Result(bool isSuccess, T? value, IEnumerable<string> errorKeys)
            : base(isSuccess, errorKeys)
        {
            this.Value = value;
        }


        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, "");
        }

        public static new Result<T> Failure(string errorKey)
        {
            return new Result<T>(false, default, errorKey);
        }

        public static new Result<T> Failure(IEnumerable<string> errorKeys)
        {
            return new Result<T>(false, default, errorKeys);
        }
    }
}
