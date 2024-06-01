using SimpleToDoListDDD.Core.Extensions;
using SimpleToDoListDDD.Core.Results;

namespace SimpleToDoListDDD.Domain.ValueTypes
{
    public sealed class Description
    {
        public string Value { get; }

        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description> Create(string value)
        {
            if (value.IsNullOrWhiteSpace())
                return Result<Description>.Failure("Description.Required");

            return Result<Description>.Success(new Description(value));
        }
    }
}
