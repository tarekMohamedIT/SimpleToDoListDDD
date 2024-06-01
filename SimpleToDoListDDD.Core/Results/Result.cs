namespace SimpleToDoListDDD.Core.Results
{
    public class Result
    {
        public bool IsSuccess { get; }

        public string ErrorKey { get; }

        protected internal Result(bool isSuccess, string errorKey)
        {
            IsSuccess = isSuccess;
            ErrorKey = errorKey;
        }

        public static Result Success()
        {
            return new Result(true, "");
        }

        public static Result Failure(string errorKey)
        {
            return new Result(false, errorKey);
        }
    }
}
