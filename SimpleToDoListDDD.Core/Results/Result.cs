﻿namespace SimpleToDoListDDD.Core.Results
{
    public class Result
    {
        public bool IsSuccess { get; }

        private readonly List<string> _results;
        public IEnumerable<string> ErrorKeys => _results.AsReadOnly();

        protected internal Result(bool isSuccess, string errorKey)
        {
            IsSuccess = isSuccess;
            _results = [errorKey];
        }
        protected internal Result(bool isSuccess, params string[] errorKeys)
        {
            IsSuccess = isSuccess;
            _results = [.. errorKeys];
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
