using SimpleToDoListDDD.Core.Extensions;
using SimpleToDoListDDD.Core.Results;

namespace SimpleToDoListDDD.Domain.ValueTypes
{
    public sealed class Title
    {
        public string Value { get; }

        private Title(string title)
        {
            Value = title;
        }

        public static Result<Title> Create(string title)
        {
            if (title.IsNullOrWhiteSpace())
                return Result<Title>.Failure("Title.Required");

            if (title.Length < 3)
                return Result<Title>.Failure("Title.TooShort");

            return Result<Title>.Success(new Title(title));
        }
    }
}
